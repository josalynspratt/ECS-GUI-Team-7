using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for generating printable HTML reports for inventory and personnel
    public partial class ReportsMenuForm : Form
    {
        public ReportsMenuForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Equipment Checkout System - Reports Menu";
        }

        // Centralized method to build, save, and open an HTML-based report
        private void GenerateHtmlReport(string reportTitle, string htmlTableRows, string tableHeaders)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Construct HTML structure with embedded CSS for styling and printing support
                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html><html><head><style>");
                html.AppendLine("body { font-family: Arial, sans-serif; margin: 30px; color: #333; }");
                html.AppendLine("h2 { color: #2C3E50; margin-bottom: 5px; }");
                html.AppendLine(".timestamp { color: #7F8C8D; font-style: italic; margin-bottom: 20px; }");
                html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
                html.AppendLine("th { background-color: #34495E; color: white; padding: 10px; text-align: left; }");
                html.AppendLine("td { padding: 10px; border-bottom: 1px solid #BDC3C7; }");
                html.AppendLine("tr:nth-child(even) { background-color: #F8F9F9; }");
                html.AppendLine("@media print { .no-print { display: none; } }"); // Hide print button on hard copy
                html.AppendLine("</style></head><body>");
                html.AppendLine($"<h2>{reportTitle}</h2>");
                html.AppendLine($"<div class='timestamp'>Generated on: {timestamp}</div>");
                html.AppendLine("<table>");
                html.AppendLine($"<tr>{tableHeaders}</tr>");
                html.AppendLine(htmlTableRows);
                html.AppendLine("</table>");
                html.AppendLine("<br/><button class='no-print' onclick='window.print()'>Print Report</button>");
                html.AppendLine("</body></html>");

                // Ensure the Reports directory exists, then create the file
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = $"{reportTitle.Replace(" ", "")}_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                string filePath = Path.Combine(folderPath, fileName);
                File.WriteAllText(filePath, html.ToString());

                // Launch the system default browser to display the generated report
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report file: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Collects inventory data and formats it for the Master Equipment Report
        private void btnEquipmentReport_Click(object sender, EventArgs e)
        {
            List<EquipmentItem> items = CentralData.GetEquipmentFromDatabase();
            StringBuilder rows = new StringBuilder();

            string headers = "<th>ID</th><th>Name</th><th>Model</th><th>Required Skill</th><th>Status</th><th>Location</th>";

            foreach (var item in items)
            {
                rows.AppendLine($"<tr><td>{item.Id}</td><td>{item.Name}</td><td>{item.Model}</td><td>{item.RequiredSkill}</td><td>{item.Status}</td><td>{item.Location}</td></tr>");
            }

            GenerateHtmlReport("Master Equipment Asset Report", rows.ToString(), headers);
        }

        // Collects personnel data and formats it for the Master Employee Roster Report
        private void btnEmployeeReport_Click(object sender, EventArgs e)
        {
            List<Employee> employees = CentralData.GetEmployeesFromDatabase();
            StringBuilder rows = new StringBuilder();

            string headers = "<th>ID</th><th>Full Name</th><th>Badge Number</th><th>Role</th><th>Skills</th>";

            foreach (var emp in employees)
            {
                rows.AppendLine($"<tr><td>{emp.EmployeeID}</td><td>{emp.FullName}</td><td>{emp.BadgeNumber}</td><td>{emp.Role}</td><td>{emp.Skills}</td></tr>");
            }

            GenerateHtmlReport("Master Employee Roster Report", rows.ToString(), headers);
        }

        // Returns the user to the Main Menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.StartPosition = FormStartPosition.CenterScreen;
            mainMenu.Show();
        }
    }
}