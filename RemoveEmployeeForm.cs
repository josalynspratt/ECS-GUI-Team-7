using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for the permanent removal of employee profiles from the system
    public partial class RemoveEmployeeForm : Form
    {
        private Employee selectedEmployee;
        // Database connection string for the local application database
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public RemoveEmployeeForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Remove Employee Profile";
            // Initialize the list of available employees
            PopulateEmployeeDropdown();

            // Configure text box for read-only display of selected employee data
            txtEmployeeDetails.Multiline = true;
            txtEmployeeDetails.ReadOnly = true;
        }

        // Populates the dropdown with all current employees in the database
        private void PopulateEmployeeDropdown()
        {
            cmbSelectEmployee.Items.Clear();
            List<Employee> employees = CentralData.GetEmployeesFromDatabase();
            foreach (var emp in employees)
            {
                cmbSelectEmployee.Items.Add($"{emp.EmployeeID}: {emp.FullName} ({emp.Role})");
            }
            txtEmployeeDetails.Clear(); // Clear display area on refresh
            selectedEmployee = null;
        }

        // Event handler to load employee details when an item is selected from the dropdown
        private void cmbSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectEmployee.SelectedIndex >= 0)
            {
                string selectedText = cmbSelectEmployee.Items[cmbSelectEmployee.SelectedIndex].ToString();
                string targetID = selectedText.Split(':')[0].Trim();

                List<Employee> employees = CentralData.GetEmployeesFromDatabase();
                selectedEmployee = employees.FirstOrDefault(emp => emp.EmployeeID == targetID);

                if (selectedEmployee != null)
                {
                    // Update display field with profile information
                    txtEmployeeDetails.Text = $"ID: {selectedEmployee.EmployeeID}{Environment.NewLine}" +
                                             $"Name: {selectedEmployee.FullName}{Environment.NewLine}" +
                                             $"Badge: {selectedEmployee.BadgeNumber}{Environment.NewLine}" +
                                             $"Role: {selectedEmployee.Role}{Environment.NewLine}" +
                                             $"Skills: {selectedEmployee.Skills}";
                }
            }
        }

        // Handles the permanent deletion of the selected employee profile
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee profile to remove.", "Selection Error");
                return;
            }

            // Prompt user for confirmation to prevent accidental data loss
            DialogResult confirmResult = MessageBox.Show($"Are you sure you want to permanently delete the profile for {selectedEmployee.FullName}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Employees WHERE EmployeeID = @ID";

                try
                {
                    // Execute the SQL DELETE command
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(selectedEmployee.EmployeeID));
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Employee profile successfully removed.", "Success");
                    PopulateEmployeeDropdown(); // Refresh dropdown to reflect changes
                }
                catch (Exception ex)
                {
                    // Handle potential database constraints or connection issues
                    MessageBox.Show($"Error removing employee: {ex.Message}", "Database Error");
                }
            }
        }

        // Returns the user to the main menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}