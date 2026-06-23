using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for displaying pending checkout requests and managing approval/denial workflow
    public partial class ViewRequestsForm : Form
    {
        private DataTable requestsTable;

        // FIXED: use centralized connection string (prevents attachdbfilename errors)
        private static string connectionString = CentralData.ConnectionString;

        public ViewRequestsForm()
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Pending Requests";
            this.StartPosition = FormStartPosition.CenterScreen;

            RefreshRequestsGrid();
        }

        // Loads all pending checkout requests into the grid
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

            string query =
                "SELECT RequestID, EmployeeID, EmployeeName, EquipmentName, CheckoutDate, ProjectName, Status " +
                "FROM CheckoutRequests WHERE Status = 'Pending'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
                dgvRequests.Columns[dgvRequests.Columns.Count - 1]
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        // Updates request + equipment status safely
        private void ProcessSelectedRequest(string targetStatus)
        {
            if (dgvRequests.CurrentRow == null)
            {
                MessageBox.Show("Please select a request row first.");
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dgvRequests.CurrentRow;

                string requestId = selectedRow.Cells["Request ID"]?.Value?.ToString();
                string equipName = selectedRow.Cells["Equipment"]?.Value?.ToString();

                if (string.IsNullOrEmpty(requestId) || string.IsNullOrEmpty(equipName))
                {
                    MessageBox.Show("Selected row data is invalid.");
                    return;
                }

                string updateRequestQuery =
                    "UPDATE CheckoutRequests SET Status = @Status WHERE RequestID = @RID";

                string updateEquipQuery =
                    "UPDATE Equipment SET Status = @EquipStatus WHERE EquipmentName = @EquipName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Update request status
                    using (SqlCommand cmd = new SqlCommand(updateRequestQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", targetStatus);
                        cmd.Parameters.AddWithValue("@RID", requestId);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Sync equipment status
                    string newEquipStatus =
                        (targetStatus == "Approved") ? "Checked Out" : "Available";

                    using (SqlCommand cmd = new SqlCommand(updateEquipQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@EquipStatus", newEquipStatus);
                        cmd.Parameters.AddWithValue("@EquipName", equipName);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Request {requestId} has been {targetStatus.ToLower()}!");
                RefreshRequestsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Update Error: " + ex.Message);
            }
        }

        // BACK NAVIGATION (FIXED - prevents app exit crash)
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.StartPosition = FormStartPosition.CenterScreen;
            mainMenu.Show();
        }
    }
}