using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class EmployeeDashboardForm : Form
    {
        private string loggedInID;

        public EmployeeDashboardForm(string employeeID = "Unknown")
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Employee Menu";
            this.loggedInID = employeeID;
        }

        private void btnViewEquipment_Click(object sender, EventArgs e)
        {
            TrackEquipmentForm trackForm = new TrackEquipmentForm("Employee");
            trackForm.Show();
            this.Close();
        }

        private void btnRequestCheckout_Click(object sender, EventArgs e)
        {
            RequestCheckoutForm requestForm = new RequestCheckoutForm(this.loggedInID);
            requestForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
    }
}