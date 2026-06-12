namespace ECS_GUI
{
    partial class EmployeeDashboardForm

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

        private void InitializeComponent()
        {
            btnViewEquipment = new Button();
            btnRequestCheckout = new Button();
            btnLogout = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnViewEquipment
            // 
            btnViewEquipment.BackColor = SystemColors.GradientActiveCaption;
            btnViewEquipment.Cursor = Cursors.Hand;
            btnViewEquipment.Font = new Font("Segoe UI", 10F);
            btnViewEquipment.Location = new Point(328, 127);
            btnViewEquipment.Name = "btnViewEquipment";
            btnViewEquipment.Size = new Size(145, 40);
            btnViewEquipment.TabIndex = 0;
            btnViewEquipment.Text = "View Equipment";
            btnViewEquipment.UseVisualStyleBackColor = false;
            btnViewEquipment.Click += btnViewEquipment_Click;
            // 
            // btnRequestCheckout
            // 
            btnRequestCheckout.BackColor = SystemColors.GradientActiveCaption;
            btnRequestCheckout.Cursor = Cursors.Hand;
            btnRequestCheckout.Font = new Font("Segoe UI", 10F);
            btnRequestCheckout.Location = new Point(328, 205);
            btnRequestCheckout.Name = "btnRequestCheckout";
            btnRequestCheckout.Size = new Size(145, 40);
            btnRequestCheckout.TabIndex = 1;
            btnRequestCheckout.Text = "Request Checkout";
            btnRequestCheckout.UseVisualStyleBackColor = false;
            btnRequestCheckout.Click += btnRequestCheckout_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.GradientActiveCaption;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(347, 283);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(340, 54);
            label1.Name = "label1";
            label1.Size = new Size(120, 28);
            label1.TabIndex = 3;
            label1.Text = "Main Menu";
            // 
            // EmployeeDasboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnLogout);
            Controls.Add(btnRequestCheckout);
            Controls.Add(btnViewEquipment);
            Name = "EmployeeDasboardForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnViewEquipment;
        private Button btnRequestCheckout;
        private Button btnLogout;
        private Label label1;
    }
}