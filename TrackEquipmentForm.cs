using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for displaying real-time inventory status and location tracking
    public partial class TrackEquipmentForm : Form
    {
        private DataTable equipmentTable; // Underlying data source for grid display

        // Stores the form that opened this one (Admin menu OR Employee dashboard)
        private Form parentForm;

        public TrackEquipmentForm(Form parent)
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Track Equipment";
            this.StartPosition = FormStartPosition.CenterScreen;

            parentForm = parent;

            // Safer navigation pattern:
            // Instead of relying on a potentially Closed parent, we keep reference
            // and only Hide it if it's still valid.
            if (parentForm != null && !parentForm.IsDisposed)
            {
                parentForm.Hide();
            }

            InitializeEquipmentData();
            InitializeFilterOptions();
        }

        // Fetches data from central storage and binds it to the DataGridView
        private void InitializeEquipmentData()
        {
            equipmentTable = new DataTable();

            equipmentTable.Columns.Add("Asset ID", typeof(string));
            equipmentTable.Columns.Add("Name", typeof(string));
            equipmentTable.Columns.Add("Model", typeof(string));
            equipmentTable.Columns.Add("Required Skill", typeof(string));
            equipmentTable.Columns.Add("Status", typeof(string));
            equipmentTable.Columns.Add("Location", typeof(string));

            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();

            foreach (var item in equipment)
            {
                equipmentTable.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Model,
                    item.RequiredSkill,
                    item.Status,
                    item.Location
                );
            }

            dgvActiveCheckouts.DataSource = equipmentTable;

            dgvActiveCheckouts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvActiveCheckouts.Columns[equipmentTable.Columns.Count - 1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
        }

        // Configures filter dropdown for status-based inventory views
        private void InitializeFilterOptions()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Available");
            cmbStatusFilter.Items.Add("Pending");
            cmbStatusFilter.Items.Add("Checked Out");

            cmbStatusFilter.SelectedIndex = 0;
        }

        // Updates grid view dynamically when filter changes
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cmbStatusFilter.SelectedItem.ToString();

            if (selectedStatus == "All")
                equipmentTable.DefaultView.RowFilter = "";
            else
                equipmentTable.DefaultView.RowFilter = $"Status = '{selectedStatus}'";
        }

        // Returns to the form that opened this screen
        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Form targetMenu = parentForm;

            this.Hide(); // IMPORTANT: do NOT Close()

            // If parent still exists, reuse it
            if (targetMenu != null && !targetMenu.IsDisposed)
            {
                targetMenu.StartPosition = FormStartPosition.CenterScreen;
                targetMenu.Show();
                return;
            }

            // FALLBACK: recover correct menu instance if parent is gone
            Form recoveredMenu =
                Application.OpenForms
                .Cast<Form>()
                .FirstOrDefault(f => f is EquipmentMenuForm || f is EmployeeDashboardForm);

            if (recoveredMenu != null)
            {
                recoveredMenu.StartPosition = FormStartPosition.CenterScreen;
                recoveredMenu.Show();
            }
        }
    }
}