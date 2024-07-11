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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class Loging : Form
    {
        public Loging()
        {
            InitializeComponent();
        }

        private void tb_user_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = " data source = DESKTOP-LDJQNC1\\SQLEXPRESS; database = LibManagementSystem; integrated security=true ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = " select * from LogingTb where username='" + tb_user.Text + "' and password ='" + tb_pass.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("Your Loging Successfull", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }

            else
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_pass_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tb_user_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void bt_login_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Loging_Load(object sender, EventArgs e)
        {

        }

        private void Loging_MouseEnter(object sender, EventArgs e)
        {

        }

        private void tb_user_MouseEnter(object sender, EventArgs e)
        {
            if (tb_user.Text == "Username")
            {
                tb_user.Clear();
            }
        }

        private void tb_pass_MouseEnter(object sender, EventArgs e)
        {
            if (tb_pass.Text == "Password")
            {
                tb_pass.Clear();
                tb_pass.PasswordChar = '*';
            }
        }
    }
}
