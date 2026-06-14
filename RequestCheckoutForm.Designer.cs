namespace ECS_GUI
{
    partial class RequestCheckoutForm
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
            lblEmployeeIDText = new Label();
            cmbEquipmentList = new ComboBox();
            dtpCheckoutDate = new DateTimePicker();
            txtProjectName = new TextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            txtEmployeeID = new TextBox();
            lblSelectEquipment = new Label();
            lblCheckoutDate = new Label();
            lblProject = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // lblEmployeeIDText
            // 
            lblEmployeeIDText.AutoSize = true;
            lblEmployeeIDText.Font = new Font("Segoe UI", 10F);
            lblEmployeeIDText.Location = new Point(241, 98);
            lblEmployeeIDText.Name = "lblEmployeeIDText";
            lblEmployeeIDText.Size = new Size(89, 19);
            lblEmployeeIDText.TabIndex = 0;
            lblEmployeeIDText.Text = "Employee ID:";
            // 
            // cmbEquipmentList
            // 
            cmbEquipmentList.Cursor = Cursors.Hand;
            cmbEquipmentList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquipmentList.FormattingEnabled = true;
            cmbEquipmentList.Location = new Point(356, 152);
            cmbEquipmentList.Name = "cmbEquipmentList";
            cmbEquipmentList.Size = new Size(274, 23);
            cmbEquipmentList.TabIndex = 1;
            // 
            // dtpCheckoutDate
            // 
            dtpCheckoutDate.Cursor = Cursors.Hand;
            dtpCheckoutDate.Location = new Point(356, 206);
            dtpCheckoutDate.Name = "dtpCheckoutDate";
            dtpCheckoutDate.Size = new Size(193, 23);
            dtpCheckoutDate.TabIndex = 2;
            // 
            // txtProjectName
            // 
            txtProjectName.Cursor = Cursors.IBeam;
            txtProjectName.Location = new Point(356, 260);
            txtProjectName.Multiline = true;
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(274, 19);
            txtProjectName.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = SystemColors.GradientActiveCaption;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.Location = new Point(436, 336);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 40);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmitRequest_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.Location = new Point(264, 336);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Font = new Font("Segoe UI", 10F);
            txtEmployeeID.Location = new Point(356, 98);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(100, 25);
            txtEmployeeID.TabIndex = 6;
            // 
            // lblSelectEquipment
            // 
            lblSelectEquipment.AutoSize = true;
            lblSelectEquipment.Font = new Font("Segoe UI", 10F);
            lblSelectEquipment.Location = new Point(213, 152);
            lblSelectEquipment.Name = "lblSelectEquipment";
            lblSelectEquipment.Size = new Size(117, 19);
            lblSelectEquipment.TabIndex = 7;
            lblSelectEquipment.Text = "Select Equipment:";
            // 
            // lblCheckoutDate
            // 
            lblCheckoutDate.AutoSize = true;
            lblCheckoutDate.Font = new Font("Segoe UI", 10F);
            lblCheckoutDate.Location = new Point(227, 206);
            lblCheckoutDate.Name = "lblCheckoutDate";
            lblCheckoutDate.Size = new Size(103, 19);
            lblCheckoutDate.TabIndex = 8;
            lblCheckoutDate.Text = "Checkout Date:";
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Font = new Font("Segoe UI", 10F);
            lblProject.Location = new Point(236, 260);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(94, 19);
            lblProject.TabIndex = 9;
            lblProject.Text = "Project Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(309, 33);
            label3.Name = "label3";
            label3.Size = new Size(182, 28);
            label3.TabIndex = 10;
            label3.Text = "Request Checkout";
            // 
            // RequestCheckoutForm
            // 
            AcceptButton = btnSubmit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(lblProject);
            Controls.Add(lblCheckoutDate);
            Controls.Add(lblSelectEquipment);
            Controls.Add(txtEmployeeID);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(txtProjectName);
            Controls.Add(dtpCheckoutDate);
            Controls.Add(cmbEquipmentList);
            Controls.Add(lblEmployeeIDText);
            Name = "RequestCheckoutForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmployeeIDText;
        private ComboBox cmbEquipmentList;
        private DateTimePicker dtpCheckoutDate;
        private TextBox txtProjectName;
        private Button btnSubmit;
        private Button btnCancel;
        private TextBox txtEmployeeID;
        private Label lblSelectEquipment;
        private Label lblCheckoutDate;
        private Label lblProject;
        private Label label3;
    }
}