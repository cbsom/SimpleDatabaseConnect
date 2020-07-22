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

namespace ConnectAccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            using (var con = new OleDbConnection(this.textBox1.Text))
            {
                using(var adptr = new OleDbDataAdapter(this.textBox2.Text, con))
                {
                    DataSet ds = new DataSet();
                    adptr.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0];
                    this.dataGridView1.Refresh();
                }
            }
        }
    }
}
