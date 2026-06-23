using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for adding new equipment and new skill levels to the system
    public partial class AddEquipmentForm : Form
    {
        public AddEquipmentForm()
        {
            InitializeComponent();

            // Set the window title displayed in the title bar
            this.Text = "Equipment Checkout System - Add Equipment";
            this.StartPosition = FormStartPosition.CenterScreen;
            // Load dropdown data when the form opens
            this.Load += AddEquipmentForm_Load;
        }

        // Initializes all dropdown controls when the form loads
        private void AddEquipmentForm_Load(object sender, EventArgs e)
        {
            PopulateSkillDropdown();
            PopulateLocationDropdown();
        }

        // Loads all available skills from the database into the Required Skill dropdown
        private void PopulateSkillDropdown()
        {
            cmbRequiredSkill.Items.Clear();

            List<string> skills = CentralData.GetSkillsFromDatabase();

            foreach (var skill in skills)
            {
                cmbRequiredSkill.Items.Add(skill);
            }

            if (cmbRequiredSkill.Items.Count > 0)
            {
                cmbRequiredSkill.SelectedIndex = 0;
            }
        }

        // Populates the available equipment storage locations
        private void PopulateLocationDropdown()
        {
            cmbLocation.Items.Clear();

            cmbLocation.Items.Add("Main Warehouse");
            cmbLocation.Items.Add("Campus Warehouse");

            cmbLocation.SelectedIndex = 0;
        }

        // Saves a new equipment record to the database
        private void btnSaveEquipment_Click(object sender, EventArgs e)
        {
            // Collect information entered by the administrator
            string name = txtEquipmentName.Text.Trim();
            string model = txtModel.Text.Trim();
            string skill = cmbRequiredSkill.SelectedItem?.ToString();
            string location = cmbLocation.SelectedItem?.ToString();

            // Validate required fields
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(model))
            {
                MessageBox.Show("Enter equipment name and model.");
                return;
            }

            // Generate the next available Equipment ID
            int nextId = 1;

            List<EquipmentItem> items = CentralData.GetEquipmentFromDatabase();

            if (items.Count > 0)
            {
                nextId = items.Max(x => int.TryParse(x.Id, out int value) ? value : 0) + 1;
            }

            // Save the equipment to the database
            CentralData.AddEquipment(
                name,
                model,
                skill ?? "Standard",
                location,
                nextId);

            // Notify the administrator that the save was successful
            MessageBox.Show($"{name} added successfully with ID {nextId}");

            // Clear the form so another piece of equipment can be entered
            txtEquipmentName.Clear();
            txtModel.Clear();

            if (cmbRequiredSkill.Items.Count > 0)
                cmbRequiredSkill.SelectedIndex = 0;

            cmbLocation.SelectedIndex = 0;

            // Return focus to the Equipment Name field
            txtEquipmentName.Focus();
        }

        // Adds a new skill level to the database
        private void btnAddSkillLevel_Click(object sender, EventArgs e)
        {
            // Retrieve the new skill entered by the administrator
            string skillName = txtNewSkillLevel.Text.Trim();

            // Validate that a skill name was entered
            if (string.IsNullOrWhiteSpace(skillName))
            {
                MessageBox.Show("Enter skill name.");
                return;
            }

            try
            {
                // Save the new skill
                CentralData.AddSkill(skillName);

                MessageBox.Show("Skill added successfully!");

                // Clear the skill entry field
                txtNewSkillLevel.Clear();

                // Refresh the Required Skill dropdown so the new skill is immediately available
                PopulateSkillDropdown();

                // Return focus to the skill textbox
                txtNewSkillLevel.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        // Returns the administrator to the Equipment Management Menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            EquipmentMenuForm equipmentMenu = new EquipmentMenuForm();
            equipmentMenu.StartPosition = FormStartPosition.CenterScreen;
            equipmentMenu.Show();

            this.Close();
        }
    }
}