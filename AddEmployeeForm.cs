using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class AddEmployeeForm : Form
    {
        // Database connection string for local SQL Server MDF file
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public AddEmployeeForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Add Employee";
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
            {
                clbSkillLevels.Items.Add(skill);
            }
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            // Capture user input from UI fields
            string empID = txtEmployeeID.Text.Trim();
            string empName = txtEmployeeName.Text.Trim();
            string badge = txtBadgeNumber.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            // Perform basic validation to ensure no fields are empty
            if (string.IsNullOrEmpty(empID) || string.IsNullOrEmpty(empName) || string.IsNullOrEmpty(badge))
            {
                MessageBox.Show("All employee identity fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate Employee ID to maintain data integrity
            List<Employee> currentEmployees = CentralData.GetEmployeesFromDatabase();
            if (currentEmployees.Any(emp => emp.EmployeeID == empID))
            {
                MessageBox.Show($"An employee with ID '{empID}' already exists in the system.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Compile selected skills into a list
            List<string> selectedSkills = new List<string>();
            foreach (var checkedItem in clbSkillLevels.CheckedItems)
            {
                selectedSkills.Add(checkedItem.ToString());
            }

            // Default to 'Standard' skill if no specific skills are selected
            List<string> dbSkills = CentralData.GetSkillsFromDatabase();
            if (selectedSkills.Count == 0 && dbSkills.Contains("Standard"))
            {
                selectedSkills.Add("Standard");
            }

            // Prepare data for database insertion
            string combinedSkills = string.Join(",", selectedSkills);
            string query = "INSERT INTO Employees (EmployeeID, FullName, BadgeNumber, Role, Skills) VALUES (@ID, @Name, @Badge, @Role, @Skills)";

            try
            {
                // Execute SQL command within a using block to ensure connection is closed properly
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use parameterized queries to prevent SQL injection
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(empID));
                        cmd.Parameters.AddWithValue("@Name", empName);
                        cmd.Parameters.AddWithValue("@Badge", badge);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Skills", combinedSkills);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Employee saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Return to previous screen
            }
            catch (Exception ex)
            {
                // Handle database connectivity or execution errors
                MessageBox.Show($"Error saving employee: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}