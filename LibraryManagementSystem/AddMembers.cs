using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class AddMembers : Form
    {
        public AddMembers()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bt_save_Click(object sender, EventArgs e)
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

                    string query = "INSERT INTO AddMembersTB (Member_Id, Member_Name, Address, Cantact_Num, Dob, Gender, Email, Start_Date, End_Date) " +
                                   "VALUES (@MemberId, @MemberName, @Address, @ContactNum, @Dob, @Gender, @Email, @StartDate, @EndDate)";

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
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Library member added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields(); // Optional: Clear fields after adding
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the member: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
