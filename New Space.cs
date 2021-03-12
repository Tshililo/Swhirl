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
    public partial class New_Space : Form
    {
        public New_Space()
        {
            InitializeComponent();
        }

        private void New_Space_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnspace_Click(object sender, EventArgs e)
        {
            New_Space objNew_Space = new New_Space();

            objNew_Space.Show();
        }

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Space objNew_Space = new New_Space();

            objNew_Space.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
