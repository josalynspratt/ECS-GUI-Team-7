using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for providing a searchable directory of employees and their current equipment status
    public partial class SearchEmployeesForm : Form
    {
        public SearchEmployeesForm()
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Employee Directory";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Load the initial full roster on form initialization
            RefreshRosterGrid("");
        }

        // Filters the employee roster based on user input and updates the DataGridView
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
                (!string.IsNullOrEmpty(emp.EmployeeID) &&
                 emp.EmployeeID.Contains(filterText)) ||

                (!string.IsNullOrEmpty(emp.FullName) &&
                 emp.FullName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0));

            foreach (var emp in filteredList)
            {
                var activeHoldings = CentralData.RequestList
                    .Where(r => r.EmployeeID == emp.EmployeeID && r.Status == "Approved")
                    .Select(r => r.EquipmentName)
                    .ToList();

                string holdingsDisplay = activeHoldings.Count > 0
                    ? string.Join(", ", activeHoldings)
                    : "None (Clear)";

                string formattedSkills = emp.Skills ?? "None";

                rosterTable.Rows.Add(
                    emp.EmployeeID,
                    emp.FullName,
                    emp.BadgeNumber,
                    formattedSkills,
                    holdingsDisplay
                );
            }

            dgvSearchResults.DataSource = rosterTable;

            dgvSearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dgvSearchResults.Columns.Count > 0)
            {
                dgvSearchResults.Columns[dgvSearchResults.Columns.Count - 1]
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        // Trigger search refresh
        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            RefreshRosterGrid(txtEmployeeSearch.Text.Trim());
        }

        // RETURN NAVIGATION (standardized)
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            EmployeeMenuForm menu = new EmployeeMenuForm();
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.Show();
        }

        private void SearchEmployeesForm_Load(object sender, EventArgs e)
        {
            // intentionally left blank
        }
    }
}