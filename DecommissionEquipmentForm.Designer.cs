namespace ECS_GUI
{
    partial class DecommissionEquipmentForm
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
            lblSelectEquipment = new Label();
            cmbSelectEquipment = new ComboBox();
            btnDecommission = new Button();
            btnBack = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblSelectEquipment
            // 
            lblSelectEquipment.AutoSize = true;
            lblSelectEquipment.Font = new Font("Segoe UI", 10F);
            lblSelectEquipment.Location = new Point(122, 152);
            lblSelectEquipment.Name = "lblSelectEquipment";
            lblSelectEquipment.Size = new Size(117, 19);
            lblSelectEquipment.TabIndex = 0;
            lblSelectEquipment.Text = "Select Equipment:";
            // 
            // cmbSelectEquipment
            // 
            cmbSelectEquipment.Cursor = Cursors.Hand;
            cmbSelectEquipment.Font = new Font("Segoe UI", 10F);
            cmbSelectEquipment.FormattingEnabled = true;
            cmbSelectEquipment.Location = new Point(262, 146);
            cmbSelectEquipment.Name = "cmbSelectEquipment";
            cmbSelectEquipment.Size = new Size(416, 25);
            cmbSelectEquipment.TabIndex = 1;
            // 
            // btnDecommission
            // 
            btnDecommission.BackColor = Color.Red;
            btnDecommission.Cursor = Cursors.Hand;
            btnDecommission.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDecommission.Location = new Point(401, 260);
            btnDecommission.Name = "btnDecommission";
            btnDecommission.Size = new Size(180, 45);
            btnDecommission.TabIndex = 2;
            btnDecommission.Text = "Decommission Asset";
            btnDecommission.UseVisualStyleBackColor = false;
            btnDecommission.Click += btnDecommission_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(189, 260);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 45);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(297, 34);
            label1.Name = "label1";
            label1.Size = new Size(207, 28);
            label1.TabIndex = 4;
            label1.Text = "Decommission Asset";
            // 
            // DecommissionEquipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnDecommission);
            Controls.Add(cmbSelectEquipment);
            Controls.Add(lblSelectEquipment);
            Name = "DecommissionEquipmentForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectEquipment;
        private ComboBox cmbSelectEquipment;
        private Button btnDecommission;
        private Button btnBack;
        private Label label1;
    }
}