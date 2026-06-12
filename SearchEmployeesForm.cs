using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class SearchEmployeesForm : Form
    {
        public SearchEmployeesForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Employee Directory";
            RefreshRosterGrid("");
        }

        private void RefreshRosterGrid(string filterText)
        {
            DataTable rosterTable = new DataTable();

            rosterTable.Columns.Add("Employee ID");
            rosterTable.Columns.Add("Name");
            rosterTable.Columns.Add("Badge Number");
            rosterTable.Columns.Add("Clearance Levels");
            rosterTable.Columns.Add("Current Active Holdings");

            List<Employee> employees = CentralData.GetEmployeesFromDatabase();

            var filteredList = employees.Where(emp =>
                emp.EmployeeID.Contains(filterText) ||
                emp.FullName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var emp in filteredList)
            {
                var activeHoldings = CentralData.RequestList
                    .Where(r => r.EmployeeID == emp.EmployeeID && r.Status == "Approved")
                    .Select(r => r.EquipmentName)
                    .ToList();

                string holdingsDisplay = activeHoldings.Count > 0 ? string.Join(", ", activeHoldings) : "None (Clear)";

                string formattedSkills = emp.Skills;

                rosterTable.Rows.Add(emp.EmployeeID, emp.FullName, emp.BadgeNumber, formattedSkills, holdingsDisplay);
            }

            dgvSearchResults.DataSource = rosterTable;
            dgvSearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSearchResults.Columns[rosterTable.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            RefreshRosterGrid(txtEmployeeSearch.Text.Trim());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            EmployeeMenuForm empMenu = new EmployeeMenuForm();
            empMenu.Show();
            this.Close();
        }

        private void SearchEmployeesForm_Load(object sender, EventArgs e)
        {
        }
    }
}