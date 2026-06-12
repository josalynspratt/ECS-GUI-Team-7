namespace ECS_GUI
{
    partial class AddEquipmentForm
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
            ComboBox cmbLocation;
            txtEquipmentName = new TextBox();
            cmbRequiredSkill = new ComboBox();
            btnSaveEquipment = new Button();
            btnBack = new Button();
            lblEquipmentName = new Label();
            lblAddEquipment = new Label();
            lblSkillLevel = new Label();
            lblNewSkillLevel = new Label();
            txtNewSkillLevel = new TextBox();
            btnAddSkillLevel = new Button();
            lblLocation = new Label();
            label1 = new Label();
            txtModel = new TextBox();
            cmbLocation = new ComboBox();
            SuspendLayout();
            // 
            // txtEquipmentName
            // 
            txtEquipmentName.Cursor = Cursors.IBeam;
            txtEquipmentName.Font = new Font("Segoe UI", 10F);
            txtEquipmentName.Location = new Point(293, 87);
            txtEquipmentName.Multiline = true;
            txtEquipmentName.Name = "txtEquipmentName";
            txtEquipmentName.Size = new Size(276, 25);
            txtEquipmentName.TabIndex = 0;
            // 
            // cmbRequiredSkill
            // 
            cmbRequiredSkill.Cursor = Cursors.Hand;
            cmbRequiredSkill.Font = new Font("Segoe UI", 10F);
            cmbRequiredSkill.FormattingEnabled = true;
            cmbRequiredSkill.Location = new Point(293, 173);
            cmbRequiredSkill.Name = "cmbRequiredSkill";
            cmbRequiredSkill.Size = new Size(276, 25);
            cmbRequiredSkill.TabIndex = 1;
            // 
            // btnSaveEquipment
            // 
            btnSaveEquipment.BackColor = SystemColors.GradientActiveCaption;
            btnSaveEquipment.Cursor = Cursors.Hand;
            btnSaveEquipment.Font = new Font("Segoe UI", 10F);
            btnSaveEquipment.Location = new Point(350, 279);
            btnSaveEquipment.Name = "btnSaveEquipment";
            btnSaveEquipment.Size = new Size(100, 45);
            btnSaveEquipment.TabIndex = 2;
            btnSaveEquipment.Text = "Save";
            btnSaveEquipment.UseVisualStyleBackColor = false;
            btnSaveEquipment.Click += btnSaveEquipment_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(321, 376);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // lblEquipmentName
            // 
            lblEquipmentName.AutoSize = true;
            lblEquipmentName.Font = new Font("Segoe UI", 10F);
            lblEquipmentName.Location = new Point(158, 90);
            lblEquipmentName.Name = "lblEquipmentName";
            lblEquipmentName.Size = new Size(118, 19);
            lblEquipmentName.TabIndex = 4;
            lblEquipmentName.Text = "Equipment Name:";
            // 
            // lblAddEquipment
            // 
            lblAddEquipment.AutoSize = true;
            lblAddEquipment.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblAddEquipment.ForeColor = SystemColors.Highlight;
            lblAddEquipment.Location = new Point(321, 39);
            lblAddEquipment.Name = "lblAddEquipment";
            lblAddEquipment.Size = new Size(158, 28);
            lblAddEquipment.TabIndex = 7;
            lblAddEquipment.Text = "Add Equipment";
            // 
            // lblSkillLevel
            // 
            lblSkillLevel.AutoSize = true;
            lblSkillLevel.Font = new Font("Segoe UI", 10F);
            lblSkillLevel.Location = new Point(206, 176);
            lblSkillLevel.Name = "lblSkillLevel";
            lblSkillLevel.Size = new Size(70, 19);
            lblSkillLevel.TabIndex = 8;
            lblSkillLevel.Text = "Skill Level:";
            // 
            // lblNewSkillLevel
            // 
            lblNewSkillLevel.AutoSize = true;
            lblNewSkillLevel.Font = new Font("Segoe UI", 10F);
            lblNewSkillLevel.Location = new Point(175, 345);
            lblNewSkillLevel.Name = "lblNewSkillLevel";
            lblNewSkillLevel.Size = new Size(101, 19);
            lblNewSkillLevel.TabIndex = 9;
            lblNewSkillLevel.Text = "New Skill Level:";
            // 
            // txtNewSkillLevel
            // 
            txtNewSkillLevel.Font = new Font("Segoe UI", 10F);
            txtNewSkillLevel.Location = new Point(293, 345);
            txtNewSkillLevel.Name = "txtNewSkillLevel";
            txtNewSkillLevel.Size = new Size(276, 25);
            txtNewSkillLevel.TabIndex = 10;
            // 
            // btnAddSkillLevel
            // 
            btnAddSkillLevel.BackColor = SystemColors.GradientActiveCaption;
            btnAddSkillLevel.Cursor = Cursors.Hand;
            btnAddSkillLevel.Font = new Font("Segoe UI", 10F);
            btnAddSkillLevel.Location = new Point(596, 334);
            btnAddSkillLevel.Name = "btnAddSkillLevel";
            btnAddSkillLevel.Size = new Size(145, 45);
            btnAddSkillLevel.TabIndex = 11;
            btnAddSkillLevel.Text = "Add New Skill Level";
            btnAddSkillLevel.UseVisualStyleBackColor = false;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 10F);
            lblLocation.Location = new Point(206, 219);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(64, 19);
            lblLocation.TabIndex = 13;
            lblLocation.Text = "Location:";
            // 
            // cmbLocation
            // 
            cmbLocation.Cursor = Cursors.Hand;
            cmbLocation.Font = new Font("Segoe UI", 10F);
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(293, 216);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(276, 25);
            cmbLocation.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(225, 133);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 16;
            label1.Text = "Model:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtModel
            // 
            txtModel.Cursor = Cursors.IBeam;
            txtModel.Font = new Font("Segoe UI", 10F);
            txtModel.Location = new Point(293, 131);
            txtModel.Multiline = true;
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(276, 25);
            txtModel.TabIndex = 17;
            // 
            // AddEquipmentForm
            // 
            AcceptButton = btnSaveEquipment;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtModel);
            Controls.Add(label1);
            Controls.Add(cmbLocation);
            Controls.Add(lblLocation);
            Controls.Add(btnAddSkillLevel);
            Controls.Add(txtNewSkillLevel);
            Controls.Add(lblNewSkillLevel);
            Controls.Add(lblSkillLevel);
            Controls.Add(lblAddEquipment);
            Controls.Add(lblEquipmentName);
            Controls.Add(btnBack);
            Controls.Add(btnSaveEquipment);
            Controls.Add(cmbRequiredSkill);
            Controls.Add(txtEquipmentName);
            Cursor = Cursors.IBeam;
            Name = "AddEquipmentForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEquipmentName;
        private ComboBox cmbRequiredSkill;
        private Button btnSaveEquipment;
        private Button btnBack;
        private Label lblEquipmentName;
        private Label lblAddEquipment;
        private Label lblSkillLevel;
        private Label lblNewSkillLevel;
        private TextBox txtNewSkillLevel;
        private Button btnAddSkillLevel;
        private Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private Label label1;
        private TextBox txtModel;
    }
}