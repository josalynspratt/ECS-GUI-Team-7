using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class RemoveEmployeeForm : Form
    {
        private Employee selectedEmployee;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public RemoveEmployeeForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Remove Employee Profile";
            PopulateEmployeeDropdown();

            txtEmployeeDetails.Multiline = true;
            txtEmployeeDetails.ReadOnly = true;
        }

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
                    txtEmployeeDetails.Text = $"ID: {selectedEmployee.EmployeeID}{Environment.NewLine}" +
                                             $"Name: {selectedEmployee.FullName}{Environment.NewLine}" +
                                             $"Badge: {selectedEmployee.BadgeNumber}{Environment.NewLine}" +
                                             $"Role: {selectedEmployee.Role}{Environment.NewLine}" +
                                             $"Skills: {selectedEmployee.Skills}";
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee profile to remove.", "Selection Error");
                return;
            }

            DialogResult confirmResult = MessageBox.Show($"Are you sure you want to permanently delete the profile for {selectedEmployee.FullName}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Employees WHERE EmployeeID = @ID";

                try
                {
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
                    PopulateEmployeeDropdown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing employee: {ex.Message}", "Database Error");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}