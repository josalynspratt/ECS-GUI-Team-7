using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for administrative tasks related to managing employee profiles
    public partial class EmployeeMenuForm : Form
    {
        public EmployeeMenuForm()
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Employee Management";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // UNIVERSAL NAVIGATION METHOD
        private void NavigateTo(Form nextForm)
        {
            nextForm.StartPosition = FormStartPosition.CenterScreen;
            nextForm.Show();

            this.Close();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            NavigateTo(new AddEmployeeForm());
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            NavigateTo(new EditEmployeeForm());
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            NavigateTo(new RemoveEmployeeForm());
        }

        private void btnViewRoster_Click(object sender, EventArgs e)
        {
            NavigateTo(new SearchEmployeesForm());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            NavigateTo(new MainMenuForm());
        }
    }
}