using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for providing employees access to checkout and tracking features
    public partial class EmployeeDashboardForm : Form
    {
        private string loggedInID;

        // Constructor receives the logged-in employee ID to maintain session context
        public EmployeeDashboardForm(string employeeID = "Unknown")
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Employee Menu";
            this.loggedInID = employeeID;
        }

        // Navigates to the equipment tracking form in 'Employee' viewing mode
        private void btnViewEquipment_Click(object sender, EventArgs e)
        {
            TrackEquipmentForm trackForm = new TrackEquipmentForm("Employee");
            trackForm.Show();
            this.Close();
        }

        // Navigates to the checkout request form, passing the current session ID
        private void btnRequestCheckout_Click(object sender, EventArgs e)
        {
            RequestCheckoutForm requestForm = new RequestCheckoutForm(this.loggedInID);
            requestForm.Show();
            this.Close();
        }

        // Terminates the current session and returns to the login screen
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
    }
}