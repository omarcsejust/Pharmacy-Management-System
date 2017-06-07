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
    public partial class Modify : Form
    {
        public Modify()
        {
            InitializeComponent();
            FillCombo();
            textMaddQuantity.Text = "0";
        }
       
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");
        void FillCombo()
        {
            textMmedicine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textMmedicine.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            try
            {
                conn.Open();
                int count;
                OleDbCommand cmd = new OleDbCommand("select drug_name from medicine", conn);
                conn.Close();
                DataTable dt = new DataTable();
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd.CommandText, conn);
                oda.Fill(dt);
                count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string getName = dt.Rows[i]["drug_name"].ToString();
                    coll.Add(getName);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                conn.Close();
            }

            textMmedicine.AutoCompleteCustomSource = coll;
        }

        private void textMmedicine_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmda = new OleDbCommand("select * from medicine where drug_name='" + textMmedicine.Text.ToString() + "'", conn);
                DataTable dta = new DataTable();
                OleDbDataAdapter odat = new OleDbDataAdapter(cmda.CommandText, conn);
                conn.Close();
                odat.Fill(dta);
                int count = dta.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string getBatch = dta.Rows[i]["batch_no"].ToString();
                    string getAmount = dta.Rows[i]["amount"].ToString();
                    string getRate = dta.Rows[i]["rate"].ToString();
                    string getExDate = dta.Rows[i]["expire_date"].ToString();
                    string drgType = dta.Rows[i]["drug_type"].ToString();
                    string company = dta.Rows[i]["company_name"].ToString();

                    textMavailable.Text = getAmount;
                    textMexpire.Text = getExDate;
                    textMbatch.Text = getBatch;
                    textMmrp.Text = getRate;
                    textMdrugType.Text = drgType;
                    textMcompany.Text = company;

                }
                conn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            int updateQuantity;
            string existingQuantity = textMavailable.Text.ToString();
            string addQuantity = textMaddQuantity.Text.ToString();
            updateQuantity = int.Parse(existingQuantity) + int.Parse(addQuantity);
            float setMRP = float.Parse(textMmrp.Text.ToString());
            try {
                OleDbCommand updateCommand = new OleDbCommand("update medicine set amount='"+updateQuantity+"',drug_type='"+textMdrugType.Text.ToString()+"',expire_date='"+this.dateTimePicker1.Text.ToString()+"',batch_no='"+textMbatch.Text.ToString()+"',company_name='"+textMcompany.Text.ToString()+"',rate='"+setMRP+"' where drug_name='"+textMmedicine.Text.ToString()+"' ",conn);
                updateCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data has been updated successfully.");
            }
            catch(Exception exception){
                MessageBox.Show(exception.Message);
                conn.Close();
            }
        }
    }
}
