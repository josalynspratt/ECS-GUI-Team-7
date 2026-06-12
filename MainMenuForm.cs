using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Admin Control Panel";
        }

        private void btnEquipmentManagement_Click(object sender, EventArgs e)
        {
            EquipmentMenuForm equipMenu = new EquipmentMenuForm();
            equipMenu.Show();
            this.Hide();
        }

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            EmployeeMenuForm empMenu = new EmployeeMenuForm();
            empMenu.Show();
            this.Hide();
        }

        private void btnViewRequests_Click(object sender, EventArgs e)
        {
            ViewRequestsForm checkoutRequests = new ViewRequestsForm();
            checkoutRequests.Show();
            this.Hide();
        }

        private void btnCheckInEquipment_Click(object sender, EventArgs e)
        {
            CheckInEquipmentForm checkInScreen = new CheckInEquipmentForm();
            checkInScreen.Show();
            this.Hide();
        }

        private void btnSystemReports_Click(object sender, EventArgs e)
        {
            ReportsMenuForm reportsMenu = new ReportsMenuForm();
            reportsMenu.Show();
            this.Hide();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginScreen = new Login();
            loginScreen.Show();
            this.Close();
        }
    }
}