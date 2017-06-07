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
using System.Data.OracleClient;

namespace Pharmacy
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        
        //OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");
       // OracleConnection conn = new OracleConnection("Provider=MSDAORA;Data Source=orc;User ID=pharmacy;Password=pharmacy;Unicode=True");
        OracleConnection conn=new OracleConnection("Data Source=orc; User ID=pharmacy; Password=pharmacy");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string uname,pass,conpass;
                uname=textCUserName.Text.ToString();
                pass=textCPassword.Text.ToString();
                conpass=textCConfirmPass.Text.ToString();
                if(pass==conpass)  
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert_login";
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter param1 = cmd.Parameters.Add("v_user_name",OracleType.VarChar);
                    param1.Direction = ParameterDirection.Input;
                    param1.Value = textCUserName.Text.ToString();

                    OracleParameter param2 = cmd.Parameters.Add("v_pass",OracleType.VarChar);
                    param2.Direction = ParameterDirection.Input;
                    param2.Value = pass;

                   // OracleParameter f_param = cmd.Parameters.Add("v_user_id",OracleType.Number);
                    //f_param.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    conn.Close();

                   /* OleDbCommand cmd = new OleDbCommand("execute insert_login('"+uname+"','"+pass+"')", conn);
                    cmd.CommandText = "insert_login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conn.Close();*/
                    MessageBox.Show("Data inserted successfully.");
                }
                else{
                    MessageBox.Show("Your password does not match!! Try again.");
                    conn.Close();
                }
            }
            catch (Exception eeception)
            {
                MessageBox.Show(eeception.Message);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
