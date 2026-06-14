using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            // Load the initial full roster on form initialization
            RefreshRosterGrid("");
        }

        // Filters the employee roster based on user input and updates the DataGridView
        private void RefreshRosterGrid(string filterText)
        {
            DataTable rosterTable = new DataTable();

            // Define the structure of the data table for display
            rosterTable.Columns.Add("Employee ID");
            rosterTable.Columns.Add("Name");
            rosterTable.Columns.Add("Badge Number");
            rosterTable.Columns.Add("Clearance Levels");
            rosterTable.Columns.Add("Current Active Holdings");

            List<Employee> employees = CentralData.GetEmployeesFromDatabase();

            // Apply filter logic to match ID or Name
            var filteredList = employees.Where(emp =>
                emp.EmployeeID.Contains(filterText) ||
                emp.FullName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var emp in filteredList)
            {
                // Join request data to show what equipment each employee currently holds
                var activeHoldings = CentralData.RequestList
                    .Where(r => r.EmployeeID == emp.EmployeeID && r.Status == "Approved")
                    .Select(r => r.EquipmentName)
                    .ToList();

                string holdingsDisplay = activeHoldings.Count > 0 ? string.Join(", ", activeHoldings) : "None (Clear)";

                string formattedSkills = emp.Skills;

                // Add record to the DataTable for binding
                rosterTable.Rows.Add(emp.EmployeeID, emp.FullName, emp.BadgeNumber, formattedSkills, holdingsDisplay);
            }

            // Bind data to the GridView and format columns
            dgvSearchResults.DataSource = rosterTable;
            dgvSearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSearchResults.Columns[rosterTable.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // Trigger the filter refresh based on user search term
        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            RefreshRosterGrid(txtEmployeeSearch.Text.Trim());
        }

        // Return navigation
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