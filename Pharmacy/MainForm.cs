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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Pharmacy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetBillNo();
            FillCombo();
            textDiscount.Text = "0";
        }
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");

        int bill;
        void SetBillNo()
        {
            conn.Open();
            OleDbCommand billCmd = new OleDbCommand("select * from sale_info order by bill_no asc",conn);
            conn.Close();
            DataTable BDT = new DataTable();
            OleDbDataAdapter BDTA = new OleDbDataAdapter(billCmd.CommandText,conn);
            BDTA.Fill(BDT);
            int BillCount = BDT.Rows.Count;
            if (BillCount == 0)
            {
                string setBill="1";
                textBillNum.Text = setBill;
                bill = Convert.ToInt32(setBill);
            }
            else {
                string getBill = BDT.Rows[BillCount-1]["bill_no"].ToString();
                bill = int.Parse(getBill);
                bill = bill + 1;
                string setBill = Convert.ToString(bill);
                textBillNum.Text = setBill;
            }
        }

        void FillCombo()
        {
            textSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();


            try
            {
                conn.Open();
                int count;
                OleDbCommand cmd = new OleDbCommand("select drug_name from medicine",conn);
                conn.Close();
                DataTable dt = new DataTable();
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd.CommandText,conn);
                oda.Fill(dt);
                count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string getName = dt.Rows[i]["drug_name"].ToString();
                    coll.Add(getName);
                }
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
                conn.Close();
            }

            textSearch.AutoCompleteCustomSource = coll;
        }

        // We need this function when we delete a drug from dataGridview bcoz after deleting we need to
        // update the the informations of a customer.
        void FillTable()
        {
            try
            {
                conn.Open();
               // OleDbDataAdapter oda = new OleDbDataAdapter("select * from sale_info where bill_no='" + textBillNum.Text.ToString() + "'", conn);
                OleDbDataAdapter oda = new OleDbDataAdapter("select drug_name,batch_no,drug_type,company_name,expire_date,quantity,mrp,total_amount from sale_info where bill_no='" + textBillNum.Text.ToString() + "'", conn);
                conn.Close();
                DataTable dtt = new DataTable();
                oda.Fill(dtt);
                dataGridViewSale.DataSource = dtt;
                int count = dtt.Rows.Count;
                float total_taka, sum = 0;
                for (int i = 0; i < count; i++)
                {
                    string totalAmount = dtt.Rows[i]["total_amount"].ToString();
                    total_taka = float.Parse(totalAmount);
                    sum = sum + total_taka;
                }
                textTotalAmount.Text = Convert.ToString(sum);
                textFinalAmount.Text = Convert.ToString(sum);
            }
            catch (Exception excep) {
                MessageBox.Show(excep.Message);
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItem adf = new AddItem();
            adf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewStock dsf = new ViewStock();
            dsf.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmda = new OleDbCommand("select * from medicine where drug_name='" + textSearch.Text.ToString() + "'", conn);
                DataTable dta = new DataTable();
                OleDbDataAdapter odat = new OleDbDataAdapter(cmda.CommandText, conn);
                conn.Close();
                odat.Fill(dta);
                int count = dta.Rows.Count;
                int i;
                for (i = 0; i < count; i++)
                {
                    string getBatch = dta.Rows[i]["batch_no"].ToString();
                    string getAmount = dta.Rows[i]["amount"].ToString();
                    string getRate = dta.Rows[i]["rate"].ToString();
                    string getExDate = dta.Rows[i]["expire_date"].ToString();
                    string drgType = dta.Rows[i]["drug_type"].ToString();
                    string company = dta.Rows[i]["company_name"].ToString();

                    textAvailable.Text = getAmount;
                    textExDate.Text = getExDate;
                    textBatch.Text = getBatch;
                    textMrp.Text = getRate;
                    textDrugType.Text = drgType;
                    textCompanyName.Text = company;
                }

                conn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                conn.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //...................... Functions of ADD Button running here..................................
        //.............................................................................................
        private void button3_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                float getRate, getTotal, getAmount,available,updateAmount;
                int getBill = int.Parse(textBillNum.Text);
                available = int.Parse(textAvailable.Text);
                getRate = float.Parse(textMrp.Text);
                getAmount = float.Parse(textQty.Text);
                updateAmount = available - getAmount;
                getTotal = getRate * getAmount;
                textTotal.Text = Convert.ToString(getTotal);

                // Checking whether the medicine is Available or not...................
                string Qty;
                int getqty=0;
                OleDbDataAdapter chkAdtr = new OleDbDataAdapter("select * from medicine where drug_name='"+textSearch.Text.ToString()+"'",conn);
                DataTable chkTbl = new DataTable();
                chkAdtr.Fill(chkTbl);
                int chkCount = chkTbl.Rows.Count;
                for (int i = 0; i < chkCount; i++)
                {
                    Qty=chkTbl.Rows[i]["amount"].ToString();
                    getqty = int.Parse(Qty);
                }

                if (getqty >= int.Parse(textQty.Text.ToString()))
                {
                    OleDbCommand insrtcmd = new OleDbCommand("insert into sale_info values('" + bill + "','" + textSearch.Text.ToString() + "','" + textBatch.Text.ToString() + "','" + textDrugType.Text.ToString() + "','" + textCompanyName.Text.ToString() + "','" + textExDate.Text.ToString() + "','" + getAmount + "','" + getRate + "','" + getTotal + "','" + this.dateTimePicker1.Text.ToString() + "')", conn);
                    insrtcmd.ExecuteNonQuery();
                    OleDbCommand updatecmd = new OleDbCommand("update medicine set amount='"+updateAmount+"' where drug_name='"+textSearch.Text.ToString()+"'",conn);
                    updatecmd.ExecuteNonQuery();
                    textAvailable.Text = Convert.ToString(updateAmount);
                    // OleDbDataAdapter oda = new OleDbDataAdapter("select * from sale_info where bill_no='"+getBill+"'",conn);
                    OleDbDataAdapter oda = new OleDbDataAdapter("select drug_name,batch_no,drug_type,company_name,expire_date,quantity,mrp,total_amount from sale_info where bill_no='" + getBill + "'", conn);
                    conn.Close();
                    DataTable dtt = new DataTable();
                    oda.Fill(dtt);
                    dataGridViewSale.DataSource = dtt;

                    // Calculating total Bill..........
                    int count = dtt.Rows.Count;
                    float total_taka, sum = 0;
                    for (int i = 0; i < count; i++)
                    {
                        string totalAmount = dtt.Rows[i]["total_amount"].ToString();
                        total_taka = float.Parse(totalAmount);
                        sum = sum + total_taka;
                    }
                    textTotalAmount.Text = Convert.ToString(sum);
                    textFinalAmount.Text = Convert.ToString(sum);
                }
                else {
                    MessageBox.Show("Sorry! This medicine is not available.");
                    conn.Close();
                }

            }
            catch(Exception exc){
                MessageBox.Show(exc.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewBill vb = new ViewBill();
            vb.Show();
        }

        // Calculating Discount.........................................

        private void button5_Click(object sender, EventArgs e)
        {
            float calDiscount, finalResult;
            float diccount;
            string getDiscount = textDiscount.Text.ToString();
            string getSum = textTotalAmount.Text.ToString();
            float sum = float.Parse(getSum);
            diccount = float.Parse(getDiscount);
            calDiscount = (diccount * sum) / 100;
            finalResult = sum - calDiscount;
            textFinalAmount.Text = Convert.ToString(finalResult);
        }

        // Creating PDF file here............................................

        private void button7_Click(object sender, EventArgs e)
        {
            try { 
                conn.Open();
                OleDbCommand insrtpayment = new OleDbCommand("insert into payment_bill values('"+textBillNum.Text.ToString()+"','"+textTotalAmount.Text.ToString()+"','"+textDiscount.Text.ToString()+"','"+textFinalAmount.Text.ToString()+"','"+this.dateTimePicker1.Text.ToString()+"')",conn);
                insrtpayment.ExecuteNonQuery();
               // MessageBox.Show("Inserted");
                conn.Close();

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter pwri = PdfWriter.GetInstance(doc, new FileStream(textBillNum.Text.ToString() + ".pdf", FileMode.Create));
                doc.Open();

                Paragraph para = new Paragraph("                                           Welcome to Janata Pharmacy\n"
                    + "                                          Ambottola Sadar, Jessore 1215\n                                           Receipt of the Customer"
                    + "\nBill No." + textBillNum.Text.ToString()
                    + "\nTotal Amount: " + textTotalAmount.Text.ToString() + "\nDiscount: " + textDiscount.Text.ToString() + " %"
                    + "\nPayable Amount: " + textFinalAmount.Text.ToString() + "\nDate of Sale: " + this.dateTimePicker1.Text.ToString() + "\n\n");
                doc.Add(para);

                // Adding dataGridView to the PDF

                PdfPTable pdfTable = new PdfPTable(dataGridViewSale.Columns.Count);
                for (int i = 0; i < dataGridViewSale.Columns.Count; i++)
                {
                    pdfTable.AddCell(new Phrase(dataGridViewSale.Columns[i].HeaderText));
                }
                pdfTable.HeaderRows = 1;
                for (int j = 0; j < dataGridViewSale.Rows.Count; j++)
                {
                    for (int k = 0; k < dataGridViewSale.Columns.Count; k++)
                    {
                        if (dataGridViewSale[k, j].Value != null)
                        {
                            pdfTable.AddCell(new Phrase(dataGridViewSale[k, j].Value.ToString()));
                        }
                    }
                }
                doc.Add(pdfTable);

                doc.Close();
                this.Hide();
                MainForm mf = new MainForm();
                mf.Show();
            }
            catch(Exception exception){
                MessageBox.Show(exception.Message);
            }
            
        }

        // To delete value from dataGridView, getting deug name into the text box.........
        private void dataGridViewSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row=this.dataGridViewSale.Rows[e.RowIndex];
                textDelete.Text = row.Cells["drug_name"].Value.ToString();
            }
        }

        // Deleting Value from dataGridview..................
        private void button6_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                OleDbCommand dltcmd = new OleDbCommand("delete from sale_info where drug_name='"+textDelete.Text.ToString()+"' and bill_no='"+textBillNum.Text.ToString()+"'",conn);
                dltcmd.ExecuteNonQuery();
                conn.Close();
                FillTable();
            }
            catch(Exception excp){
                MessageBox.Show(excp.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DaySell dfm = new DaySell();
            dfm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Modify mfm = new Modify();
            mfm.Show();
        }
    }
}
