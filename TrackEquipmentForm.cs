using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class TrackEquipmentForm : Form
    {
        private DataTable equipmentTable;
        private string userRole;

        public TrackEquipmentForm(string role = "Admin")
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Track Equipment";
            this.userRole = role;
            InitializeEquipmentData();
            InitializeFilterOptions();
        }

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
                equipmentTable.Rows.Add(item.Id, item.Name, item.Model, item.RequiredSkill, item.Status, item.Location);
            }

            dgvActiveCheckouts.DataSource = equipmentTable;
            dgvActiveCheckouts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvActiveCheckouts.Columns[equipmentTable.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitializeFilterOptions()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Available");
            cmbStatusFilter.Items.Add("Pending");
            cmbStatusFilter.Items.Add("Checked Out");
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cmbStatusFilter.SelectedItem.ToString();

            if (selectedStatus == "All")
            {
                equipmentTable.DefaultView.RowFilter = "";
            }
            else
            {
                equipmentTable.DefaultView.RowFilter = $"Status = '{selectedStatus}'";
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            if (!userRole.Equals("Employee", StringComparison.OrdinalIgnoreCase))
            {
                EquipmentMenuForm equipMenu = new EquipmentMenuForm();
                equipMenu.Show();
            }
            else
            {
                EmployeeDashboardForm empDashboard = new EmployeeDashboardForm();
                empDashboard.Show();
            }
            this.Close();
        }
    }
}