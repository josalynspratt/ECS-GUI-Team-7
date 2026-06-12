namespace ECS_GUI
{
    partial class EditEquipmentForm
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
            cmbSelectEquipment = new ComboBox();
            txtEquipmentName = new TextBox();
            btnSaveUpdates = new Button();
            btnBack = new Button();
            lblRequiredSkill = new Label();
            lblEquipmentName = new Label();
            lblSelectEquipment = new Label();
            label1 = new Label();
            clbRequiredSkills = new CheckedListBox();
            lblLocation = new Label();
            cmbLocation = new ComboBox();
            txtModel = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbSelectEquipment
            // 
            cmbSelectEquipment.Cursor = Cursors.Hand;
            cmbSelectEquipment.Font = new Font("Segoe UI", 10F);
            cmbSelectEquipment.FormattingEnabled = true;
            cmbSelectEquipment.Location = new Point(358, 83);
            cmbSelectEquipment.Name = "cmbSelectEquipment";
            cmbSelectEquipment.Size = new Size(244, 25);
            cmbSelectEquipment.TabIndex = 0;
            cmbSelectEquipment.SelectedIndexChanged += cmbSelectEquipment_SelectedIndexChanged;
            cmbSelectEquipment.Click += cmbSelectEquipment_SelectedIndexChanged;
            // 
            // txtEquipmentName
            // 
            txtEquipmentName.Cursor = Cursors.IBeam;
            txtEquipmentName.Font = new Font("Segoe UI", 10F);
            txtEquipmentName.Location = new Point(358, 121);
            txtEquipmentName.Name = "txtEquipmentName";
            txtEquipmentName.Size = new Size(244, 25);
            txtEquipmentName.TabIndex = 1;
            // 
            // btnSaveUpdates
            // 
            btnSaveUpdates.BackColor = SystemColors.GradientActiveCaption;
            btnSaveUpdates.Cursor = Cursors.Hand;
            btnSaveUpdates.Font = new Font("Segoe UI", 10F);
            btnSaveUpdates.Location = new Point(437, 353);
            btnSaveUpdates.Name = "btnSaveUpdates";
            btnSaveUpdates.Size = new Size(100, 45);
            btnSaveUpdates.TabIndex = 3;
            btnSaveUpdates.Text = "Save Updates";
            btnSaveUpdates.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(263, 353);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblRequiredSkill
            // 
            lblRequiredSkill.AutoSize = true;
            lblRequiredSkill.Font = new Font("Segoe UI", 10F);
            lblRequiredSkill.Location = new Point(223, 238);
            lblRequiredSkill.Name = "lblRequiredSkill";
            lblRequiredSkill.Size = new Size(93, 19);
            lblRequiredSkill.TabIndex = 5;
            lblRequiredSkill.Text = "Required Skill:";
            // 
            // lblEquipmentName
            // 
            lblEquipmentName.AutoSize = true;
            lblEquipmentName.Font = new Font("Segoe UI", 10F);
            lblEquipmentName.Location = new Point(198, 124);
            lblEquipmentName.Name = "lblEquipmentName";
            lblEquipmentName.Size = new Size(118, 19);
            lblEquipmentName.TabIndex = 6;
            lblEquipmentName.Text = "Equipment Name:";
            // 
            // lblSelectEquipment
            // 
            lblSelectEquipment.AutoSize = true;
            lblSelectEquipment.Font = new Font("Segoe UI", 10F);
            lblSelectEquipment.Location = new Point(199, 86);
            lblSelectEquipment.Name = "lblSelectEquipment";
            lblSelectEquipment.Size = new Size(117, 19);
            lblSelectEquipment.TabIndex = 7;
            lblSelectEquipment.Text = "Select Equipment:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(340, 36);
            label1.Name = "label1";
            label1.Size = new Size(157, 28);
            label1.TabIndex = 8;
            label1.Text = "Edit Equipment";
            // 
            // clbRequiredSkills
            // 
            clbRequiredSkills.Font = new Font("Segoe UI", 10F);
            clbRequiredSkills.FormattingEnabled = true;
            clbRequiredSkills.Location = new Point(358, 238);
            clbRequiredSkills.Name = "clbRequiredSkills";
            clbRequiredSkills.Size = new Size(244, 84);
            clbRequiredSkills.TabIndex = 9;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 10F);
            lblLocation.Location = new Point(252, 200);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(64, 19);
            lblLocation.TabIndex = 11;
            lblLocation.Text = "Location:";
            // 
            // cmbLocation
            // 
            cmbLocation.Cursor = Cursors.Hand;
            cmbLocation.Font = new Font("Segoe UI", 10F);
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(358, 197);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(244, 25);
            cmbLocation.TabIndex = 10;
            // 
            // txtModel
            // 
            txtModel.Cursor = Cursors.IBeam;
            txtModel.Font = new Font("Segoe UI", 10F);
            txtModel.Location = new Point(358, 160);
            txtModel.Multiline = true;
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(244, 25);
            txtModel.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(265, 162);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 18;
            label2.Text = "Model:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditEquipmentForm
            // 
            AcceptButton = btnSaveUpdates;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtModel);
            Controls.Add(label2);
            Controls.Add(lblLocation);
            Controls.Add(cmbLocation);
            Controls.Add(clbRequiredSkills);
            Controls.Add(label1);
            Controls.Add(lblSelectEquipment);
            Controls.Add(lblEquipmentName);
            Controls.Add(lblRequiredSkill);
            Controls.Add(btnBack);
            Controls.Add(btnSaveUpdates);
            Controls.Add(txtEquipmentName);
            Controls.Add(cmbSelectEquipment);
            Name = "EditEquipmentForm";
            Text = "EditEquipmentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSelectEquipment;
        private TextBox txtEquipmentName;
        private Button btnSaveUpdates;
        private Button btnBack;
        private Label lblRequiredSkill;
        private Label lblEquipmentName;
        private Label lblSelectEquipment;
        private Label label1;
        private CheckedListBox clbRequiredSkills;
        private Label lblLocation;
        private ComboBox cmbLocation;
        private TextBox txtModel;
        private Label label2;
    }
}