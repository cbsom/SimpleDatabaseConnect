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

namespace SimpleDatabaseConnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string err = null;

            Properties.Settings.Default.Save();
            try
            {
                if (Properties.Settings.Default.OleDbChecked)
                {
                    try
                    {
                        using (var con = new OleDbConnection(this.textBox1.Text))
                        {
                            using (var adptr = new OleDbDataAdapter(this.textBox2.Text, con))
                            {
                                DataSet ds = new DataSet();
                                adptr.Fill(ds);
                                this.dataGridView1.DataSource = ds.Tables[0];
                                this.dataGridView1.Refresh();
                            }
                        }
                    }
                    catch (OleDbException oe)
                    {
                        err = oe.Message + Environment.NewLine + oe.StackTrace;
                    }
                }
                else if (Properties.Settings.Default.SqlServer)
                {
                    try
                    {
                        using (var con = new SqlConnection(this.textBox1.Text))
                        {
                            using (var adptr = new SqlDataAdapter(this.textBox2.Text, con))
                            {
                                DataSet ds = new DataSet();
                                adptr.Fill(ds);
                                this.dataGridView1.DataSource = ds.Tables[0];
                                this.dataGridView1.Refresh();
                            }
                        }
                    }
                    catch (SqlException se)
                    {
                        err = se.Message + Environment.NewLine + se.StackTrace;
                    }
                }
            }
            catch(Exception ex)
            {
                err = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            this.tbError.Visible = !string.IsNullOrEmpty(err);
            this.tbError.Text = err;
        }



        private void rbOleDb_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButton2.Checked = !rbOleDb.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.rbOleDb.Checked = !radioButton2.Checked;
        }
    }
}
