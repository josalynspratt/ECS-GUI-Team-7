using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class CheckInEquipmentForm : Form
    {
        // Connection string for the local database file
        private static string connectionString = CentralData.ConnectionString; public CheckInEquipmentForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Return Asset";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Populate list of available assets and location options on initialization
            PopulateCheckedOutEquipment();
            PopulateLocationDropdown();
        }

        // Fills the location dropdown to allow staff to specify warehouse destination
        private void PopulateLocationDropdown()
        {
            cmbLocation.Items.Clear();
            cmbLocation.Items.Add("Main Warehouse");
            cmbLocation.Items.Add("Campus Warehouse");
            if (cmbLocation.Items.Count > 0)
            {
                cmbLocation.SelectedIndex = 0;
            }
        }

        // Filters and displays only equipment currently marked as 'Checked Out'
        private void PopulateCheckedOutEquipment()
        {
            lstCheckedOutEquipment.Items.Clear();
            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
            var activeCheckouts = equipment.Where(item => item.Status == "Checked Out");
            foreach (var item in activeCheckouts)
            {
                lstCheckedOutEquipment.Items.Add($"{item.Id}: {item.Name}");
            }
        }

        // Updates the location dropdown to reflect the current known location of the selected item
        private void lstCheckedOutEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCheckedOutEquipment.SelectedIndex >= 0)
            {
                string selectedText = lstCheckedOutEquipment.SelectedItem.ToString();
                string equipmentIdStr = selectedText.Split(':')[0];

                List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
                var targetEquipment = equipment.FirstOrDefault(item => item.Id == equipmentIdStr);
                if (targetEquipment != null && cmbLocation.Items.Contains(targetEquipment.Location))
                {
                    cmbLocation.SelectedItem = targetEquipment.Location;
                }
            }
        }

        // Handles the core check-in logic: updating DB status and finalizing the request record
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (lstCheckedOutEquipment.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an item.", "Selection Required");
                return;
            }

            string selectedText = lstCheckedOutEquipment.SelectedItem.ToString();
            string equipmentIdStr = selectedText.Split(':')[0].Trim();
            string newLocation = cmbLocation.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newLocation))
            {
                MessageBox.Show("Select a return location.");
                return;
            }

            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
            var targetEquipment = equipment.FirstOrDefault(item => item.Id == equipmentIdStr);

            if (targetEquipment == null) return;

            string query =
                @"UPDATE Equipment
          SET Status = @Status,
              Location = @Location,
              AssignedEmployeeID = NULL,
              ExpectedReturnDate = NULL,
              LastUpdated = @Updated
          WHERE EquipmentID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Status", "Available");
                cmd.Parameters.AddWithValue("@Location", newLocation);
                cmd.Parameters.AddWithValue("@Updated", DateTime.Now);
                cmd.Parameters.AddWithValue("@ID", equipmentIdStr);

                conn.Open();
                cmd.ExecuteNonQuery();
                CentralData.AuditLogList.Add(new AuditLog
                {
                    LogID = Guid.NewGuid().ToString(),
                    Action = "Equipment Checked In",
                    Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Details = $"{targetEquipment.Id} checked in to {newLocation}"
                });
            }

            var activeRequest = CentralData.RequestList.FirstOrDefault(r =>
                r.EquipmentID == targetEquipment.Id &&
                r.Status == "Pending");

            if (activeRequest != null)
            {
                activeRequest.Status = "Returned";
                activeRequest.ActualReturnDate = DateTime.Now.ToString("MM/dd/yyyy");
            }

            MessageBox.Show($"{targetEquipment.Name} checked in.");
            CentralData.AddAuditLog(
                 "Equipment Checked In",
                  $"{targetEquipment.Name} returned to {newLocation}"
            );

            PopulateCheckedOutEquipment();
        }

        // Navigation back to the Main Menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.StartPosition = FormStartPosition.CenterScreen;
            mainMenu.Show();
        }

        private void CheckInEquipmentForm_Load(object sender, EventArgs e)
        {
        }
    }
}