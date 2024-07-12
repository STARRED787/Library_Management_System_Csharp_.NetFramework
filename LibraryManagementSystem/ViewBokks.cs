using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class ViewBokks : Form
    {
        public ViewBokks()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewBokks_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True";
            string sql = "SELECT Book_Id, Book_Name, Book_Author, Book_Publication, Purchase_Date, Book_Price, Book_Quantity FROM AddBooksTB";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_addBooks.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void dgv_addBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgv_addBooks.Rows[e.RowIndex];

                // Ensure the column names match exactly with those in the DataTable
                tb_bookId.Text = row.Cells["Book_Id"].Value.ToString();
                tb_bookname.Text = row.Cells["Book_Name"].Value.ToString();
                tb_bookauth.Text = row.Cells["Book_Author"].Value.ToString();
                tb_bookpub.Text = row.Cells["Book_Publication"].Value.ToString();
                dtp_bookdate.Value = Convert.ToDateTime(row.Cells["Purchase_Date"].Value);
                tb_bookprice.Text = row.Cells["Book_Price"].Value.ToString();
                tb_bookquantity.Text = row.Cells["Book_Quantity"].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // SQL command with parameters
                    SqlCommand cmd = new SqlCommand("UPDATE AddBooksTB SET Book_Id = @Book_Id, Book_Name = @Book_Name, " +
                                                     "Book_Author = @Book_Author, Book_Publication = @Book_Publication, " +
                                                     "Purchase_Date = @Purchase_Date, Book_Price = @Book_Price, " +
                                                     "Book_Quantity = @Book_Quantity WHERE Book_Id = @Original_Book_Id", conn);

                    // Parameters
                    cmd.Parameters.AddWithValue("@Book_Id", int.Parse(tb_bookId.Text)); // Assuming BookId is integer
                    cmd.Parameters.AddWithValue("@Book_Name", tb_bookname.Text);
                    cmd.Parameters.AddWithValue("@Book_Author", tb_bookauth.Text);
                    cmd.Parameters.AddWithValue("@Book_Publication", tb_bookpub.Text);
                    cmd.Parameters.AddWithValue("@Purchase_Date", dtp_bookdate.Value);
                    cmd.Parameters.AddWithValue("@Book_Price", decimal.Parse(tb_bookprice.Text)); // Assuming BookPrice is decimal
                    cmd.Parameters.AddWithValue("@Book_Quantity", int.Parse(tb_bookquantity.Text)); // Assuming BookQuantity is integer

                    // Original BookId to identify the record to update
                    cmd.Parameters.AddWithValue("@Original_Book_Id", int.Parse(tb_bookId.Text));

                    // Execute the update query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No record found with the given Book Id.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Input format error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True");
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM AddBooksTB WHERE Book_Id = @Book_Id", conn);

                cmd.Parameters.AddWithValue("@Book_Id", int.Parse(tb_bookId.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No record found with the given BookId", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
    

