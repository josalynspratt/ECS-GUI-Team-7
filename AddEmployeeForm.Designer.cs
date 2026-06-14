namespace ECS_GUI
{
    partial class AddEmployeeForm
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
            txtEmployeeID = new TextBox();
            lblEmployeeID = new Label();
            txtEmployeeName = new TextBox();
            lblEmployeeName = new Label();
            txtBadgeNumber = new TextBox();
            lblBadgeNumber = new Label();
            cmbRole = new ComboBox();
            lblRole = new Label();
            lblSkillLevel = new Label();
            btnSaveEmployee = new Button();
            btnBack = new Button();
            clbSkillLevels = new CheckedListBox();
            lblAddEmployee = new Label();
            SuspendLayout();
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Cursor = Cursors.IBeam;
            txtEmployeeID.Font = new Font("Segoe UI", 10F);
            txtEmployeeID.Location = new Point(374, 68);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(100, 25);
            txtEmployeeID.TabIndex = 0;
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.AutoSize = true;
            lblEmployeeID.Font = new Font("Segoe UI", 10F);
            lblEmployeeID.Location = new Point(252, 74);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(89, 19);
            lblEmployeeID.TabIndex = 1;
            lblEmployeeID.Text = "Employee ID:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Cursor = Cursors.IBeam;
            txtEmployeeName.Font = new Font("Segoe UI", 10F);
            txtEmployeeName.Location = new Point(374, 107);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(100, 25);
            txtEmployeeName.TabIndex = 2;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 10F);
            lblEmployeeName.Location = new Point(230, 110);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(111, 19);
            lblEmployeeName.TabIndex = 3;
            lblEmployeeName.Text = "Employee Name:";
            // 
            // txtBadgeNumber
            // 
            txtBadgeNumber.Cursor = Cursors.IBeam;
            txtBadgeNumber.Font = new Font("Segoe UI", 10F);
            txtBadgeNumber.Location = new Point(374, 140);
            txtBadgeNumber.Name = "txtBadgeNumber";
            txtBadgeNumber.Size = new Size(100, 25);
            txtBadgeNumber.TabIndex = 4;
            // 
            // lblBadgeNumber
            // 
            lblBadgeNumber.AutoSize = true;
            lblBadgeNumber.Font = new Font("Segoe UI", 10F);
            lblBadgeNumber.Location = new Point(237, 146);
            lblBadgeNumber.Name = "lblBadgeNumber";
            lblBadgeNumber.Size = new Size(104, 19);
            lblBadgeNumber.TabIndex = 5;
            lblBadgeNumber.Text = "Badge Number:";
            // 
            // cmbRole
            // 
            cmbRole.Cursor = Cursors.Hand;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(373, 179);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(121, 25);
            cmbRole.TabIndex = 6;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(303, 182);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(38, 19);
            lblRole.TabIndex = 7;
            lblRole.Text = "Role:";
            // 
            // lblSkillLevel
            // 
            lblSkillLevel.AutoSize = true;
            lblSkillLevel.Font = new Font("Segoe UI", 10F);
            lblSkillLevel.Location = new Point(271, 218);
            lblSkillLevel.Name = "lblSkillLevel";
            lblSkillLevel.Size = new Size(70, 19);
            lblSkillLevel.TabIndex = 9;
            lblSkillLevel.Text = "Skill Level:";
            // 
            // btnSaveEmployee
            // 
            btnSaveEmployee.BackColor = SystemColors.GradientActiveCaption;
            btnSaveEmployee.Cursor = Cursors.Hand;
            btnSaveEmployee.Font = new Font("Segoe UI", 10F);
            btnSaveEmployee.Location = new Point(416, 348);
            btnSaveEmployee.Name = "btnSaveEmployee";
            btnSaveEmployee.Size = new Size(145, 60);
            btnSaveEmployee.TabIndex = 10;
            btnSaveEmployee.Text = "Save Employee Profile";
            btnSaveEmployee.UseVisualStyleBackColor = false;
            btnSaveEmployee.Click += btnSaveEmployee_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(239, 356);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // clbSkillLevels
            // 
            clbSkillLevels.Font = new Font("Segoe UI", 10F);
            clbSkillLevels.FormattingEnabled = true;
            clbSkillLevels.Location = new Point(373, 218);
            clbSkillLevels.Name = "clbSkillLevels";
            clbSkillLevels.Size = new Size(272, 104);
            clbSkillLevels.TabIndex = 12;
            // 
            // lblAddEmployee
            // 
            lblAddEmployee.AutoSize = true;
            lblAddEmployee.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblAddEmployee.ForeColor = SystemColors.Highlight;
            lblAddEmployee.Location = new Point(326, 19);
            lblAddEmployee.Name = "lblAddEmployee";
            lblAddEmployee.Size = new Size(148, 28);
            lblAddEmployee.TabIndex = 13;
            lblAddEmployee.Text = "Add Employee";
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblAddEmployee);
            Controls.Add(clbSkillLevels);
            Controls.Add(btnBack);
            Controls.Add(btnSaveEmployee);
            Controls.Add(lblSkillLevel);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(lblBadgeNumber);
            Controls.Add(txtBadgeNumber);
            Controls.Add(lblEmployeeName);
            Controls.Add(txtEmployeeName);
            Controls.Add(lblEmployeeID);
            Controls.Add(txtEmployeeID);
            Name = "AddEmployeeForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmployeeID;
        private Label lblEmployeeID;
        private TextBox txtEmployeeName;
        private Label lblEmployeeName;
        private TextBox txtBadgeNumber;
        private Label lblBadgeNumber;
        private ComboBox cmbRole;
        private Label lblRole;
        private Label lblSkillLevel;
        private Button btnSaveEmployee;
        private Button btnBack;
        private CheckedListBox clbSkillLevels;
        private Label lblAddEmployee;
    }
}