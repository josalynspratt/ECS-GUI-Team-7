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
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ECSDatabase.mdf;Integrated Security=True";
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

            // Enforce security clearance: check if user possesses the required skill for the item
            if (!string.IsNullOrEmpty(targetEquipment.RequiredSkill) && !currentEmployee.Skills.Contains(targetEquipment.RequiredSkill))
            {
                MessageBox.Show($"Access Denied! This equipment requires '{targetEquipment.RequiredSkill}' clearance, which is not assigned to your profile.",
                                "Clearance Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string projectName = txtProjectName.Text.Trim();
            if (string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Please enter a project name.");
                return;
            }

            // Instantiate request object and generate tracking info
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

            // Database operations to record request and update equipment status
            string insertRequestQuery = "INSERT INTO CheckoutRequests (RequestID, EmployeeID, EmployeeName, EquipmentName, CheckoutDate, ProjectName, Status) VALUES (@RID, @EID, @EName, @Equip, @Date, @Proj, @Status)";
            string updateEquipQuery = "UPDATE Equipment SET Status = 'Pending' WHERE EquipmentID = @ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Transactional approach would be ideal, but here we perform sequence operations
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

                    using (SqlCommand cmd = new SqlCommand(updateEquipQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", newRequest.EquipmentID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Checkout request submitted successfully for approval.");
                txtProjectName.Clear();
                cmbEquipmentList.SelectedIndex = -1;
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