namespace ECS_GUI
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnSystemReports = new Button();
            btnLogOut = new Button();
            btnViewRequests = new Button();
            btnCheckInEquipment = new Button();
            btnEquipmentManagement = new Button();
            btnEmployeeManagement = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(340, 39);
            label1.Name = "label1";
            label1.Size = new Size(120, 28);
            label1.TabIndex = 0;
            label1.Text = "Main Menu";
            // 
            // btnSystemReports
            // 
            btnSystemReports.BackColor = SystemColors.GradientActiveCaption;
            btnSystemReports.Cursor = Cursors.Hand;
            btnSystemReports.Font = new Font("Segoe UI", 10F);
            btnSystemReports.Location = new Point(253, 289);
            btnSystemReports.Name = "btnSystemReports";
            btnSystemReports.Size = new Size(271, 47);
            btnSystemReports.TabIndex = 3;
            btnSystemReports.Text = "System Reports Dashboard";
            btnSystemReports.UseVisualStyleBackColor = false;
            btnSystemReports.Click += btnSystemReports_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.Red;
            btnLogOut.Cursor = Cursors.Hand;
            btnLogOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogOut.Location = new Point(350, 381);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(100, 40);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogout_Click;
            // 
            // btnViewRequests
            // 
            btnViewRequests.BackColor = SystemColors.GradientActiveCaption;
            btnViewRequests.Cursor = Cursors.Hand;
            btnViewRequests.Font = new Font("Segoe UI", 10F);
            btnViewRequests.Location = new Point(136, 195);
            btnViewRequests.Name = "btnViewRequests";
            btnViewRequests.Size = new Size(193, 47);
            btnViewRequests.TabIndex = 5;
            btnViewRequests.Text = "View Checkout Requests";
            btnViewRequests.UseVisualStyleBackColor = false;
            btnViewRequests.Click += btnViewRequests_Click;
            // 
            // btnCheckInEquipment
            // 
            btnCheckInEquipment.BackColor = SystemColors.GradientActiveCaption;
            btnCheckInEquipment.Cursor = Cursors.Hand;
            btnCheckInEquipment.Font = new Font("Segoe UI", 10F);
            btnCheckInEquipment.Location = new Point(472, 195);
            btnCheckInEquipment.Name = "btnCheckInEquipment";
            btnCheckInEquipment.Size = new Size(193, 47);
            btnCheckInEquipment.TabIndex = 9;
            btnCheckInEquipment.Text = "Check In Equipment";
            btnCheckInEquipment.UseVisualStyleBackColor = false;
            btnCheckInEquipment.Click += btnCheckInEquipment_Click;
            // 
            // btnEquipmentManagement
            // 
            btnEquipmentManagement.BackColor = SystemColors.GradientActiveCaption;
            btnEquipmentManagement.Cursor = Cursors.Hand;
            btnEquipmentManagement.Font = new Font("Segoe UI", 10F);
            btnEquipmentManagement.Location = new Point(136, 101);
            btnEquipmentManagement.Name = "btnEquipmentManagement";
            btnEquipmentManagement.Size = new Size(193, 47);
            btnEquipmentManagement.TabIndex = 10;
            btnEquipmentManagement.Text = "Equipment Information";
            btnEquipmentManagement.UseVisualStyleBackColor = false;
            btnEquipmentManagement.Click += btnEquipmentManagement_Click;
            // 
            // btnEmployeeManagement
            // 
            btnEmployeeManagement.BackColor = SystemColors.GradientActiveCaption;
            btnEmployeeManagement.Cursor = Cursors.Hand;
            btnEmployeeManagement.Font = new Font("Segoe UI", 10F);
            btnEmployeeManagement.Location = new Point(472, 101);
            btnEmployeeManagement.Name = "btnEmployeeManagement";
            btnEmployeeManagement.Size = new Size(193, 47);
            btnEmployeeManagement.TabIndex = 11;
            btnEmployeeManagement.Text = "Employee Information";
            btnEmployeeManagement.UseVisualStyleBackColor = false;
            btnEmployeeManagement.Click += btnEmployeeManagement_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEmployeeManagement);
            Controls.Add(btnEquipmentManagement);
            Controls.Add(btnCheckInEquipment);
            Controls.Add(btnViewRequests);
            Controls.Add(btnLogOut);
            Controls.Add(btnSystemReports);
            Controls.Add(label1);
            Name = "MainMenuForm";
            Text = "Equipment Checkout System";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSystemReports;
        private Button btnLogOut;
        private Button btnViewRequests;
        private Button btnCheckInEquipment;
        private Button btnEquipmentManagement;
        private Button btnEmployeeManagement;
    }
}