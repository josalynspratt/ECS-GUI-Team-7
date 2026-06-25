using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for enabling employees to request equipment checkouts with skill validation
    public partial class RequestCheckoutForm : Form
    {
        private static string connectionString = CentralData.ConnectionString;

        public RequestCheckoutForm(string employeeID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            try
            {
                // Set current session ID; fallback to default if employeeID is missing
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message);
            }
        }

        // Filters equipment to show only items currently available for checkout
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

            if (!string.IsNullOrEmpty(targetEquipment.RequiredSkill) &&
                !currentEmployee.Skills.Contains(targetEquipment.RequiredSkill))
            {
                MessageBox.Show(
                    $"Access Denied! This equipment requires '{targetEquipment.RequiredSkill}' clearance.",
                    "Clearance Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string projectName = txtProjectName.Text.Trim();
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
                CheckoutDate = DateTime.Now.ToString("MM/dd/yyyy"),
                ProjectName = projectName,
                Status = "Pending",
                ExpectedReturnDate = DateTime.Now.AddDays(7).ToString("MM/dd/yyyy"),
                ActualReturnDate = "N/A"
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert request
                    string insertRequestQuery =
                        @"INSERT INTO CheckoutRequests
                  (RequestID, EmployeeID, EmployeeName, EquipmentName, CheckoutDate, ProjectName, Status)
                  VALUES
                  (@RID, @EID, @EName, @Equip, @Date, @Proj, @Status)";

                    using (SqlCommand cmd = new SqlCommand(insertRequestQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RID", newRequest.RequestID);
                        cmd.Parameters.AddWithValue("@EID", newRequest.EmployeeID);
                        cmd.Parameters.AddWithValue("@EName", newRequest.EmployeeName);
                        cmd.Parameters.AddWithValue("@Equip", newRequest.EquipmentName);
                        cmd.Parameters.AddWithValue("@Date", newRequest.CheckoutDate);
                        cmd.Parameters.AddWithValue("@Proj", newRequest.ProjectName);
                        cmd.Parameters.AddWithValue("@Status", newRequest.Status);
                        cmd.ExecuteNonQuery();
                    }

                    CentralData.RequestList.Add(newRequest);
                    CentralData.AuditLogList.Add(new AuditLog
                    {
                        LogID = Guid.NewGuid().ToString(),
                        Action = "Checkout Requested",
                        Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Details = $"{currentEmployee.EmployeeID} requested {targetEquipment.Name}"
                    });

                    // Update equipment
                    string updateEquipmentQuery =
                        @"UPDATE Equipment
                  SET AssignedEmployeeID = @EmpID,
                      ExpectedReturnDate = @ReturnDate,
                      Status = 'Checked Out',
                      LastUpdated = @Updated
                  WHERE EquipmentID = @EquipID";

                    using (SqlCommand cmd = new SqlCommand(updateEquipmentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpID", currentEmployee.EmployeeID);
                        cmd.Parameters.AddWithValue("@ReturnDate", newRequest.ExpectedReturnDate);
                        cmd.Parameters.AddWithValue("@Updated", DateTime.Now);
                        cmd.Parameters.AddWithValue("@EquipID", targetEquipment.Id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Checkout request submitted successfully.");

                txtProjectName.Clear();
                cmbEquipmentList.SelectedIndex = -1;
                CentralData.AddAuditLog(
                    "Checkout Requested",
                    $"Employee {currentEmployee.EmployeeID} requested {targetEquipment.Name}"
);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmployeeDashboardForm dashboard = new EmployeeDashboardForm(txtEmployeeID.Text);
            dashboard.Show();
            this.Close();
        }
    }
}