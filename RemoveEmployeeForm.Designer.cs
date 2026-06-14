namespace ECS_GUI
{
    partial class RemoveEmployeeForm
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
            lblRemoveEmployee = new Label();
            cmbSelectEmployee = new ComboBox();
            lblSelectEmployee = new Label();
            txtEmployeeDetails = new TextBox();
            btnRemoveEmployee = new Button();
            btnBack = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblRemoveEmployee
            // 
            lblRemoveEmployee.AutoSize = true;
            lblRemoveEmployee.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblRemoveEmployee.ForeColor = SystemColors.Highlight;
            lblRemoveEmployee.Location = new Point(335, 28);
            lblRemoveEmployee.Name = "lblRemoveEmployee";
            lblRemoveEmployee.Size = new Size(186, 28);
            lblRemoveEmployee.TabIndex = 1;
            lblRemoveEmployee.Text = "Remove Employee";
            // 
            // cmbSelectEmployee
            // 
            cmbSelectEmployee.Cursor = Cursors.Hand;
            cmbSelectEmployee.Font = new Font("Segoe UI", 10F);
            cmbSelectEmployee.FormattingEnabled = true;
            cmbSelectEmployee.Location = new Point(356, 135);
            cmbSelectEmployee.Name = "cmbSelectEmployee";
            cmbSelectEmployee.Size = new Size(272, 25);
            cmbSelectEmployee.TabIndex = 2;
            cmbSelectEmployee.SelectedIndexChanged += cmbSelectEmployee_SelectedIndexChanged;
            // 
            // lblSelectEmployee
            // 
            lblSelectEmployee.AutoSize = true;
            lblSelectEmployee.Font = new Font("Segoe UI", 10F);
            lblSelectEmployee.Location = new Point(219, 138);
            lblSelectEmployee.Name = "lblSelectEmployee";
            lblSelectEmployee.Size = new Size(110, 19);
            lblSelectEmployee.TabIndex = 3;
            lblSelectEmployee.Text = "Select Employee:";
            // 
            // txtEmployeeDetails
            // 
            txtEmployeeDetails.Cursor = Cursors.IBeam;
            txtEmployeeDetails.Font = new Font("Segoe UI", 10F);
            txtEmployeeDetails.Location = new Point(356, 212);
            txtEmployeeDetails.Name = "txtEmployeeDetails";
            txtEmployeeDetails.Size = new Size(272, 25);
            txtEmployeeDetails.TabIndex = 4;
            // 
            // btnRemoveEmployee
            // 
            btnRemoveEmployee.BackColor = Color.Red;
            btnRemoveEmployee.Cursor = Cursors.Hand;
            btnRemoveEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemoveEmployee.Location = new Point(445, 312);
            btnRemoveEmployee.Name = "btnRemoveEmployee";
            btnRemoveEmployee.Size = new Size(145, 50);
            btnRemoveEmployee.TabIndex = 5;
            btnRemoveEmployee.Text = "Remove Employee Record";
            btnRemoveEmployee.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.Location = new Point(210, 315);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(219, 215);
            label1.Name = "label1";
            label1.Size = new Size(116, 19);
            label1.TabIndex = 7;
            label1.Text = "Employee Details:";
            // 
            // RemoveEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnRemoveEmployee);
            Controls.Add(txtEmployeeDetails);
            Controls.Add(lblSelectEmployee);
            Controls.Add(cmbSelectEmployee);
            Controls.Add(lblRemoveEmployee);
            Name = "RemoveEmployeeForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRemoveEmployee;
        private ComboBox cmbSelectEmployee;
        private Label lblSelectEmployee;
        private TextBox txtEmployeeDetails;
        private Button btnRemoveEmployee;
        private Button btnBack;
        private Label label1;
    }
}