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
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dtp_bookdate_ValueChanged(object sender, EventArgs e)
        {
            dtp_bookdate.CustomFormat = "dd/MM/yyyy";
        }

        private void dtp_bookdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_bookdate.CustomFormat = "";
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            // Basic validation checks
            if (string.IsNullOrWhiteSpace(tb_bookname.Text) ||
                string.IsNullOrWhiteSpace(tb_bookauth.Text) ||
                string.IsNullOrWhiteSpace(tb_bookpub.Text) ||
                dtp_bookdate.Value == null || dtp_bookdate.Value == DateTime.MinValue)
            {
                MessageBox.Show("Please fill in all required fields with valid data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tb_bookprice.Text, out int price))
            {
                MessageBox.Show("Invalid Price", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tb_bookquantity.Text, out int quantity))
            {
                MessageBox.Show("Invalid Quantity", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True");
            conn.Open();

            try
            {
                // SQL command with parameters
                string sql = "INSERT INTO AddBookTB (Book_Name, Book_Author, Book_Publication, Purchase_Date, Book_Price, Book_Quantity) " +
                             "VALUES (@Book_Name, @Book_Author, @Book_Publication, @Purchase_Date, @Book_Price, @Book_Quantity)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Book_Name", tb_bookname.Text);
                    cmd.Parameters.AddWithValue("@Book_Author", tb_bookauth.Text);
                    cmd.Parameters.AddWithValue("@Book_Publication", tb_bookpub.Text);
                    cmd.Parameters.AddWithValue("@Purchase_Date", dtp_bookdate.Value);

                    // Assuming 'price' and 'quantity' are defined and assigned earlier code
                    cmd.Parameters.AddWithValue("@Book_Price", price);
                    cmd.Parameters.AddWithValue("@Book_Quantity", quantity);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }         
        
    }
}
