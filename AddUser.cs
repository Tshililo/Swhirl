using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swhirl_App
{
    public partial class AddUser : Form
    {
  
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please Enter Email");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please Enter Password");
                return;
            }

            if (string.IsNullOrEmpty(txtCornfirmPass.Text))
            {
                MessageBox.Show("Please Enter Confirm Password");
                return;
            }

            if (txtPassword.Text != txtCornfirmPass.Text)
            {
                MessageBox.Show("Password do not match!");
                return;
            }

            try
            {
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\TrialDB.mdf; Integrated Security = True; Connect Timeout = 30";

                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into TrialLoginDB(loginID,Username,Passcode) values('" +
                Guid.NewGuid() + "','" + txtEmail.Text + "','" + txtCornfirmPass.Text + "');";

                SqlConnection MyConn2 = new SqlConnection(connectionString);
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                SqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  

                MyConn2.Close();

                this.Hide();
                frmLogin objPhonebook = new frmLogin();
                objPhonebook.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
