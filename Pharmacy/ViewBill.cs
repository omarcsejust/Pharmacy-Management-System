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
    public partial class ViewBill : Form
    {
        public ViewBill()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                OleDbCommand pmntBillcmd = new OleDbCommand("select * from payment_bill where bill_no='"+textBillNo.Text.ToString()+"'",conn);
                OleDbDataAdapter pmntAdapter = new OleDbDataAdapter(pmntBillcmd.CommandText,conn);
                DataTable pmntDta = new DataTable();
                pmntAdapter.Fill(pmntDta);
                OleDbDataAdapter oda = new OleDbDataAdapter("select drug_name,batch_no,drug_type,company_name,expire_date,quantity,mrp,total_amount from sale_info where bill_no='" + textBillNo.Text.ToString() + "'", conn);
                conn.Close();
                DataTable dtt = new DataTable();
                oda.Fill(dtt);
                dataGridView1.DataSource = dtt;

                int count = pmntDta.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string getTotal = pmntDta.Rows[i]["amount"].ToString();
                    string getDiscount = pmntDta.Rows[i]["discount"].ToString();
                    string getFinal = pmntDta.Rows[i]["total_amount"].ToString();
                    textAmount.Text = getTotal;
                    textDiscount.Text = getDiscount;
                    textPayAmount.Text = getFinal;
                }
            }
            catch(Exception excp){
                MessageBox.Show(excp.Message);
            }
        }
    }
}
