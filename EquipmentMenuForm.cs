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

            // Window setup for consistent appearance
            this.Text = "Equipment Checkout System - Equipment Menu";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // UNIVERSAL NAVIGATION METHOD
        // Ensures only ONE form is active at a time (without destroying return path)
        private void NavigateTo(Form nextForm)
        {
            nextForm.StartPosition = FormStartPosition.CenterScreen;
            nextForm.Show();

            // IMPORTANT CHANGE:
            // Do NOT Close() if this form might be returned to
            this.Hide();
        }

        // Navigates to the form for adding new inventory items
        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            NavigateTo(new AddEquipmentForm());
        }

        // Navigates to the form for modifying details of existing equipment
        private void btnEditEquipment_Click(object sender, EventArgs e)
        {
            NavigateTo(new EditEquipmentForm(this));
        }

        // Navigates to the form for permanently removing equipment
        private void btnDecommissionEquipment_Click(object sender, EventArgs e)
        {
            NavigateTo(new DecommissionEquipmentForm(this));
        }

        // Opens equipment tracking dashboard (ADMIN MODE DEFAULT)
        private void btnViewEquipment_Click(object sender, EventArgs e)
        {
            NavigateTo(new TrackEquipmentForm(this)); // SAFE NOW
        }

        // Returns to MAIN MENU (no duplicates created)
        private void btnBack_Click(object sender, EventArgs e)
        {
            NavigateTo(new MainMenuForm());
        }
    }
}