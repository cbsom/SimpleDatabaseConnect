using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimpleDatabaseConnect
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
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

        private void ExecuteSql()
        {
            DbConnection con = null;
            DbDataAdapter adp = null;
            string err = null;
            string sql = this.fastColoredTextBox1.Selection.IsEmpty
                ? this.fastColoredTextBox1.Text
                : this.fastColoredTextBox1.Selection.Text;

            try
            {
                if (this.rbOleDb.Checked)
                {
                    Properties.Settings.Default.Provider = "OleDb";
                    con = new OleDbConnection(this.textBox1.Text.Trim());
                    adp = new OleDbDataAdapter(sql, con as OleDbConnection);
                }
                else if (this.rbSqlServer.Checked)
                {
                    Properties.Settings.Default.Provider = "SqlServer";
                    con = new SqlConnection(this.textBox1.Text.Trim());
                    adp = new SqlDataAdapter(sql, con as SqlConnection);
                }
                else if (this.rbOdbc.Checked)
                {
                    Properties.Settings.Default.Provider = "Odbc";
                    con = new OdbcConnection(this.textBox1.Text.Trim());
                    adp = new OdbcDataAdapter(sql, con as OdbcConnection);
                }

                Properties.Settings.Default.Save();

                try
                {
                    using (con)
                    {
                        using (adp)
                        {
                            DataSet ds = new DataSet();
                            adp.Fill(ds);
                            this.dataGridView1.DataSource = ds.Tables[0];
                            this.dataGridView1.Refresh();
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
            }
            catch (Exception ex)
            {
                err = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            this.tbError.Visible = !string.IsNullOrEmpty(err);
            this.tbError.Text = err;            
        }        
    }
}
