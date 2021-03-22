using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleDatabaseConnect
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate (object sender, DataGridViewRowPostPaintEventArgs e)
            {
                using (var brush = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                        e.InheritedRowStyle.Font,
                        brush,
                        e.RowBounds.Location.X + 15,
                        e.RowBounds.Location.Y + 4);
                }
            };

            switch (Properties.Settings.Default.Provider)
            {
                case "OleDb":
                    this.rbOleDb.Checked = true;
                    break;
                case "SqlServer":
                    this.rbSqlServer.Checked = true;
                    break;
                case "Odbc":
                    this.rbOdbc.Checked = true;
                    break;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length > 0)
            {
                this.testConnectionAsync();
            }
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                this.ExecuteSql();
            }
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
            if (this.dataGridView1.DataSource != null && this.dataGridView1.DataSource is DataTable)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Save results as Excel file";
                    sfd.Filter = "Excel file (*.xlsx)|*.xlsx";
                    sfd.DefaultExt = ".xlsx";
                    sfd.OverwritePrompt = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            workbook.AddWorksheet(this.dataGridView1.DataSource as DataTable);
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show($"The data has been successfully exported to {sfd.FileName}.");
                        }
                    }
                }
            }
        }

        private void ExecuteSql()
        {
            string sql = this.fastColoredTextBox1.Selection.IsEmpty
                    ? this.fastColoredTextBox1.Text
                    : this.fastColoredTextBox1.Selection.Text;
            string err = null;

            this.tbError.Visible = this.tbMessage.Visible = false;
            this.buttonExportToExcel.Visible = false;
            this.buttonExportToExcel.Enabled = false;

            this.SaveConnectionType();

            try
            {
                using (DbConnection con = this.GetConnection())
                {
                    using (DbDataAdapter adp = this.GetAdapter(con, sql))
                    {
                        try
                        {

                            if (sql.Trim().StartsWith("select", StringComparison.OrdinalIgnoreCase))
                            {
                                DataSet ds = new DataSet();
                                adp.Fill(ds);
                                this.dataGridView1.DataSource = ds.Tables[0];
                                this.dataGridView1.Refresh();
                                this.rowCountStatusLabel.Text = $"{ds.Tables[0].Rows.Count} rows returned";
                                this.buttonExportToExcel.Visible = true;
                                this.buttonExportToExcel.Enabled = true;
                            }
                            else
                            {
                                using (var com = con.CreateCommand())
                                {
                                    com.CommandText = sql;
                                    con.Open();
                                    int records = com.ExecuteNonQuery();
                                    this.tbMessage.Text = this.rowCountStatusLabel.Text = $"Complete. {records} records affected.";
                                    this.tbMessage.Visible = true;
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
                            {
                                con.Close();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                err = ex.Message + Environment.NewLine + ex.StackTrace;
            }


            this.tbError.Visible = !string.IsNullOrEmpty(err);
            this.tbError.Text = err;
            if (tbError.Visible)
            {
                this.tbMessage.Visible = false;
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.testConnectionAsync();
        }

        private async void testConnectionAsync()
        {
            string err = null;

            this.lblConnectionTest.Text = "Testing connection...";
            this.lblConnectionTest.ForeColor = Color.Purple;

            try
            {
                using (var con = this.GetConnection())
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
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }


            if (string.IsNullOrEmpty(err))
            {
                this.lblConnectionTest.Text = "Connection test succeeded.";
                this.lblConnectionTest.ForeColor = Color.DarkGreen;
            }
            else
            {
                this.lblConnectionTest.Text = "Connection test failed. " + err;
                this.lblConnectionTest.ForeColor = Color.Red;
            }
        }

        private DbConnection GetConnection()
        {
            DbConnection con = null;

            if (this.rbOleDb.Checked)
            {
                con = new OleDbConnection(this.textBox1.Text.Trim());
            }
            else if (this.rbSqlServer.Checked)
            {
                con = new SqlConnection(this.textBox1.Text.Trim());
            }
            else if (this.rbOdbc.Checked)
            {
                con = new OdbcConnection(this.textBox1.Text.Trim());
            }

            return con;
        }

        private DbDataAdapter GetAdapter(DbConnection con, string sql)
        {
            DbDataAdapter adp = null;

            if (con is OleDbConnection)
            {
                adp = new OleDbDataAdapter(sql, con as OleDbConnection);
            }
            else if (con is SqlConnection)
            {
                adp = new SqlDataAdapter(sql, con as SqlConnection);
            }
            else if (con is OdbcConnection)
            {
                adp = new OdbcDataAdapter(sql, con as OdbcConnection);
            }

            return adp;
        }

        private void SaveConnectionType()
        {
            if (this.rbOleDb.Checked)
            {
                Properties.Settings.Default.Provider = "OleDb";
            }
            else if (this.rbSqlServer.Checked)
            {
                Properties.Settings.Default.Provider = "SqlServer";
            }
            else if (this.rbOdbc.Checked)
            {
                Properties.Settings.Default.Provider = "Odbc";
            }

            Properties.Settings.Default.Save();
        }
    }
}
