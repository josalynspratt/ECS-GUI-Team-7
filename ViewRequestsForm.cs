using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class ViewRequestsForm : Form
    {
        private DataTable requestsTable;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public ViewRequestsForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Pending Requests";
            RefreshRequestsGrid();
        }

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

            foreach (var req in CentralData.RequestList)
            {
                if (req.Status == "Pending")
                {
                    requestsTable.Rows.Add(req.RequestID, req.EmployeeID, req.EmployeeName, req.EquipmentName, req.CheckoutDate, req.ProjectName, req.Status);
                }
            }

            dgvRequests.DataSource = requestsTable;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRequests.Columns[requestsTable.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ProcessSelectedRequest("Approved");
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            ProcessSelectedRequest("Denied");
        }

        private void ProcessSelectedRequest(string targetStatus)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRequests.SelectedRows[0];
                string requestId = selectedRow.Cells["Request ID"].Value.ToString();

                CheckoutRequest match = CentralData.RequestList.Find(r => r.RequestID == requestId);

                if (match != null)
                {
                    match.Status = targetStatus;

                    List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
                    EquipmentItem asset = equipment.Find(eq => eq.Id == match.EquipmentID);
                    if (asset != null)
                    {
                        int isCheckedOutValue = (targetStatus == "Approved") ? 1 : 0;
                        string query = "UPDATE Equipment SET IsCheckedOut = @IsCheckedOut WHERE EquipmentID = @ID";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@IsCheckedOut", isCheckedOutValue);
                            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(match.EquipmentID));

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Request {requestId} has been successfully {targetStatus.ToLower()}!");
                    RefreshRequestsGrid();
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