using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class RequestCheckoutForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public RequestCheckoutForm(string employeeID)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(employeeID) || employeeID.Equals("Unknown", StringComparison.OrdinalIgnoreCase))
            {
                List<Employee> employees = CentralData.GetEmployeesFromDatabase();
                var defaultEmp = employees.FirstOrDefault();
                txtEmployeeID.Text = defaultEmp != null ? defaultEmp.EmployeeID : "10020";
            }
            else
            {
                txtEmployeeID.Text = employeeID;
            }

            this.Text = "Equipment Checkout System - Request Checkout";
            PopulateEquipmentDropdown();
        }

        private void PopulateEquipmentDropdown()
        {
            cmbEquipmentList.Items.Clear();
            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();

            foreach (var item in equipment)
            {
                if (item.Status == "Available")
                {
                    cmbEquipmentList.Items.Add(item.Name);
                }
            }

            if (cmbEquipmentList.Items.Count > 0)
            {
                cmbEquipmentList.SelectedIndex = 0;
            }
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            string currentEmpID = txtEmployeeID.Text.Trim();
            string selectedEquipName = cmbEquipmentList.SelectedItem?.ToString();

            List<Employee> employees = CentralData.GetEmployeesFromDatabase();
            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();

            var currentEmployee = employees.FirstOrDefault(emp => emp.EmployeeID == currentEmpID);
            var targetEquipment = equipment.FirstOrDefault(eq => eq.Name == selectedEquipName);

            if (currentEmployee == null || targetEquipment == null)
            {
                MessageBox.Show("Invalid Employee ID or Equipment selection.");
                return;
            }

            if (!string.IsNullOrEmpty(targetEquipment.RequiredSkill) && !currentEmployee.Skills.Contains(targetEquipment.RequiredSkill))
            {
                MessageBox.Show($"Access Denied! This equipment requires '{targetEquipment.RequiredSkill}' clearance, which is not assigned to your profile.",
                                "Clearance Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string projectName = txtProjectName.Text.Trim();
            string checkoutDate = DateTime.Now.ToString("MM/dd/yyyy");
            string expectedReturn = DateTime.Now.AddDays(7).ToString("MM/dd/yyyy");

            if (string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Please enter a project name.");
                return;
            }

            CheckoutRequest newRequest = new CheckoutRequest
            {
                RequestID = CentralData.GenerateNextRequestID(),
                EmployeeID = currentEmployee.EmployeeID,
                EmployeeName = currentEmployee.FullName,
                EquipmentID = targetEquipment.Id,
                EquipmentName = targetEquipment.Name,
                CheckoutDate = checkoutDate,
                ProjectName = projectName,
                Status = "Pending",
                ExpectedReturnDate = expectedReturn,
                ActualReturnDate = "N/A"
            };

            string query = "UPDATE Equipment SET Status = 'Pending' WHERE EquipmentID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", targetEquipment.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CentralData.RequestList.Add(newRequest);

            MessageBox.Show($"Success! Your request {newRequest.RequestID} has been submitted for approval.");
            ReturnToEmployeeDashboard();
        }

        private void ReturnToEmployeeDashboard()
        {
            EmployeeDashboardForm employeeDashboard = new EmployeeDashboardForm(txtEmployeeID.Text.Trim());
            employeeDashboard.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnToEmployeeDashboard();
        }
    }
}