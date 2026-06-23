using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class AddEmployeeForm : Form
    {
        // FIXED: use same database connection as CentralData (prevents attachdbfilename errors)
        private static string connectionString = CentralData.ConnectionString;

        public AddEmployeeForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Add Employee";
            this.StartPosition = FormStartPosition.CenterScreen;
            // Initialize UI elements and dropdowns upon form loading
            PopulateFormOptions();
        }

        // Populates role combobox and skill checkbox list from system data
        private void PopulateFormOptions()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Employee");
            cmbRole.Items.Add("Admin");
            cmbRole.SelectedIndex = 0;

            clbSkillLevels.Items.Clear();

            List<string> skills = CentralData.GetSkillsFromDatabase();
            foreach (var skill in skills)
                clbSkillLevels.Items.Add(skill);
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            // Capture user input from UI fields
            string empID = txtEmployeeID.Text.Trim();
            string empName = txtEmployeeName.Text.Trim();
            string badge = txtBadgeNumber.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            // Perform basic validation to ensure no fields are empty
            if (string.IsNullOrEmpty(empID) ||
                string.IsNullOrEmpty(empName) ||
                string.IsNullOrEmpty(badge))
            {
                MessageBox.Show("All employee identity fields are required.");
                return;
            }

            // Check for duplicate Employee ID to maintain data integrity
            List<Employee> currentEmployees = CentralData.GetEmployeesFromDatabase();

            if (currentEmployees.Any(emp => emp.EmployeeID == empID))
            {
                MessageBox.Show("Employee already exists.");
                return;
            }

            // Compile selected skills into a list
            List<string> selectedSkills = new List<string>();

            foreach (var item in clbSkillLevels.CheckedItems)
                selectedSkills.Add(item.ToString());

            // Default skill fallback
            if (selectedSkills.Count == 0)
                selectedSkills.Add("Standard");

            string combinedSkills = string.Join(",", selectedSkills);

            string query = @"
                INSERT INTO Employees 
                (EmployeeID, FullName, BadgeNumber, Role, Skills)
                VALUES (@ID, @Name, @Badge, @Role, @Skills)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Use parameterized queries to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ID", empID);
                    cmd.Parameters.AddWithValue("@Name", empName);
                    cmd.Parameters.AddWithValue("@Badge", badge);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@Skills", combinedSkills);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Notify the administrator that the employee was added successfully
                MessageBox.Show("Employee saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the form for the next employee entry
                txtEmployeeID.Clear();
                txtEmployeeName.Clear();
                txtBadgeNumber.Clear();

                cmbRole.SelectedIndex = 0;

                // Uncheck all selected skills
                for (int i = 0; i < clbSkillLevels.Items.Count; i++)
                {
                    clbSkillLevels.SetItemChecked(i, false);
                }

                // Return focus to the Employee ID field
                txtEmployeeID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving employee: {ex.Message}");
            }
        }

        // Returns the user back to the Employee Menu Screen
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Open the Employee Management Menu
            EmployeeMenuForm employeeMenu = new EmployeeMenuForm();
            employeeMenu.StartPosition = FormStartPosition.CenterScreen;
            employeeMenu.Show();

            // Close the current form
            this.Close();
        }
    }
}