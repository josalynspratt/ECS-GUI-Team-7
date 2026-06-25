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

        // FIX: unified connection string (prevents AttachDbFilename mismatch errors)
        private static string connectionString = CentralData.ConnectionString;

        public RemoveEmployeeForm()
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Remove Employee Profile";
            this.StartPosition = FormStartPosition.CenterScreen;

            PopulateEmployeeDropdown();

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

            txtEmployeeDetails.Clear();
            selectedEmployee = null;
        }

        // Event handler to load employee details when selected
        private void cmbSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectEmployee.SelectedIndex < 0)
                return;

            string selectedText = cmbSelectEmployee.SelectedItem.ToString();
            string targetID = selectedText.Split(':')[0].Trim();

            List<Employee> employees = CentralData.GetEmployeesFromDatabase();
            selectedEmployee = employees.FirstOrDefault(emp => emp.EmployeeID == targetID);

            if (selectedEmployee == null)
                return;

            txtEmployeeDetails.Text =
                $"ID: {selectedEmployee.EmployeeID}{Environment.NewLine}" +
                $"Name: {selectedEmployee.FullName}{Environment.NewLine}" +
                $"Badge: {selectedEmployee.BadgeNumber}{Environment.NewLine}" +
                $"Role: {selectedEmployee.Role}{Environment.NewLine}" +
                $"Skills: {selectedEmployee.Skills}";
        }

        // Handles permanent deletion
        // Handles permanent deletion
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee profile to remove.", "Selection Error");
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Are you sure you want to permanently delete the profile for {selectedEmployee.FullName}?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            // Prevent deletion if employee currently has equipment assigned
            string equipmentCheckQuery =
                "SELECT COUNT(*) FROM Equipment WHERE AssignedEmployeeID = @ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(equipmentCheckQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedEmployee.EmployeeID);

                    conn.Open();

                    int assignedCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (assignedCount > 0)
                    {
                        MessageBox.Show(
                            "This employee currently has equipment checked out and cannot be removed.",
                            "Deletion Blocked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }

                // Prevent deletion if employee has pending or approved checkout requests
                string requestCheckQuery =
                    @"SELECT COUNT(*)
              FROM CheckoutRequests
              WHERE EmployeeID = @ID
              AND Status IN ('Pending', 'Approved')";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(requestCheckQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedEmployee.EmployeeID);

                    conn.Open();

                    int activeRequests = Convert.ToInt32(cmd.ExecuteScalar());

                    if (activeRequests > 0)
                    {
                        MessageBox.Show(
                            "This employee has active checkout requests and cannot be removed.",
                            "Deletion Blocked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }

                string query = "DELETE FROM Employees WHERE EmployeeID = @ID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedEmployee.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Employee profile successfully removed.", "Success");

                PopulateEmployeeDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing employee: {ex.Message}", "Database Error");
            }
        }

        // BACK BUTTON (consistent navigation rule)
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            EmployeeMenuForm menu = new EmployeeMenuForm();
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.Show();
        }
    }
}