using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class CheckInEquipmentForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public CheckInEquipmentForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Return Asset";
            PopulateCheckedOutEquipment();
            PopulateLocationDropdown();
        }

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

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (lstCheckedOutEquipment.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an item from the list to check in.", "Selection Required");
                return;
            }

            string selectedText = lstCheckedOutEquipment.SelectedItem.ToString();
            string equipmentIdStr = selectedText.Split(':')[0];
            string newLocation = cmbLocation.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newLocation))
            {
                MessageBox.Show("Please select a return warehouse destination.");
                return;
            }

            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
            var targetEquipment = equipment.FirstOrDefault(item => item.Id == equipmentIdStr);
            if (targetEquipment != null)
            {
                string query = "UPDATE Equipment SET Status = @Status, Location = @Location WHERE EquipmentID = @ID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", "Available");
                    cmd.Parameters.AddWithValue("@Location", newLocation);
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(equipmentIdStr));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                var activeRequest = CentralData.RequestList.FirstOrDefault(r =>
                    r.EquipmentID == targetEquipment.Id && r.Status == "Approved");

                if (activeRequest != null)
                {
                    activeRequest.Status = "Returned";
                    activeRequest.ActualReturnDate = DateTime.Now.ToString("MM/dd/yyyy");
                }

                MessageBox.Show($"{targetEquipment.Name} has been successfully checked in and transferred to {newLocation}.");

                PopulateCheckedOutEquipment();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }

        private void CheckInEquipmentForm_Load(object sender, EventArgs e)
        {
        }
    }
}