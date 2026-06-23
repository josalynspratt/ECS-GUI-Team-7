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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // UNIVERSAL NAVIGATION METHOD
        private void NavigateTo(Form nextForm)
        {
            nextForm.StartPosition = FormStartPosition.CenterScreen;
            nextForm.Show();
            this.Close();
        }

        private void btnEquipmentManagement_Click(object sender, EventArgs e)
        {
            NavigateTo(new EquipmentMenuForm());
        }

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            NavigateTo(new EmployeeMenuForm());
        }

        private void btnViewRequests_Click(object sender, EventArgs e)
        {
            NavigateTo(new ViewRequestsForm());
        }

        private void btnCheckInEquipment_Click(object sender, EventArgs e)
        {
            NavigateTo(new CheckInEquipmentForm());
        }

        private void btnSystemReports_Click(object sender, EventArgs e)
        {
            NavigateTo(new ReportsMenuForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            NavigateTo(new Login());
        }
    }
}