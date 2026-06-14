using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    // The central hub for administrators, providing access to all management modules
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Admin Control Panel";
        }

        // Navigates to the inventory management module
        private void btnEquipmentManagement_Click(object sender, EventArgs e)
        {
            EquipmentMenuForm equipMenu = new EquipmentMenuForm();
            equipMenu.Show();
            this.Hide();
        }

        // Navigates to the personnel management module
        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            EmployeeMenuForm empMenu = new EmployeeMenuForm();
            empMenu.Show();
            this.Hide();
        }

        // Opens the dashboard to view and process pending checkout requests
        private void btnViewRequests_Click(object sender, EventArgs e)
        {
            ViewRequestsForm checkoutRequests = new ViewRequestsForm();
            checkoutRequests.Show();
            this.Hide();
        }

        // Accesses the return asset module to process incoming equipment check-ins
        private void btnCheckInEquipment_Click(object sender, EventArgs e)
        {
            CheckInEquipmentForm checkInScreen = new CheckInEquipmentForm();
            checkInScreen.Show();
            this.Hide();
        }

        // Navigates to the system reporting dashboard
        private void btnSystemReports_Click(object sender, EventArgs e)
        {
            ReportsMenuForm reportsMenu = new ReportsMenuForm();
            reportsMenu.Show();
            this.Hide();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
        }

        // Terminates the admin session and returns to the login screen
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginScreen = new Login();
            loginScreen.Show();
            this.Close();
        }
    }
}