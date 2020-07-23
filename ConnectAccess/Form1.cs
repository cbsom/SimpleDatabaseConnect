using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.Common;

namespace SimpleDatabaseConnect
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnection con = null;
            DbDataAdapter adp = null;
            string err = null;

            try
            {
                if (this.rbOleDb.Checked)
                {
                    Properties.Settings.Default.Provider = "OleDb";
                    con = new OleDbConnection(this.textBox1.Text.Trim());
                    adp = new OleDbDataAdapter(this.textBox2.Text, con as OleDbConnection);
                }
                else if (this.rbSqlServer.Checked)
                {
                    Properties.Settings.Default.Provider = "SqlServer";
                    con = new SqlConnection(this.textBox1.Text.Trim());
                    adp = new SqlDataAdapter(this.textBox2.Text, con as SqlConnection);
                }
                else if (this.rbOdbc.Checked)
                {
                    Properties.Settings.Default.Provider = "Odbc";
                    con = new OdbcConnection(this.textBox1.Text.Trim());
                    adp = new OdbcDataAdapter(this.textBox2.Text, con as OdbcConnection);
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
