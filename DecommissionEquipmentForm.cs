using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class DecommissionEquipmentForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public DecommissionEquipmentForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Decommission Equipment";
            PopulateEquipmentDropdown();
        }

        private void PopulateEquipmentDropdown()
        {
            cmbSelectEquipment.Items.Clear();
            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();

            foreach (var item in equipment)
            {
                if (item.Status != "Decommissioned")
                {
                    cmbSelectEquipment.Items.Add($"{item.Id}: {item.Name} ({item.Status})");
                }
            }
        }

        private void btnDecommission_Click(object sender, EventArgs e)
        {
            if (cmbSelectEquipment.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an equipment item to decommission first.", "Selection Required");
                return;
            }

            string selectedText = cmbSelectEquipment.SelectedItem.ToString();
            int equipmentId = int.Parse(selectedText.Split(':')[0]);

            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
            var targetEquipment = equipment.FirstOrDefault(item => item.Id == equipmentId.ToString());
            if (targetEquipment != null)
            {
                if (targetEquipment.Status == "Checked Out")
                {
                    MessageBox.Show(
                        $"{targetEquipment.Name} cannot be decommissioned because it is currently checked out by an employee. " +
                        "It must be checked back in before it can be removed from inventory.",
                        "Action Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop
                    );
                    return;
                }

                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to decommission {targetEquipment.Name}? This will permanently remove it from the active asset list.",
                    "Confirm Decommission",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM Equipment WHERE EquipmentID = @ID";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", equipmentId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("The equipment has been successfully decommissioned.");

                    PopulateEquipmentDropdown();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EquipmentMenuForm equipMenu = new EquipmentMenuForm();
            equipMenu.Show();
            this.Close();
        }
    }
}