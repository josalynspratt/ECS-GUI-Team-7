using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ECS_GUI
{
    public partial class AddEquipmentForm : Form
    {
        // Connection string configured to locate the local database file dynamically in the application directory
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECSDatabase.mdf") + ";Integrated Security=True";

        public AddEquipmentForm()
        {
            InitializeComponent();
            this.Text = "Equipment Checkout System - Add Equipment";
            // Register load event to initialize dropdowns
            this.Load += AddEquipmentForm_Load;
        }

        private void AddEquipmentForm_Load(object sender, EventArgs e)
        {
            PopulateSkillDropdown();
            PopulateLocationDropdown();
        }

        // Populates the required skill dropdown from the centralized database
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

        // Populates the warehouse location dropdown with available options
        private void PopulateLocationDropdown()
        {
            cmbLocation.Items.Clear();
            cmbLocation.Items.Add("Main Warehouse");
            cmbLocation.Items.Add("Campus Warehouse");
            if (cmbLocation.Items.Count > 0)
            {
                cmbLocation.SelectedIndex = 0;
            }
        }

        private void btnSaveEquipment_Click(object sender, EventArgs e)
        {
            // Capture user input from the form
            string eqName = txtEquipmentName.Text.Trim();
            string eqModel = txtModel.Text.Trim();
            string reqSkill = cmbRequiredSkill.SelectedItem?.ToString();
            string location = cmbLocation.SelectedItem?.ToString();

            // Perform input validation for required fields
            if (string.IsNullOrEmpty(eqName) || string.IsNullOrEmpty(eqModel))
            {
                MessageBox.Show("Please enter an equipment name and model description.");
                return;
            }

            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please select a warehouse location.");
                return;
            }

            // Determine the next asset ID by finding the maximum current ID and incrementing
            int nextNumericId = 1;
            List<EquipmentItem> items = CentralData.GetEquipmentFromDatabase();
            if (items.Count > 0)
            {
                var numericIds = items.Select(eq => int.TryParse(eq.Id, out int parseResult) ? parseResult : 0);
                nextNumericId = numericIds.Max() + 1;
            }

            // SQL insert query utilizing parameters to ensure data security
            string query = "INSERT INTO Equipment (EquipmentID, EquipmentName, Model, RequiredSkill, Status, Location) VALUES (@ID, @Name, @Model, @Skill, @Status, @Location)";

            try
            {
                // Execute the database insert operation
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", nextNumericId);
                    cmd.Parameters.AddWithValue("@Name", eqName);
                    cmd.Parameters.AddWithValue("@Model", eqModel);
                    cmd.Parameters.AddWithValue("@Skill", reqSkill ?? "Standard");
                    cmd.Parameters.AddWithValue("@Status", "Available"); // Default status upon creation
                    cmd.Parameters.AddWithValue("@Location", location);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"{eqName} has been successfully added with Asset ID: {nextNumericId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Return to the inventory management dashboard
            }
            catch (Exception ex)
            {
                // Handle potential database connection or constraint errors
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}