using System;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class EquipmentMenuForm : Form
    {
        public EquipmentMenuForm()
        {
            InitializeComponent();
            this.Text = "ECS - Equipment Management";
        }

        private void btnViewEquipment_Click(object sender, EventArgs e)
        {
            TrackEquipmentForm trackForm = new TrackEquipmentForm();
            trackForm.Show();
            this.Close();
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            AddEquipmentForm addForm = new AddEquipmentForm();
            addForm.Show();
            this.Close();
        }

        private void btnEditEquipment_Click(object sender, EventArgs e)
        {
            EditEquipmentForm editForm = new EditEquipmentForm();
            editForm.Show();
            this.Close();
        }

        private void btnDecommission_Click(object sender, EventArgs e)
        {
            DecommissionEquipmentForm decomForm = new DecommissionEquipmentForm();
            decomForm.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}