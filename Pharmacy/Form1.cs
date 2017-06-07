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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textPassword.PasswordChar = '*';
        }
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from login", conn);
                string inputUser = textUser.Text.ToString();
                string inputPass = textPassword.Text.ToString();
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                int count = 0;
                int test = 0;
                count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string dbUser, dbPass;
                    dbUser = dt.Rows[i]["USER_NAME"].ToString();
                    dbPass = dt.Rows[i]["PASSWORD"].ToString();
                    if (dbUser == inputUser && dbPass == inputPass)
                    {
                        test = test + 1;
                    }
                }
                if (test == 1)
                {
                    conn.Close();
                    this.Hide();
                    MainForm fm = new MainForm();
                    fm.Show();

                }
                else if (test > 1)
                {
                    MessageBox.Show("Duplicate user name or password");
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please check your password!!!");
                    conn.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
