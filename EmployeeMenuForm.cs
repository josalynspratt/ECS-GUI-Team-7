using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class EmployeeMenuForm : Form
    {
        public EmployeeMenuForm()
        {
            InitializeComponent();
            this.Text = "ECS - Employee Management";
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmpForm = new AddEmployeeForm();
            addEmpForm.Show();
            this.Close();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            EditEmployeeForm editEmpForm = new EditEmployeeForm();
            editEmpForm.Show();
            this.Close();
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            RemoveEmployeeForm removeEmpForm = new RemoveEmployeeForm();
            removeEmpForm.Show();
            this.Close();
        }

        private void btnViewRoster_Click(object sender, EventArgs e)
        {
            SearchEmployeesForm searchForm = new SearchEmployeesForm();
            searchForm.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }

        private void EmployeeMenuForm_Load(object sender, EventArgs e)
        {
        }
    }
}