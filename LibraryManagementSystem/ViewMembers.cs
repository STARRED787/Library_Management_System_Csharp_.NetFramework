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

namespace LibraryManagementSystem
{
    public partial class ViewMembers : Form
    {
        public ViewMembers()
        {
            InitializeComponent();
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            // Check if the search textbox for Member Name is not empty
            if (string.IsNullOrWhiteSpace(tb_memsef.Text))
            {
                MessageBox.Show("Please enter a Member Name to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string memberName = tb_memsef.Text.Trim(); // Trim any leading or trailing spaces

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Search query based on Member_Name
                    string query = "SELECT * FROM AddMembersTB WHERE Member_Name LIKE @MemberName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use LIKE for partial matches
                        cmd.Parameters.AddWithValue("@MemberName", "%" + memberName + "%"); // Wildcards for partial matches
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the data to DataGridView
                        dgv_addmembers.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No records found with the provided Member Name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Validation checks
            if (string.IsNullOrWhiteSpace(tb_memId.Text) ||
                string.IsNullOrWhiteSpace(tb_memname.Text) ||
                string.IsNullOrWhiteSpace(tb_memadd.Text) ||
                string.IsNullOrWhiteSpace(tb_memcan.Text) ||
                cb_memgen.SelectedItem == null ||
                !DateTime.TryParse(dtp_memdob.Text, out DateTime dob) ||
                !DateTime.TryParse(dtp_memstart.Text, out DateTime startDate) ||
                !DateTime.TryParse(dtp_memend.Text, out DateTime endDate))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tb_memId.Text, out int memberId))
            {
                MessageBox.Show("Invalid Member ID. It must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(tb_memcan.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Contact number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(tb_mememail.Text) && !Regex.IsMatch(tb_mememail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure Start Date is before End Date
            if (startDate >= endDate)
            {
                MessageBox.Show("End Date must be after Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Update the existing record
                    string query = "UPDATE AddMembersTB SET Member_Name = @MemberName, Address = @Address, Cantact_Num = @ContactNum, Dob = @Dob, " +
                                   "Gender = @Gender, Email = @Email, Start_Date = @StartDate, End_Date = @EndDate WHERE Member_Id = @MemberId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@MemberId", memberId);
                        cmd.Parameters.AddWithValue("@MemberName", tb_memname.Text);
                        cmd.Parameters.AddWithValue("@Address", tb_memadd.Text);
                        cmd.Parameters.AddWithValue("@ContactNum", tb_memcan.Text);
                        cmd.Parameters.AddWithValue("@Dob", dob);
                        cmd.Parameters.AddWithValue("@Gender", cb_memgen.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Email", tb_mememail.Text);
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Library member updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields(); // Optional: Clear fields after updating
                        }
                        else
                        {
                            MessageBox.Show("No member found with the provided Member ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the member: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to clear all input fields
        private void ClearFields()
        {
            tb_memId.Clear();
            tb_memname.Clear();
            tb_memadd.Clear();
            tb_memcan.Clear();
            cb_memgen.SelectedIndex = -1;
            tb_mememail.Clear();
            dtp_memdob.Value = DateTime.Now;
            dtp_memstart.Value = DateTime.Now;
            dtp_memend.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Validation to ensure Member ID is provided
            if (string.IsNullOrWhiteSpace(tb_memId.Text))
            {
                MessageBox.Show("Please enter a Member ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tb_memId.Text, out int memberId))
            {
                MessageBox.Show("Invalid Member ID. It must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this member?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return; // Exit if the user chooses not to delete
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Delete the record from the database
                    string query = "DELETE FROM AddMembersTB WHERE Member_Id = @MemberId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", memberId);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Library member deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields(); // Optional: Clear fields after deletion
                        }
                        else
                        {
                            MessageBox.Show("No member found with the provided Member ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the member: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_addBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked on a valid row
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_addmembers.Rows[e.RowIndex];

                // Populate fields with data from the selected row
                tb_memId.Text = row.Cells["Member_Id"].Value.ToString();
                tb_memname.Text = row.Cells["Member_Name"].Value.ToString();
                tb_memadd.Text = row.Cells["Address"].Value.ToString();
                tb_memcan.Text = row.Cells["Cantact_Num"].Value.ToString();
                dtp_memdob.Value = Convert.ToDateTime(row.Cells["Dob"].Value);
                cb_memgen.SelectedItem = row.Cells["Gender"].Value.ToString();
                tb_mememail.Text = row.Cells["Email"].Value.ToString();
                dtp_memstart.Value = Convert.ToDateTime(row.Cells["Start_Date"].Value);
                dtp_memend.Value = Convert.ToDateTime(row.Cells["End_Date"].Value);
            }


        }

        private void ViewMembers_Load(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Query to fetch all records from AddMembersTB
                    string query = "SELECT * FROM AddMembersTB";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the data to DataGridView
                        dgv_addmembers.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                    {
                        conn.Open();

                        // Query to fetch all records from AddMembersTB
                        string query = "SELECT * FROM AddMembersTB";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind the data to DataGridView
                            dgv_addmembers.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while refreshing the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
    
    
    
    

