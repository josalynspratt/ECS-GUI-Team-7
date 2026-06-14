namespace ECS_GUI
{
    partial class EquipmentMenuForm
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
            btnAddEquipment = new Button();
            btnEditEquipment = new Button();
            btnDecommission = new Button();
            btnViewEquipment = new Button();
            btnBack = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnAddEquipment
            // 
            btnAddEquipment.BackColor = SystemColors.GradientActiveCaption;
            btnAddEquipment.Cursor = Cursors.Hand;
            btnAddEquipment.Font = new Font("Segoe UI", 10F);
            btnAddEquipment.Location = new Point(426, 132);
            btnAddEquipment.Name = "btnAddEquipment";
            btnAddEquipment.Size = new Size(177, 47);
            btnAddEquipment.TabIndex = 7;
            btnAddEquipment.Text = "Add Equipment";
            btnAddEquipment.UseVisualStyleBackColor = false;
            btnAddEquipment.Click += btnAddEquipment_Click;
            // 
            // btnEditEquipment
            // 
            btnEditEquipment.BackColor = SystemColors.GradientActiveCaption;
            btnEditEquipment.Cursor = Cursors.Hand;
            btnEditEquipment.Font = new Font("Segoe UI", 10F);
            btnEditEquipment.Location = new Point(426, 218);
            btnEditEquipment.Name = "btnEditEquipment";
            btnEditEquipment.Size = new Size(177, 47);
            btnEditEquipment.TabIndex = 8;
            btnEditEquipment.Text = "Edit Equipment";
            btnEditEquipment.UseVisualStyleBackColor = false;
            btnEditEquipment.Click += btnEditEquipment_Click;
            // 
            // btnDecommission
            // 
            btnDecommission.BackColor = SystemColors.GradientActiveCaption;
            btnDecommission.Cursor = Cursors.Hand;
            btnDecommission.Font = new Font("Segoe UI", 10F);
            btnDecommission.Location = new Point(199, 218);
            btnDecommission.Name = "btnDecommission";
            btnDecommission.Size = new Size(177, 47);
            btnDecommission.TabIndex = 9;
            btnDecommission.Text = "Decommission Equipment";
            btnDecommission.UseVisualStyleBackColor = false;
            btnDecommission.Click += btnDecommission_Click;
            // 
            // btnViewEquipment
            // 
            btnViewEquipment.BackColor = SystemColors.GradientActiveCaption;
            btnViewEquipment.Cursor = Cursors.Hand;
            btnViewEquipment.Font = new Font("Segoe UI", 10F);
            btnViewEquipment.Location = new Point(199, 132);
            btnViewEquipment.Name = "btnViewEquipment";
            btnViewEquipment.Size = new Size(177, 47);
            btnViewEquipment.TabIndex = 10;
            btnViewEquipment.Text = "View Equipment";
            btnViewEquipment.UseVisualStyleBackColor = false;
            btnViewEquipment.Click += btnViewEquipment_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(312, 350);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(177, 47);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back to Main Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(304, 32);
            label1.Name = "label1";
            label1.Size = new Size(174, 28);
            label1.TabIndex = 12;
            label1.Text = "Equipment Menu";
            // 
            // EquipmentMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnViewEquipment);
            Controls.Add(btnDecommission);
            Controls.Add(btnEditEquipment);
            Controls.Add(btnAddEquipment);
            Name = "EquipmentMenuForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddEquipment;
        private Button btnEditEquipment;
        private Button btnDecommission;
        private Button btnViewEquipment;
        private Button btnBack;
        private Label label1;
    }
}