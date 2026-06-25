using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class DecommissionEquipmentForm : Form
    {
        private Form parentForm;

        public DecommissionEquipmentForm(Form parent)
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Decommission Equipment";
            this.StartPosition = FormStartPosition.CenterScreen;

            parentForm = parent;

            // IMPORTANT: hide parent so we can safely return to it
            if (parentForm != null && !parentForm.IsDisposed)
            {
                parentForm.Hide();
            }

            PopulateEquipmentDropdown();
        }

        private void PopulateEquipmentDropdown()
        {
            cmbSelectEquipment.Items.Clear();

            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();

            foreach (var item in equipment)
            {
                // Only show equipment that is NOT already decommissioned
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
                MessageBox.Show("Please select an equipment item first.");
                return;
            }

            string selectedText = cmbSelectEquipment.SelectedItem.ToString();
            string equipmentId = selectedText.Split(':')[0].Trim();

            var equipment = CentralData.GetEquipmentFromDatabase();
            var target = equipment.FirstOrDefault(x => x.Id == equipmentId);

            if (target == null)
            {
                MessageBox.Show("Equipment not found.");
                return;
            }

            // Prevent decommissioning equipment that is currently checked out
            if (target.Status == "Checked Out")
            {
                MessageBox.Show("Cannot decommission equipment that is checked out.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Decommission {target.Name}?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                // Updates database: sets status to Decommissioned and clears assignment fields
                CentralData.DecommissionEquipment(equipmentId);

                CentralData.AuditLogList.Add(new AuditLog
                {
                    LogID = Guid.NewGuid().ToString(),
                    Action = "Equipment Decommissioned",
                    Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Details = $"Equipment {equipmentId} was decommissioned"
                });

                MessageBox.Show("Equipment successfully decommissioned.");
                CentralData.AddAuditLog(
                    "Equipment Decommissioned",
                    $"{target.Name} was decommissioned"
                );

                PopulateEquipmentDropdown();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            if (parentForm != null && !parentForm.IsDisposed)
            {
                parentForm.StartPosition = FormStartPosition.CenterScreen;
                parentForm.Show();
            }
        }
    }
}