using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class EditEmployeeForm : Form
    {
        private Employee selectedEmployee;
        // Database connection string for the local application database
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public EditEmployeeForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Edit Employee Profile";
            // Initialize dropdowns and skill list on startup
            PopulateFormOptions();
        }

        // Sets up roles and skills, and loads the list of existing employees
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

            PopulateEmployeeDropdown();
        }

        // Refresh list of employees available for editing
        private void PopulateEmployeeDropdown()
        {
            cmbSelectEmployee.Items.Clear();
            List<Employee> employees = CentralData.GetEmployeesFromDatabase();
            foreach (var emp in employees)
            {
                cmbSelectEmployee.Items.Add($"{emp.EmployeeID}: {emp.FullName} ({emp.Role})");
            }
        }

        private void btnSaveUpdates_Click(object sender, EventArgs e)
        {
            // Validate that an employee is actually selected
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee profile to edit first.", "Selection Required");
                return;
            }

            string updatedName = txtEmployeeName.Text.Trim();
            string updatedBadge = txtBadgeNumber.Text.Trim();
            string updatedRole = cmbRole.SelectedItem?.ToString();
            string updatedUsername = updatedName.Replace(" ", "").ToLower(); // Auto-generate username from name

            // Input validation
            if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedBadge))
            {
                MessageBox.Show("Employee name and badge number fields cannot be empty.", "Validation Error");
                return;
            }

            // Execute SQL update query to save changes
            string query = "UPDATE Employees SET FullName = @Name, Username = @User, BadgeNumber = @Badge, Role = @Role WHERE EmployeeID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", updatedName);
                cmd.Parameters.AddWithValue("@User", updatedUsername);
                cmd.Parameters.AddWithValue("@Badge", updatedBadge);
                cmd.Parameters.AddWithValue("@Role", updatedRole);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(selectedEmployee.EmployeeID));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show($"Profile modifications for {updatedName} have been successfully saved!");

            // Refresh UI and clear form fields for next action
            PopulateEmployeeDropdown();
            ClearFormInputs();
        }

        // Resets the form inputs to blank states
        private void ClearFormInputs()
        {
            txtEmployeeName.Clear();
            txtBadgeNumber.Clear();
            cmbRole.SelectedIndex = 0;
            for (int i = 0; i < clbSkillLevels.Items.Count; i++)
            {
                clbSkillLevels.SetItemChecked(i, false);
            }
            cmbSelectEmployee.SelectedIndex = -1;
            selectedEmployee = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EmployeeMenuForm empMenu = new EmployeeMenuForm();
            empMenu.Show();
            this.Close();
        }

        // Event handler to populate form fields when an employee is selected from the dropdown
        private void cmbSelectEmployee_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbSelectEmployee.SelectedIndex >= 0)
            {
                string selectedText = cmbSelectEmployee.Items[cmbSelectEmployee.SelectedIndex].ToString();
                string targetID = selectedText.Split(':')[0].Trim();

                List<Employee> employees = CentralData.GetEmployeesFromDatabase();
                selectedEmployee = employees.FirstOrDefault(emp => emp.EmployeeID == targetID);

                if (selectedEmployee != null)
                {
                    // Populate fields with data from the selected employee object
                    txtEmployeeName.Text = selectedEmployee.FullName;
                    txtBadgeNumber.Text = selectedEmployee.BadgeNumber;
                    cmbRole.SelectedItem = selectedEmployee.Role;

                    // Uncheck all skills, then check only those associated with the user
                    for (int i = 0; i < clbSkillLevels.Items.Count; i++)
                    {
                        clbSkillLevels.SetItemChecked(i, false);
                    }

                    for (int i = 0; i < clbSkillLevels.Items.Count; i++)
                    {
                        string skillName = clbSkillLevels.Items[i].ToString();
                        if (selectedEmployee.Skills.Contains(skillName))
                        {
                            clbSkillLevels.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }
    }
}