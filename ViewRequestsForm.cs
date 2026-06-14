using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for displaying pending checkout requests and managing the approval/denial workflow
    public partial class ViewRequestsForm : Form
    {
        private DataTable requestsTable;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECSDatabase.mdf") + ";Integrated Security=True";

        public ViewRequestsForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Pending Requests";
            // Load pending requests upon initialization
            RefreshRequestsGrid();
        }

        // Queries the database for all requests currently marked as 'Pending' and populates the DataGridView
        private void RefreshRequestsGrid()
        {
            requestsTable = new DataTable();
            requestsTable.Columns.Add("Request ID");
            requestsTable.Columns.Add("Employee ID");
            requestsTable.Columns.Add("Employee Name");
            requestsTable.Columns.Add("Equipment");
            requestsTable.Columns.Add("Checkout Date");
            requestsTable.Columns.Add("Project Name");
            requestsTable.Columns.Add("Status");

            string query = "SELECT RequestID, EmployeeID, EmployeeName, EquipmentName, CheckoutDate, ProjectName, Status FROM CheckoutRequests WHERE Status = 'Pending'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requestsTable.Rows.Add(
                                reader["RequestID"].ToString(),
                                reader["EmployeeID"].ToString(),
                                reader["EmployeeName"].ToString(),
                                reader["EquipmentName"].ToString(),
                                reader["CheckoutDate"].ToString(),
                                reader["ProjectName"].ToString(),
                                reader["Status"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requests: " + ex.Message);
            }

            dgvRequests.DataSource = requestsTable;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (dgvRequests.Columns.Count > 0)
            {
                dgvRequests.Columns[dgvRequests.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ProcessSelectedRequest("Approved");
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            ProcessSelectedRequest("Denied");
        }

        // Logic for updating the request status and syncing the corresponding equipment availability
        private void ProcessSelectedRequest(string targetStatus)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRequests.SelectedRows[0];
                string requestId = selectedRow.Cells["Request ID"].Value.ToString();

                string updateRequestQuery = "UPDATE CheckoutRequests SET Status = @Status WHERE RequestID = @RID";
                string updateEquipQuery = "UPDATE Equipment SET Status = @EquipStatus WHERE EquipmentName = @EquipName";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // 1. Update the request status
                        using (SqlCommand cmd = new SqlCommand(updateRequestQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Status", targetStatus);
                            cmd.Parameters.AddWithValue("@RID", requestId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Synchronize equipment status: 'Checked Out' if approved, 'Available' if denied
                        string equipName = selectedRow.Cells["Equipment"].Value.ToString();
                        string newEquipStatus = (targetStatus == "Approved") ? "Checked Out" : "Available";

                        using (SqlCommand cmd = new SqlCommand(updateEquipQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@EquipStatus", newEquipStatus);
                            cmd.Parameters.AddWithValue("@EquipName", equipName);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Request {requestId} has been successfully {targetStatus.ToLower()}!");
                    RefreshRequestsGrid(); // Update the UI
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Update Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a pending request row from the list grid first.");
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