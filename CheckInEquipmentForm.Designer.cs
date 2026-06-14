namespace ECS_GUI
{
    partial class CheckInEquipmentForm
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
            btnCheckIn = new Button();
            btnBack = new Button();
            label1 = new Label();
            lstCheckedOutEquipment = new ListBox();
            label2 = new Label();
            cmbLocation = new ComboBox();
            SuspendLayout();
            // 
            // lblSelectEquipment
            // 
            lblSelectEquipment.AutoSize = true;
            lblSelectEquipment.Font = new Font("Segoe UI", 10F);
            lblSelectEquipment.Location = new Point(160, 111);
            lblSelectEquipment.Name = "lblSelectEquipment";
            lblSelectEquipment.Size = new Size(117, 19);
            lblSelectEquipment.TabIndex = 1;
            lblSelectEquipment.Text = "Select Equipment:";
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = SystemColors.GradientActiveCaption;
            btnCheckIn.Cursor = Cursors.Hand;
            btnCheckIn.Font = new Font("Segoe UI", 10F);
            btnCheckIn.Location = new Point(410, 352);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(145, 45);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "Check In Asset";
            btnCheckIn.UseVisualStyleBackColor = false;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(246, 352);
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
            label1.Location = new Point(300, 35);
            label1.Name = "label1";
            label1.Size = new Size(200, 28);
            label1.TabIndex = 4;
            label1.Text = "Check In Equipment";
            // 
            // lstCheckedOutEquipment
            // 
            lstCheckedOutEquipment.FormattingEnabled = true;
            lstCheckedOutEquipment.Location = new Point(300, 111);
            lstCheckedOutEquipment.Name = "lstCheckedOutEquipment";
            lstCheckedOutEquipment.Size = new Size(331, 139);
            lstCheckedOutEquipment.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(213, 269);
            label2.Name = "label2";
            label2.Size = new Size(64, 19);
            label2.TabIndex = 6;
            label2.Text = "Location:";
            // 
            // cmbLocation
            // 
            cmbLocation.Font = new Font("Segoe UI", 10F);
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(300, 268);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(201, 25);
            cmbLocation.TabIndex = 7;
            // 
            // CheckInEquipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbLocation);
            Controls.Add(label2);
            Controls.Add(lstCheckedOutEquipment);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnCheckIn);
            Controls.Add(lblSelectEquipment);
            Name = "CheckInEquipmentForm";
            Text = "Equipment Checkout System";
            Load += CheckInEquipmentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSelectEquipment;
        private Button btnCheckIn;
        private Button btnBack;
        private Label label1;
        private ListBox lstCheckedOutEquipment;
        private Label label2;
        private ComboBox cmbLocation;
    }
}