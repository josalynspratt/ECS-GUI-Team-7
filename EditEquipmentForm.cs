using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class EditEquipmentForm : Form
    {
        private EquipmentItem selectedItem;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public EditEquipmentForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Edit Equipment";
            PopulateFormOptions();
        }

        private void PopulateFormOptions()
        {
            cmbLocation.Items.Clear();
            cmbLocation.Items.Add("Main Warehouse");
            cmbLocation.Items.Add("Campus Warehouse");
            if (cmbLocation.Items.Count > 0)
            {
                cmbLocation.SelectedIndex = 0;
            }

            clbRequiredSkills.Items.Clear();
            List<string> skills = CentralData.GetSkillsFromDatabase();
            foreach (var skill in skills)
            {
                clbRequiredSkills.Items.Add(skill);
            }

            PopulateEquipmentDropdown();
        }

        private void PopulateEquipmentDropdown()
        {
            cmbSelectEquipment.Items.Clear();
            List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
            foreach (var item in equipment)
            {
                cmbSelectEquipment.Items.Add($"{item.Id}: {item.Name} ({item.Status})");
            }
        }

        private void cmbSelectEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectEquipment.SelectedIndex >= 0)
            {
                string selectedText = cmbSelectEquipment.SelectedItem.ToString();
                string targetID = selectedText.Split(':')[0].Trim();

                List<EquipmentItem> equipment = CentralData.GetEquipmentFromDatabase();
                selectedItem = equipment.FirstOrDefault(eq => eq.Id == targetID);

                if (selectedItem != null)
                {
                    txtEquipmentName.Text = selectedItem.Name;
                    txtModel.Text = selectedItem.Model;

                    if (cmbLocation.Items.Contains(selectedItem.Location))
                    {
                        cmbLocation.SelectedItem = selectedItem.Location;
                    }

                    for (int i = 0; i < clbRequiredSkills.Items.Count; i++)
                    {
                        clbRequiredSkills.SetItemChecked(i, clbRequiredSkills.Items[i].ToString() == selectedItem.RequiredSkill);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Please select an equipment item to edit.", "Selection Error");
                return;
            }

            string updatedName = txtEquipmentName.Text.Trim();
            string updatedModel = txtModel.Text.Trim();
            string updatedLocation = cmbLocation.SelectedItem?.ToString();

            string updatedSkill = "Standard";
            if (clbRequiredSkills.CheckedItems.Count > 0)
            {
                updatedSkill = clbRequiredSkills.CheckedItems[0].ToString();
            }

            if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedModel))
            {
                MessageBox.Show("Name and Model fields cannot be empty.", "Validation Error");
                return;
            }

            string query = "UPDATE Equipment SET EquipmentName = @Name, Model = @Model, RequiredSkill = @Skill, Location = @Location WHERE EquipmentID = @ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", updatedName);
                        cmd.Parameters.AddWithValue("@Model", updatedModel);
                        cmd.Parameters.AddWithValue("@Skill", updatedSkill);
                        cmd.Parameters.AddWithValue("@Location", updatedLocation);
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(selectedItem.Id));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Equipment details updated successfully!", "Success");
                PopulateEquipmentDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating equipment: {ex.Message}", "Database Error");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}