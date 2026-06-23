using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Form responsible for editing existing equipment records in the system
    public partial class EditEquipmentForm : Form
    {
        private EquipmentItem selectedItem;
        private Form parentForm;

        // FIX: unified connection string to avoid AttachDbFilename inconsistencies
        private static string connectionString = CentralData.ConnectionString;

        public EditEquipmentForm(Form parent)
        {
            InitializeComponent();

            this.Text = "Equipment Checkout System - Edit Equipment";
            this.StartPosition = FormStartPosition.CenterScreen;

            parentForm = parent;

            // IMPORTANT: hide parent instead of losing it
            if (parentForm != null && !parentForm.IsDisposed)
            {
                parentForm.Hide();
            }

            PopulateFormOptions();
        }

        private void PopulateFormOptions()
        {
            cmbLocation.Items.Clear();
            cmbLocation.Items.Add("Main Warehouse");
            cmbLocation.Items.Add("Campus Warehouse");

            if (cmbLocation.Items.Count > 0)
                cmbLocation.SelectedIndex = 0;

            clbRequiredSkills.Items.Clear();

            List<string> skills = CentralData.GetSkillsFromDatabase();
            foreach (var skill in skills)
                clbRequiredSkills.Items.Add(skill);

            PopulateEquipmentDropdown();
        }

        private void PopulateEquipmentDropdown()
        {
            cmbSelectEquipment.Items.Clear();

            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();

            foreach (var item in equipment)
                cmbSelectEquipment.Items.Add($"{item.Id}: {item.Name} ({item.Status})");
        }

        private void cmbSelectEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectEquipment.SelectedIndex < 0)
                return;

            string selectedText = cmbSelectEquipment.SelectedItem.ToString();
            string targetID = selectedText.Split(':')[0].Trim();

            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
            selectedItem = equipment.FirstOrDefault(eq => eq.Id == targetID);

            if (selectedItem == null)
                return;

            txtEquipmentName.Text = selectedItem.Name;
            txtModel.Text = selectedItem.Model;

            cmbLocation.SelectedItem = selectedItem.Location;

            for (int i = 0; i < clbRequiredSkills.Items.Count; i++)
                clbRequiredSkills.SetItemChecked(i, false);

            string[] skills = (selectedItem.RequiredSkill ?? "")
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < clbRequiredSkills.Items.Count; i++)
            {
                string skillName = clbRequiredSkills.Items[i].ToString();

                if (skills.Contains(skillName))
                    clbRequiredSkills.SetItemChecked(i, true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Please select an equipment item to edit.");
                return;
            }

            string updatedName = txtEquipmentName.Text.Trim();
            string updatedModel = txtModel.Text.Trim();
            string updatedLocation = cmbLocation.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(updatedName) || string.IsNullOrWhiteSpace(updatedModel))
            {
                MessageBox.Show("Name and Model cannot be empty.");
                return;
            }

            string updatedSkill = "Standard";

            if (clbRequiredSkills.CheckedItems.Count > 0)
            {
                List<string> selectedSkills = new List<string>();

                foreach (var item in clbRequiredSkills.CheckedItems)
                    selectedSkills.Add(item.ToString());

                updatedSkill = string.Join(",", selectedSkills);
            }

            string query = @"
                UPDATE Equipment 
                SET EquipmentName = @Name,
                    Model = @Model,
                    RequiredSkill = @Skill,
                    Location = @Location
                WHERE EquipmentID = @ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", updatedName);
                    cmd.Parameters.AddWithValue("@Model", updatedModel);
                    cmd.Parameters.AddWithValue("@Skill", updatedSkill);
                    cmd.Parameters.AddWithValue("@Location", updatedLocation ?? "Main Warehouse");
                    cmd.Parameters.AddWithValue("@ID", selectedItem.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Equipment updated successfully!");
                PopulateEquipmentDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating equipment: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            if (parentForm != null && !parentForm.IsDisposed)
            {
                parentForm.StartPosition = FormStartPosition.CenterScreen;
                parentForm.Show();
            }
        }
    }
}