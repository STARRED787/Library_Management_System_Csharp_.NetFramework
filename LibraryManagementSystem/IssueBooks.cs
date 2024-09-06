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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Loadcb_bookname()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // SQL query to retrieve the data for ComboBox
                    string query = "SELECT Book_Name FROM AddBooksTB";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Add a default "Select" item at the top of the ComboBox
                        DataRow row = dt.NewRow();
                        row["Book_Name"] = "Select"; // Default text
                        dt.Rows.InsertAt(row, 0); // Insert at the first position

                        // Bind data to ComboBox
                        cb_isbookname.DataSource = dt;
                        cb_isbookname.DisplayMember = "Book_Name";
                        cb_isbookname.ValueMember = "Book_Name";

                        // Set default selected index to 0 (the "Select" item)
                        cb_isbookname.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            Loadcb_bookname();

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // SQL query to retrieve the data
                    string query = "SELECT * FROM IssueBooksTB";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the data to DataGridView
                        dgv_addmembers.DataSource = dt;

                        // Optionally auto-resize columns
                        dgv_addmembers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if the search textbox for Member Name is not empty
            if (string.IsNullOrWhiteSpace(tb_issuenams.Text))
            {
                MessageBox.Show("Please enter a Member Name to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string memberName = tb_issuenams.Text.Trim(); // Trim any leading or trailing spaces

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

                        // Check if any records found
                        if (dt.Rows.Count > 0)
                        {
                            // Display the first record in the text boxes
                            DataRow row = dt.Rows[0];

                            tb_ismemId.Text = row["Member_Id"].ToString();      // Display Member_Id
                            tb_ismemname.Text = row["Member_Name"].ToString();  // Display Member_Name
                            tb_ismemadd.Text = row["Address"].ToString();       // Display Address
                            tb_ismemcan.Text = row["Cantact_Num"].ToString();   // Display Cantact_Num
                            tb_ismememail.Text = row["Email"].ToString();

                        }
                        else
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

        private void bt_issuebook_Click(object sender, EventArgs e)
        {
            // Validation checks
            if (string.IsNullOrWhiteSpace(tb_ismemId.Text) ||
                string.IsNullOrWhiteSpace(tb_ismemname.Text) ||
                string.IsNullOrWhiteSpace(tb_ismemadd.Text) ||
                string.IsNullOrWhiteSpace(tb_ismemcan.Text) ||
                cb_isbookname.SelectedItem == null ||
                !DateTime.TryParse(dtp_isdate.Text, out DateTime issueDate) ||
                !DateTime.TryParse(dtp_redate.Text, out DateTime returnDate)) // Assuming you have a DateTimePicker for Return Date
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tb_ismemId.Text, out int memberId))
            {
                MessageBox.Show("Invalid Member ID. It must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(tb_ismemcan.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Contact number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(tb_ismememail.Text) && !Regex.IsMatch(tb_ismememail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "INSERT INTO IssueBooksTB (Member_Id, Member_Name, Address, Cantact_Num, Email, Book_Name, Issue_Date, Return_Date) " +
                                   "VALUES (@MemberId, @MemberName, @Address, @ContactNum, @Email, @BookName, @IssueDate, @ReturnDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@MemberId", memberId);
                        cmd.Parameters.AddWithValue("@MemberName", tb_ismemname.Text);
                        cmd.Parameters.AddWithValue("@Address", tb_ismemadd.Text);
                        cmd.Parameters.AddWithValue("@ContactNum", tb_ismemcan.Text);
                        cmd.Parameters.AddWithValue("@Email", tb_ismememail.Text);
                        cmd.Parameters.AddWithValue("@BookName", cb_isbookname.SelectedValue); // Get selected book from ComboBox
                        cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                        cmd.Parameters.AddWithValue("@ReturnDate", returnDate); // New parameter for Return Date

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Book issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields(); // Optional: Clear fields after adding
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while issuing the book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Optional: Method to clear input fields after saving
        private void ClearFields()
        {
            tb_ismemId.Clear();
            tb_ismemname.Clear();
            tb_ismemadd.Clear();
            tb_ismemcan.Clear();
            tb_ismememail.Clear();
            cb_isbookname.SelectedIndex = -1;
            dtp_isdate.Value = DateTime.Now;
        }

        private void dgv_addmembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_addmembers.Rows[e.RowIndex];

                // Populate text boxes with selected row data
                tb_ismemId.Text = row.Cells["Member_Id"].Value.ToString();
                tb_ismemname.Text = row.Cells["Member_Name"].Value.ToString();
                tb_ismemadd.Text = row.Cells["Address"].Value.ToString();
                tb_ismemcan.Text = row.Cells["Cantact_Num"].Value.ToString();
                tb_ismememail.Text = row.Cells["Email"].Value.ToString();

                // Populate ComboBox with Book_Name from the selected row
                string bookName = row.Cells["Book_Name"].Value.ToString();

                // Ensure ComboBox has been populated with data
                if (cb_isbookname.DataSource != null)
                {
                    // Try to set the selected value
                    cb_isbookname.SelectedItem = cb_isbookname.Items
                        .Cast<DataRowView>()
                        .FirstOrDefault(item => item["Book_Name"].ToString() == bookName);

                    // If the item is not found, you might want to handle it
                    if (cb_isbookname.SelectedItem == null)
                    {
                        cb_isbookname.SelectedIndex = 0; // Default to the first item (e.g., "Select")
                    }
                }
                else
                {
                    // Handle case where DataSource is null (perhaps reload data or handle gracefully)
                    cb_isbookname.SelectedIndex = 0; // Default to the first item (e.g., "Select")
                }

                // Populate the DateTimePicker with the Issue_Date from the selected row
                if (DateTime.TryParse(row.Cells["Issue_Date"].Value.ToString(), out DateTime issueDate))
                {
                    dtp_isdate.Value = issueDate;
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // SQL query to retrieve the data
                    string query = "SELECT * FROM IssueBooksTB";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the data to DataGridView
                        dgv_addmembers.DataSource = dt;

                        // Optionally auto-resize columns
                        dgv_addmembers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            // Validation checks
            if (cb_isbookname.SelectedItem == null)
            {
                MessageBox.Show("Please select a book name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "UPDATE IssueBooksTB SET " +
                                   "Book_Name = @BookName " +
                                   "WHERE Member_Id = @MemberId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@BookName", cb_isbookname.SelectedValue); // Get selected book from ComboBox using SelectedValue
                        cmd.Parameters.AddWithValue("@MemberId", tb_ismemId.Text); // Assuming you have the Member ID in a TextBox

                        // Execute the update query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields(); // Optional: Clear fields after updating
                        }
                        else
                        {
                            MessageBox.Show("No record found with the provided Member ID.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
