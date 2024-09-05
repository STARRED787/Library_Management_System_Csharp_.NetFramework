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

            if (!int.TryParse(tb_bookId.Text, out int Id))
            {
                MessageBox.Show("Invalid Book Id. Please enter a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tb_bookprice.Text, out decimal price))
            {
                MessageBox.Show("Invalid Price. Please enter a valid number for Book Price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tb_bookquantity.Text, out int quantity))
            {
                MessageBox.Show("Invalid Quantity. Please enter a valid integer for Book Quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Establish SQL connection
            string connectionString = @"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString); // Declare SqlConnection object outside try block

            try
            {
                conn.Open(); // Open connection here

                // SQL command with parameters
                string sql = "INSERT INTO AddBooksTB (Book_Id, Book_Name, Book_Author, Book_Publication, Purchase_Date, Book_Price, Book_Quantity) " +
                             "VALUES (@Book_Id, @Book_Name, @Book_Author, @Book_Publication, @Purchase_Date, @Book_Price, @Book_Quantity)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Book_Id", Id);
                    cmd.Parameters.AddWithValue("@Book_Name", tb_bookname.Text);
                    cmd.Parameters.AddWithValue("@Book_Author", tb_bookauth.Text);
                    cmd.Parameters.AddWithValue("@Book_Publication", tb_bookpub.Text);
                    cmd.Parameters.AddWithValue("@Purchase_Date", dtp_bookdate.Value);
                    cmd.Parameters.AddWithValue("@Book_Price", price);
                    cmd.Parameters.AddWithValue("@Book_Quantity", quantity);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Close connection in finally block to ensure it's always closed
            }

        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            tb_bookId.Clear();
            tb_bookname.Clear();
            tb_bookauth.Clear();
            tb_bookpub.Clear();
            dtp_bookdate.Value = DateTime.Now;
            tb_bookprice.Clear();
            tb_bookquantity.Clear();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_bookId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tb_bookquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_bookprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_bookpub_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tb_bookname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tb_bookauth_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }
    }
}
        

