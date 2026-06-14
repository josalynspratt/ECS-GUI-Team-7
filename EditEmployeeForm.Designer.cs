namespace ECS_GUI
{
    partial class EditEmployeeForm
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
            cmbSelectEmployee = new ComboBox();
            cmbRole = new ComboBox();
            lblSelectEmployee = new Label();
            lblRole = new Label();
            txtEmployeeName = new TextBox();
            lblEmployeeName = new Label();
            lblBadgeNumber = new Label();
            txtBadgeNumber = new TextBox();
            clbSkillLevels = new CheckedListBox();
            btnSaveUpdates = new Button();
            btnBack = new Button();
            lblSkillLevels = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(327, 27);
            label1.Name = "label1";
            label1.Size = new Size(147, 28);
            label1.TabIndex = 1;
            label1.Text = "Edit Employee";
            // 
            // cmbSelectEmployee
            // 
            cmbSelectEmployee.Cursor = Cursors.Hand;
            cmbSelectEmployee.Font = new Font("Segoe UI", 10F);
            cmbSelectEmployee.FormattingEnabled = true;
            cmbSelectEmployee.Location = new Point(369, 78);
            cmbSelectEmployee.Name = "cmbSelectEmployee";
            cmbSelectEmployee.Size = new Size(192, 25);
            cmbSelectEmployee.TabIndex = 2;
            cmbSelectEmployee.SelectedIndexChanged += cmbSelectEmployee_SelectedIndexChanged_1;
            // 
            // cmbRole
            // 
            cmbRole.Cursor = Cursors.Hand;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(369, 211);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(192, 25);
            cmbRole.TabIndex = 3;
            // 
            // lblSelectEmployee
            // 
            lblSelectEmployee.AutoSize = true;
            lblSelectEmployee.Font = new Font("Segoe UI", 10F);
            lblSelectEmployee.Location = new Point(240, 81);
            lblSelectEmployee.Name = "lblSelectEmployee";
            lblSelectEmployee.Size = new Size(110, 19);
            lblSelectEmployee.TabIndex = 4;
            lblSelectEmployee.Text = "Select Employee:";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(312, 214);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(38, 19);
            lblRole.TabIndex = 5;
            lblRole.Text = "Role:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Cursor = Cursors.IBeam;
            txtEmployeeName.Font = new Font("Segoe UI", 10F);
            txtEmployeeName.Location = new Point(369, 125);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(192, 25);
            txtEmployeeName.TabIndex = 6;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 10F);
            lblEmployeeName.Location = new Point(239, 128);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(111, 19);
            lblEmployeeName.TabIndex = 7;
            lblEmployeeName.Text = "Employee Name:";
            // 
            // lblBadgeNumber
            // 
            lblBadgeNumber.AutoSize = true;
            lblBadgeNumber.Font = new Font("Segoe UI", 10F);
            lblBadgeNumber.Location = new Point(246, 172);
            lblBadgeNumber.Name = "lblBadgeNumber";
            lblBadgeNumber.Size = new Size(104, 19);
            lblBadgeNumber.TabIndex = 9;
            lblBadgeNumber.Text = "Badge Number:";
            lblBadgeNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBadgeNumber
            // 
            txtBadgeNumber.Cursor = Cursors.IBeam;
            txtBadgeNumber.Font = new Font("Segoe UI", 10F);
            txtBadgeNumber.Location = new Point(369, 170);
            txtBadgeNumber.Name = "txtBadgeNumber";
            txtBadgeNumber.Size = new Size(192, 25);
            txtBadgeNumber.TabIndex = 8;
            // 
            // clbSkillLevels
            // 
            clbSkillLevels.Font = new Font("Segoe UI", 10F);
            clbSkillLevels.FormattingEnabled = true;
            clbSkillLevels.Location = new Point(369, 259);
            clbSkillLevels.Name = "clbSkillLevels";
            clbSkillLevels.Size = new Size(192, 84);
            clbSkillLevels.TabIndex = 10;
            // 
            // btnSaveUpdates
            // 
            btnSaveUpdates.BackColor = SystemColors.GradientActiveCaption;
            btnSaveUpdates.Cursor = Cursors.Hand;
            btnSaveUpdates.Font = new Font("Segoe UI", 10F);
            btnSaveUpdates.Location = new Point(433, 373);
            btnSaveUpdates.Name = "btnSaveUpdates";
            btnSaveUpdates.Size = new Size(145, 45);
            btnSaveUpdates.TabIndex = 11;
            btnSaveUpdates.Text = "Save Updates";
            btnSaveUpdates.UseVisualStyleBackColor = false;
            btnSaveUpdates.Click += btnSaveUpdates_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(222, 373);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 12;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblSkillLevels
            // 
            lblSkillLevels.AutoSize = true;
            lblSkillLevels.Font = new Font("Segoe UI", 10F);
            lblSkillLevels.Location = new Point(246, 259);
            lblSkillLevels.Name = "lblSkillLevels";
            lblSkillLevels.Size = new Size(76, 19);
            lblSkillLevels.TabIndex = 13;
            lblSkillLevels.Text = "Skill Levels:";
            lblSkillLevels.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSkillLevels);
            Controls.Add(btnBack);
            Controls.Add(btnSaveUpdates);
            Controls.Add(clbSkillLevels);
            Controls.Add(lblBadgeNumber);
            Controls.Add(txtBadgeNumber);
            Controls.Add(lblEmployeeName);
            Controls.Add(txtEmployeeName);
            Controls.Add(lblRole);
            Controls.Add(lblSelectEmployee);
            Controls.Add(cmbRole);
            Controls.Add(cmbSelectEmployee);
            Controls.Add(label1);
            Name = "EditEmployeeForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbSelectEmployee;
        private ComboBox cmbRole;
        private Label lblSelectEmployee;
        private Label lblRole;
        private TextBox txtEmployeeName;
        private Label lblEmployeeName;
        private Label lblBadgeNumber;
        private TextBox txtBadgeNumber;
        private CheckedListBox clbSkillLevels;
        private Button btnSaveUpdates;
        private Button btnBack;
        private Label lblSkillLevels;
    }
}