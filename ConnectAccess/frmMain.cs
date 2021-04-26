using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;
using SimpleDatabaseConnect.Properties;

namespace SimpleDatabaseConnect
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            this.InitializeComponent();
            dataGridView1.RowPostPaint +=
                delegate (object sender, DataGridViewRowPostPaintEventArgs e)
                {
                    using (var brush =
                        new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
                    {
                        e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                            e.InheritedRowStyle.Font,
                            brush,
                            e.RowBounds.Location.X + 15,
                            e.RowBounds.Location.Y + 4);
                    }
                };

            switch (Settings.Default.Provider)
            {
                case "OleDb":
                    rbOleDb.Checked = true;
                    break;
                case "SqlServer":
                    rbSqlServer.Checked = true;
                    break;
                case "Odbc":
                    rbOdbc.Checked = true;
                    break;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                this.testConnectionAsync();
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                this.ExecuteSql();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ExecuteSql();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            this.testConnectionAsync();
        }

        private void rbConType_CheckedChanged(object sender, EventArgs e)
        {
            this.testConnectionAsync();
        }

        private void buttonExportToExcel_ButtonClick(object sender, EventArgs e)
        {
            if (!(dataGridView1.DataSource is DataTable table))
                return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Save results as Excel file";
                sfd.Filter = "Excel file (*.xlsx)|*.xlsx";
                sfd.DefaultExt = ".xlsx";
                sfd.OverwritePrompt = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        workbook.AddWorksheet(table);
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show(
                            $"The data has been successfully exported to {sfd.FileName}.");
                    }
                }
            }
        }

        private void ExecuteSql()
        {
            string sql = fastColoredTextBox1.Selection.IsEmpty
                ? fastColoredTextBox1.Text
                : fastColoredTextBox1.Selection.Text;
            string err = null;

            tbError.Visible = tbMessage.Visible = false;
            tbError.Text = "";
            tbMessage.Text = "";
            buttonExportToExcel.Visible = false;
            buttonExportToExcel.Enabled = false;

            this.SaveConnectionType();

            try
            {
                using (DbConnection con = this.GetConnection())
                {
                    try
                    {
                        if (sql.Trim().StartsWith("select", StringComparison.OrdinalIgnoreCase))
                        {
                            var ds = new DataSet();

                            using (DbDataAdapter adp = GetAdapter(con, sql))
                            {
                                adp.Fill(ds);
                            }

                            dataGridView1.DataSource = ds.Tables[0];
                            dataGridView1.Refresh();
                            rowCountStatusLabel.Text = $@"{ds.Tables[0].Rows.Count} rows returned";
                            buttonExportToExcel.Visible = true;
                            buttonExportToExcel.Enabled = true;
                        }
                        else
                        {
                            using (DbCommand com = con.CreateCommand())
                            {
                                var records = 0;
                                var sqlStatements = new HashSet<string>();
                                if (cbSplit.Checked)
                                {
                                    foreach (string s in sql.Split(';'))
                                    {
                                        sqlStatements.Add(s);
                                    }
                                }
                                else
                                {
                                    sqlStatements.Add(sql);
                                }

                                con.Open();


                                foreach (string sqlStatement in sqlStatements)
                                {
                                    com.CommandText = sqlStatement;
                                    try
                                    {
                                        int r = com.ExecuteNonQuery();
                                        records += r;
                                        tbMessage.AppendText($@"Completed {sqlStatement}. {r} records affected.");
                                    }
                                    catch (OleDbException oe)
                                    {
                                        tbMessage.AppendText($@"FAILED: {sqlStatement}. {oe.Message}.");
                                    }
                                    catch (SqlException se)
                                    {
                                        tbMessage.AppendText($@"FAILED: {sqlStatement}. {se.Message}.");
                                    }
                                    catch (OdbcException de)
                                    {
                                        tbMessage.AppendText($@"FAILED: {sqlStatement}. {de.Message}.");
                                    }
                                    catch (Exception ex)
                                    {
                                        tbMessage.AppendText($@"FAILED: {sqlStatement}. {ex.Message}.");
                                    }

                                    this.tbMessage.Refresh();
                                }


                                if (con.State != ConnectionState.Closed)
                                {
                                    con.Close();
                                }

                                rowCountStatusLabel.Text =
                                    $@"Complete. {records} records affected.";
                                tbMessage.Visible = true;
                            }
                        }
                    }
                    catch (OleDbException oe)
                    {
                        err = oe.Message + Environment.NewLine + oe.StackTrace;
                    }
                    catch (SqlException se)
                    {
                        err = se.Message + Environment.NewLine + se.StackTrace;
                    }
                    catch (OdbcException de)
                    {
                        err = de.Message + Environment.NewLine + de.StackTrace;
                    }
                    catch (Exception ex)
                    {
                        err = ex.Message + Environment.NewLine + ex.StackTrace;
                    }
                    finally
                    {
                        if (con != null && con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                err = ex.Message + Environment.NewLine + ex.StackTrace;
            }


            tbError.Visible = !string.IsNullOrEmpty(err);
            tbError.Text = err;
            if (tbError.Visible)
                tbMessage.Visible = false;
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.testConnectionAsync();
        }

        private async void testConnectionAsync()
        {
            string err = null;

            lblConnectionTest.Text = @"Testing connection...";
            lblConnectionTest.ForeColor = Color.Purple;

            try
            {
                using (DbConnection con = this.GetConnection())
                {
                    try
                    {
                        await con.OpenAsync();
                    }

                    catch (OleDbException oe)
                    {
                        err = oe.Message;
                    }
                    catch (SqlException se)
                    {
                        err = se.Message;
                    }
                    catch (OdbcException de)
                    {
                        err = de.Message;
                    }
                    catch (Exception ex)
                    {
                        err = ex.Message;
                    }

                    finally
                    {
                        if (con != null && con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }


            if (string.IsNullOrEmpty(err))
            {
                lblConnectionTest.Text = "Connection test succeeded.";
                lblConnectionTest.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblConnectionTest.Text = "Connection test failed. " + err;
                lblConnectionTest.ForeColor = Color.Red;
            }
        }

        private DbConnection GetConnection()
        {
            DbConnection con = null;

            if (rbOleDb.Checked)
            {
                con = new OleDbConnection(textBox1.Text.Trim());
            }
            else if (rbSqlServer.Checked)
            {
                con = new SqlConnection(textBox1.Text.Trim());
            }
            else if (rbOdbc.Checked)
                con = new OdbcConnection(textBox1.Text.Trim());

            return con;
        }

        private static DbDataAdapter GetAdapter(DbConnection con, string sql)
        {
            DbDataAdapter adp = null;

            switch (con)
            {
                case OleDbConnection connection:
                    adp = new OleDbDataAdapter(sql, connection);
                    break;
                case SqlConnection sqlConnection:
                    adp = new SqlDataAdapter(sql, sqlConnection);
                    break;
                case OdbcConnection odbcConnection:
                    adp = new OdbcDataAdapter(sql, odbcConnection);
                    break;
            }

            return adp;
        }

        private void SaveConnectionType()
        {
            if (rbOleDb.Checked)
            {
                Settings.Default.Provider = "OleDb";
            }
            else if (rbSqlServer.Checked)
            {
                Settings.Default.Provider = "SqlServer";
            }
            else if (rbOdbc.Checked)
                Settings.Default.Provider = "Odbc";

            Settings.Default.Save();
        }
    }
}