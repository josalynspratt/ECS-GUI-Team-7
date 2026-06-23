using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for authenticating users and routing them to their respective dashboards
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Login";
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputID = txtEmployeeID.Text.Trim();
            string inputBadge = txtBadgeNumber.Text.Trim();

            // Hardcoded administrator bypass for emergency access
            if (inputID.Equals("99999") && inputBadge.Equals("B999", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Success! Welcome Admin.");
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                try
                {
                    // Fetch all employees to validate credentials against the database
                    List<Employee> employees = CentralData.GetEmployeesFromDatabase();

                    Employee loggedInUser = employees.FirstOrDefault(emp =>
                        emp.EmployeeID == inputID &&
                        emp.BadgeNumber.Equals(inputBadge, StringComparison.OrdinalIgnoreCase));

                    if (loggedInUser != null)
                    {
                        // Role-based routing
                        if (loggedInUser.Role != null &&
                            loggedInUser.Role.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"Success! Welcome {loggedInUser.FullName}.");
                            MainMenuForm mainMenu = new MainMenuForm();
                            mainMenu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Success! Welcome back {loggedInUser.FullName}.");
                            EmployeeDashboardForm employeeDashboard =
                                new EmployeeDashboardForm(loggedInUser.EmployeeID);

                            employeeDashboard.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Employee ID or Badge Number. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }
    }
}