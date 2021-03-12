using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swhirl_App
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void pureDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void pureDriveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_Space objNew_Space = new New_Space();
            
            objNew_Space.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Space objNew_Space = new New_Space();

            objNew_Space.Show();
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            Phonebook objPhonebook  = new Phonebook();

            objPhonebook.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUser objPhonebook = new AddUser();
            objPhonebook.Show();
        }
    }
}
