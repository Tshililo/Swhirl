using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swhirl_App
{
    public partial class Phonebook : Form
    {
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\HOMEDESK\DESKTOP\SWHIRL APPERATING SYSTEM\SWHIRL APP 1\DB\TRIALDB.MDF;Integrated Security=True;Connect Timeout=30");
        int PhoneBookID = 0;
        public Phonebook()
        {
            InitializeComponent();
        }

        private void Phonebook_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "" && txtContact.Text.Trim() != "")
            {
                Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = reg.Match(txtEmail.Text.Trim());
                if (match.Success)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ContactAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@PhoneBookID", PhoneBookID);
                        sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Added Successfully");
                        Clear();
                        GridFill();
                    }
                }
                else
                    MessageBox.Show("Email Address is not Valid");
            }
            else
                MessageBox.Show("Please Fill All Mandatory Fields.");
        }

        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtEmail.Text = txtAddress.Text = txtSearch.Text = "";
            PhoneBookID = 0;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;

        }

       
        void GridFill()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewAll", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dgvPhoneBook.DataSource = dtbl;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GridFill();
            btnDelete.Enabled = false;
        }

        private void dgvPhoneBook_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPhoneBook.CurrentRow.Index != -1)
            {
                txtFirstName.Text = dgvPhoneBook.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = dgvPhoneBook.CurrentRow.Cells[2].Value.ToString();
                txtContact.Text = dgvPhoneBook.CurrentRow.Cells[3].Value.ToString();
                txtEmail.Text = dgvPhoneBook.CurrentRow.Cells[4].Value.ToString();
                txtAddress.Text = dgvPhoneBook.CurrentRow.Cells[5].Value.ToString();
                PhoneBookID = Convert.ToInt32(dgvPhoneBook.CurrentRow.Cells[0].Value.ToString());

                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }






        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ContactSearchByValue", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@SearchValue", txtSearch.Text.Trim());
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dgvPhoneBook.DataSource = dtbl;
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("ContactDeleteByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PhoneBookID", PhoneBookID);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Contact has been Deleted");
                Clear();
                GridFill();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnspace_Click(object sender, EventArgs e)
        {
            New_Space objNew_Space = new New_Space();

            objNew_Space.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            Phonebook objPhonebook = new Phonebook();

            objPhonebook.Show();
        }
    }
}
