using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for providing administrators access to equipment management tasks
    public partial class EquipmentMenuForm : Form
    {
        public EquipmentMenuForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Equipment Menu";
        }

        // Navigates to the form for adding new inventory items
        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            AddEquipmentForm addForm = new AddEquipmentForm();
            addForm.Show();
        }

        // Navigates to the form for modifying details of existing equipment
        private void btnEditEquipment_Click(object sender, EventArgs e)
        {
            EditEquipmentForm editForm = new EditEquipmentForm();
            editForm.Show();
            this.Close();
        }

        // Navigates to the form for permanently removing equipment from the active database
        private void btnDecommissionEquipment_Click(object sender, EventArgs e)
        {
            DecommissionEquipmentForm decommForm = new DecommissionEquipmentForm();
            decommForm.Show();
            this.Close();
        }

        // Returns the administrator to the main system navigation
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}