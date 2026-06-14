using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for administrative tasks related to managing employee profiles
    public partial class EmployeeMenuForm : Form
    {
        // Constructor for the administrative employee management menu
        public EmployeeMenuForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Admin: Employee Management";
        }

        // Navigates to the form for adding a new employee to the system
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addForm = new AddEmployeeForm();
            addForm.Show();
        }

        // Navigates to the form for updating existing employee profiles
        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            EditEmployeeForm editForm = new EditEmployeeForm();
            editForm.Show();
            this.Close();
        }

        // Returns the administrator to the main system menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}