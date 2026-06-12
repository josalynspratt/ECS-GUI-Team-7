namespace ECS_GUI
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblEmployeeID = new Label();
            txtEmployeeID = new TextBox();
            btnLogin = new Button();
            lblBadgeNumber = new Label();
            txtBadgeNumber = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.AutoSize = true;
            lblEmployeeID.Font = new Font("Segoe UI", 10F);
            lblEmployeeID.Location = new Point(292, 138);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(89, 19);
            lblEmployeeID.TabIndex = 0;
            lblEmployeeID.Text = "Employee ID:";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Cursor = Cursors.IBeam;
            txtEmployeeID.Font = new Font("Segoe UI", 10F);
            txtEmployeeID.Location = new Point(398, 138);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(100, 25);
            txtEmployeeID.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.GradientActiveCaption;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.Location = new Point(350, 253);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 40);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblBadgeNumber
            // 
            lblBadgeNumber.AutoSize = true;
            lblBadgeNumber.Font = new Font("Segoe UI", 10F);
            lblBadgeNumber.Location = new Point(277, 182);
            lblBadgeNumber.Name = "lblBadgeNumber";
            lblBadgeNumber.Size = new Size(104, 19);
            lblBadgeNumber.TabIndex = 3;
            lblBadgeNumber.Text = "Badge Number:";
            // 
            // txtBadgeNumber
            // 
            txtBadgeNumber.Cursor = Cursors.IBeam;
            txtBadgeNumber.Font = new Font("Segoe UI", 10F);
            txtBadgeNumber.Location = new Point(398, 182);
            txtBadgeNumber.Name = "txtBadgeNumber";
            txtBadgeNumber.Size = new Size(100, 25);
            txtBadgeNumber.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(223, 38);
            label3.Name = "label3";
            label3.Size = new Size(354, 28);
            label3.TabIndex = 4;
            label3.Text = "Equipment Checkout System - Login";
            // 
            // Login
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtBadgeNumber);
            Controls.Add(lblBadgeNumber);
            Controls.Add(btnLogin);
            Controls.Add(txtEmployeeID);
            Controls.Add(lblEmployeeID);
            Name = "Login";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmployeeID;
        private TextBox txtEmployeeID;
        private Button btnLogin;
        private Label lblBadgeNumber;
        private TextBox txtBadgeNumber;
        private Label label3;
    }
}
