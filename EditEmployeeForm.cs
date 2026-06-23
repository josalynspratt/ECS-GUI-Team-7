using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for modifying existing employee records
    public partial class EditEmployeeForm : Form
    {
        private Employee selectedEmployee;

        // Uses the centralized database connection string
        private static string connectionString = CentralData.ConnectionString;

        public EditEmployeeForm()
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Edit Employee Profile";
            this.StartPosition = FormStartPosition.CenterScreen;

            PopulateFormOptions();
        }

        // Sets up role selections, skill list, and employee dropdown
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

            PopulateEmployeeDropdown();
        }

        // Loads all employees into the selection dropdown
        private void PopulateEmployeeDropdown()
        {
            cmbSelectEmployee.Items.Clear();

            List<Employee> employees = CentralData.GetEmployeesFromDatabase();

            foreach (var emp in employees)
                cmbSelectEmployee.Items.Add($"{emp.EmployeeID}: {emp.FullName} ({emp.Role})");

            cmbSelectEmployee.SelectedIndex = -1;
        }

        private void btnSaveUpdates_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee profile to edit first.", "Selection Required");
                return;
            }

            string updatedName = txtEmployeeName.Text.Trim();
            string updatedBadge = txtBadgeNumber.Text.Trim();
            string updatedRole = cmbRole.SelectedItem?.ToString() ?? "Employee";

            if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedBadge))
            {
                MessageBox.Show("Employee name and badge number fields cannot be empty.", "Validation Error");
                return;
            }

            List<string> selectedSkills = new List<string>();

            foreach (var item in clbSkillLevels.CheckedItems)
                selectedSkills.Add(item.ToString());

            if (selectedSkills.Count == 0)
                selectedSkills.Add("Standard");

            string combinedSkills = string.Join(",", selectedSkills);

            string query = @"
                UPDATE Employees
                SET FullName = @Name,
                    BadgeNumber = @Badge,
                    Role = @Role,
                    Skills = @Skills
                WHERE EmployeeID = @ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", updatedName);
                    cmd.Parameters.AddWithValue("@Badge", updatedBadge);
                    cmd.Parameters.AddWithValue("@Role", updatedRole);
                    cmd.Parameters.AddWithValue("@Skills", combinedSkills);
                    cmd.Parameters.AddWithValue("@ID", selectedEmployee.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Profile modifications for {updatedName} have been successfully saved!");

                PopulateEmployeeDropdown();
                ClearFormInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}");
            }
        }

        // Resets the form inputs
        private void ClearFormInputs()
        {
            txtEmployeeName.Clear();
            txtBadgeNumber.Clear();
            cmbRole.SelectedIndex = 0;

            for (int i = 0; i < clbSkillLevels.Items.Count; i++)
                clbSkillLevels.SetItemChecked(i, false);

            cmbSelectEmployee.SelectedIndex = -1;
            selectedEmployee = null;
        }

        // BACK BUTTON (no parent, no hidden forms, no child tracking)
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            EmployeeMenuForm menu = new EmployeeMenuForm();
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.Show();
        }

        // Loads selected employee into form fields
        private void cmbSelectEmployee_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbSelectEmployee.SelectedIndex < 0)
                return;

            string selectedText = cmbSelectEmployee.SelectedItem.ToString();
            string targetID = selectedText.Split(':')[0].Trim();

            List<Employee> employees = CentralData.GetEmployeesFromDatabase();
            selectedEmployee = employees.FirstOrDefault(emp => emp.EmployeeID == targetID);

            if (selectedEmployee == null)
                return;

            txtEmployeeName.Text = selectedEmployee.FullName;
            txtBadgeNumber.Text = selectedEmployee.BadgeNumber;
            cmbRole.SelectedItem = selectedEmployee.Role;

            for (int i = 0; i < clbSkillLevels.Items.Count; i++)
                clbSkillLevels.SetItemChecked(i, false);

            string[] employeeSkills = (selectedEmployee.Skills ?? "")
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < clbSkillLevels.Items.Count; i++)
            {
                string skillName = clbSkillLevels.Items[i].ToString();

                if (employeeSkills.Contains(skillName))
                    clbSkillLevels.SetItemChecked(i, true);
            }
        }
    }
}