namespace ECS_GUI
{
    partial class EmployeeMenuForm
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
            Button btnEditEmployee;
            Button btnRemoveEmployee;
            Button btnBack;
            btnAddEmployee = new Button();
            btnViewRoster = new Button();
            label3 = new Label();
            btnEditEmployee = new Button();
            btnRemoveEmployee = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.BackColor = SystemColors.GradientActiveCaption;
            btnEditEmployee.Cursor = Cursors.Hand;
            btnEditEmployee.Font = new Font("Segoe UI", 10F);
            btnEditEmployee.Location = new Point(423, 122);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(193, 47);
            btnEditEmployee.TabIndex = 13;
            btnEditEmployee.Text = "Edit Employee";
            btnEditEmployee.UseVisualStyleBackColor = false;
            btnEditEmployee.Click += btnEditEmployee_Click;
            // 
            // btnRemoveEmployee
            // 
            btnRemoveEmployee.BackColor = SystemColors.GradientActiveCaption;
            btnRemoveEmployee.Cursor = Cursors.Hand;
            btnRemoveEmployee.Font = new Font("Segoe UI", 10F);
            btnRemoveEmployee.Location = new Point(185, 221);
            btnRemoveEmployee.Name = "btnRemoveEmployee";
            btnRemoveEmployee.Size = new Size(193, 47);
            btnRemoveEmployee.TabIndex = 14;
            btnRemoveEmployee.Text = "Remove Employee";
            btnRemoveEmployee.UseVisualStyleBackColor = false;
            btnRemoveEmployee.Click += btnRemoveEmployee_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(328, 323);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 15;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.BackColor = SystemColors.GradientActiveCaption;
            btnAddEmployee.Cursor = Cursors.Hand;
            btnAddEmployee.Font = new Font("Segoe UI", 10F);
            btnAddEmployee.Location = new Point(185, 122);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(193, 47);
            btnAddEmployee.TabIndex = 11;
            btnAddEmployee.Text = "Add Employee";
            btnAddEmployee.UseVisualStyleBackColor = false;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnViewRoster
            // 
            btnViewRoster.BackColor = SystemColors.GradientActiveCaption;
            btnViewRoster.Cursor = Cursors.Hand;
            btnViewRoster.Font = new Font("Segoe UI", 10F);
            btnViewRoster.Location = new Point(423, 221);
            btnViewRoster.Name = "btnViewRoster";
            btnViewRoster.Size = new Size(193, 47);
            btnViewRoster.TabIndex = 12;
            btnViewRoster.Text = "View Roster and Holdings";
            btnViewRoster.UseVisualStyleBackColor = false;
            btnViewRoster.Click += btnViewRoster_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(318, 38);
            label3.Name = "label3";
            label3.Size = new Size(164, 28);
            label3.TabIndex = 16;
            label3.Text = "Employee Menu";
            // 
            // EmployeeMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnBack);
            Controls.Add(btnRemoveEmployee);
            Controls.Add(btnEditEmployee);
            Controls.Add(btnViewRoster);
            Controls.Add(btnAddEmployee);
            Name = "EmployeeMenuForm";
            Text = "Equipment Checkout System";
            Load += EmployeeMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddEmployee;
        private Button btnViewRoster;
        private Label label3;
    }
}