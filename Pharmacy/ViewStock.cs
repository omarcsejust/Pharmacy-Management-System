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

namespace Pharmacy
{
    public partial class ViewStock : Form
    {
        public ViewStock()
        {
            InitializeComponent();
        }
        DataTable dt;
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbDataAdapter oda = new OleDbDataAdapter("select * from medicine",conn);
                dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2_Click(null,null);
            DataView dv=new DataView(dt);
            dv.RowFilter = string.Format("drug_name like '%{0}%'",textBox1.Text);
            dataGridView1.DataSource = dv;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbDataAdapter oda = new OleDbDataAdapter("select * from medicine where amount<'"+textQty.Text.ToString()+"'",conn);
                DataTable dta = new DataTable();
                oda.Fill(dta);
                dataGridView1.DataSource = dta;
                conn.Close();
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
