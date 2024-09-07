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

namespace LibraryManagementSystem
{
    public partial class DeleveryBooks : Form
    {
        public DeleveryBooks()
        {
            InitializeComponent();
        }

        private void DeleveryBooks_Load(object sender, EventArgs e)
        {
                        try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Define the query to fetch all records from DeleveryBooksTB
                    string query = "SELECT * FROM DeleveryBooksTB";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        dgv_deinfo.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Loadcb_bookname()
        {
            

        }

        private void bt_issuebook_Click(object sender, EventArgs e)
        {
            // Check if the search textbox for Member Name is not empty
            if (string.IsNullOrWhiteSpace(tb_denams.Text))
            {
                MessageBox.Show("Please enter a Member Name to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string memberName = tb_denams.Text.Trim(); // Trim any leading or trailing spaces

            // Use the delivery date from the DateTimePicker
            DateTime predefinedDeliveryDate = dtp_dedate.Value; // Get the selected delivery date from DateTimePicker

            // Calculate late days and fees
            int lateDays = (dtp_redate.Value < predefinedDeliveryDate) ? ( predefinedDeliveryDate - dtp_redate.Value).Days : 0;
            int lateFee = lateDays * 5; // Assuming a late fee of 5 units per day

            // Determine payment method based on selected radio button
            string paymentMethod = "";
            if (rb_no.Checked) paymentMethod = "No Pay";
            else if (rb_pai.Checked) paymentMethod = "Pay";
            else if (rb_unpai.Checked) paymentMethod = "Unpaid";
            else
            {
                MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Prepare the SQL query
                    string query = "INSERT INTO DeleveryBooksTB (Member_Id, Member_Name, Address, Cantact_Num, Email, Book_Name, Issue_Date, Return_Date, Delevery_Date, Late_Days, Late_Fees, Payements) " +
                                   "VALUES (@MemberId, @MemberName, @Address, @CantactNum, @Email, @BookName, @IssueDate, @ReturnDate, @DeleveryDate, @LateDays, @LateFees, @Payements)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@MemberId", tb_dememId.Text);
                        cmd.Parameters.AddWithValue("@MemberName", tb_dememname.Text);
                        cmd.Parameters.AddWithValue("@Address", tb_dememadd.Text);
                        cmd.Parameters.AddWithValue("@CantactNum", tb_dememcan.Text);
                        cmd.Parameters.AddWithValue("@Email", tb_demememail.Text);
                        cmd.Parameters.AddWithValue("@BookName",tb_bookname.Text); // Assuming you have this value from somewhere
                        cmd.Parameters.AddWithValue("@IssueDate", dtp_isdate.Value);
                        cmd.Parameters.AddWithValue("@ReturnDate", dtp_redate.Value);
                        cmd.Parameters.AddWithValue("@DeleveryDate", dtp_dedate.Value);
                        cmd.Parameters.AddWithValue("@LateDays", lateDays);
                        cmd.Parameters.AddWithValue("@LateFees", lateFee);
                        cmd.Parameters.AddWithValue("@Payements", paymentMethod);

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if the search textbox for Member Name is not empty
            if (string.IsNullOrWhiteSpace(tb_denams.Text))
            {
                MessageBox.Show("Please enter a Member Name to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string memberName = tb_denams.Text.Trim(); // Trim any leading or trailing spaces

            // Use the delivery date from the DateTimePicker
            DateTime predefinedDeliveryDate = dtp_dedate.Value; // Get the selected delivery date from DateTimePicker

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Search query based on Member_Name
                    string query = "SELECT * FROM IssueBooksTB WHERE Member_Name LIKE @MemberName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use LIKE for partial matches
                        cmd.Parameters.AddWithValue("@MemberName", "%" + memberName + "%"); // Wildcards for partial matches
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Display the first record in the text boxes
                            DataRow row = dt.Rows[0];

                            tb_dememId.Text = row["Member_Id"].ToString();      // Display Member_Id
                            tb_dememname.Text = row["Member_Name"].ToString();  // Display Member_Name
                            tb_dememadd.Text = row["Address"].ToString();       // Display Address
                            tb_dememcan.Text = row["Cantact_Num"].ToString();   // Display Cantact_Num
                            tb_demememail.Text = row["Email"].ToString();
                            tb_bookname.Text = row["Book_Name"].ToString();

                            // Convert dates to appropriate format and set to DateTimePickers
                            if (DateTime.TryParse(row["Issue_Date"].ToString(), out DateTime issueDate))
                            {
                                dtp_isdate.Value = issueDate;
                            }
                            if (DateTime.TryParse(row["Return_Date"].ToString(), out DateTime returnDate))
                            {
                                dtp_redate.Value = returnDate;
                            }

                            // Calculate late days based on delivery date from DateTimePicker
                            int lateDays = (returnDate < predefinedDeliveryDate) ? ( predefinedDeliveryDate - returnDate).Days : 0;

                            // Display late days and calculate late fee
                            tb_deltdays.Text = lateDays.ToString();
                            int lateFee = lateDays * 5; // Assuming a late fee of 5 units per day
                            tb_ltfees.Text = ("Rs.")+lateFee.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LDJQNC1\SQLEXPRESS;Initial Catalog=LibManagementSystem;Integrated Security=True"))
                {
                    conn.Open();

                    // Define the query to fetch all records from DeleveryBooksTB
                    string query = "SELECT * FROM DeleveryBooksTB";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        dgv_deinfo.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_deinfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear text boxes
            tb_dememId.Clear();
            tb_dememname.Clear();
            tb_dememadd.Clear();
            tb_dememcan.Clear();
            tb_demememail.Clear();
            tb_ltfees.Clear();
            tb_deltdays.Clear();
            tb_dememname.Text = ""; // Assuming you have a ComboBox or TextBox for Book_Name

            // Reset DateTimePickers to default value (usually the current date)
            dtp_isdate.Value = DateTime.Now;
            dtp_redate.Value = DateTime.Now;
            dtp_dedate.Value = DateTime.Now;

            // Uncheck all radio buttons
            rb_no.Checked = false;
            rb_pai.Checked = false;
            rb_unpai.Checked = false;

            // Optionally, you can reset any other controls or perform additional actions
            MessageBox.Show("Form cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}