using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void newBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddBooks ab = new AddBooks();
            ab.Show();
      
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ViewBooks ab = new ViewBooks();
            ab.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            IssueBooks ab = new IssueBooks();
            ab.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DeleveryBooks ab = new DeleveryBooks();
            ab.Show();

        }
    }
}
