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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }
        // Generating Drug Id........................
        int max_id;
        public int GetMedicineId() {
            OleDbCommand cmd = new OleDbCommand("select * from medicine order by drug_id asc",conn);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd.CommandText,conn);
            DataTable dta = new DataTable();
            oda.Fill(dta);
            int count = dta.Rows.Count;
            if (count == 0)
            {
                return count + 1;
            }
            else {
                string get_max_id = dta.Rows[count - 1]["drug_id"].ToString();
                max_id = Int32.Parse(get_max_id);
                return max_id + 1;
            }
        }

        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string dname, bnum, quantity, price,dType,company;
                float getRate, getAmount;
                int id;
                dname = textName.Text.ToString();
                bnum = textBatch.Text.ToString();
                quantity = textAmount.Text.ToString();
                price = textRate.Text.ToString();
               // ed = textType.Text.ToString();
                dType = textType.Text.ToString();
                company = textCompany.Text.ToString();
                if (dname != "" && bnum != "" && quantity != "" && price != "" )
                {
                    getAmount = float.Parse(quantity);
                    getRate = float.Parse(price);
                    id = GetMedicineId();
                    OleDbCommand cmd = new OleDbCommand("insert into medicine (drug_id,drug_name,batch_no,amount,rate,expire_date,drug_type,company_name) values('"+id+"','" + dname + "','" + bnum + "','" + getAmount + "','" + getRate + "','"+this.dateTimePicker1.Text.ToString()+"','"+dType+"','"+company+"')",conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data has been inserted successfully.");
                }
                else {
                    MessageBox.Show("Please fill all the requirement.");
                    conn.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

        }
    }
}
