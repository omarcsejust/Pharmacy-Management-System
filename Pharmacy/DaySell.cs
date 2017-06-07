using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Pharmacy
{
    public partial class DaySell : Form
    {
        public DaySell()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                OleDbDataAdapter oda = new OleDbDataAdapter("select * from payment_bill where sold_date='"+this.dateTimePicker1.Text.ToString()+"'",conn);
                DataTable dt = new DataTable();
                conn.Close();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                int count = dt.Rows.Count;
                float sum = 0;
                for (int i = 0; i < count; i++)
                {
                    string finalAmount=dt.Rows[i]["total_amount"].ToString();
                    sum = sum + float.Parse(finalAmount);
                }
                textBox1.Text = Convert.ToString(sum);
            }
            catch(Exception excp){
                MessageBox.Show(excp.Message);
            }
        }
    }
}
