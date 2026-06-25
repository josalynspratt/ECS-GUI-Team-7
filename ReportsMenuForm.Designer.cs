namespace ECS_GUI
{
    partial class ReportsMenuForm
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
            btnActiveInventory = new Button();
            btnTransactionMasterLog = new Button();
            btnOutboundDeployments = new Button();
            btnAuditLogTrail = new Button();
            btnDecommissionedReport = new Button();
            btnBack = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnActiveInventory
            // 
            btnActiveInventory.BackColor = SystemColors.GradientActiveCaption;
            btnActiveInventory.Cursor = Cursors.Hand;
            btnActiveInventory.Font = new Font("Segoe UI", 10F);
            btnActiveInventory.Location = new Point(146, 132);
            btnActiveInventory.Name = "btnActiveInventory";
            btnActiveInventory.Size = new Size(145, 60);
            btnActiveInventory.TabIndex = 0;
            btnActiveInventory.Text = "Active Operational Inventory";
            btnActiveInventory.UseVisualStyleBackColor = false;
            btnActiveInventory.Click += btnActiveInventory_Click_1;
            // 
            // btnTransactionMasterLog
            // 
            btnTransactionMasterLog.BackColor = SystemColors.GradientActiveCaption;
            btnTransactionMasterLog.Cursor = Cursors.Hand;
            btnTransactionMasterLog.Font = new Font("Segoe UI", 10F);
            btnTransactionMasterLog.Location = new Point(510, 132);
            btnTransactionMasterLog.Name = "btnTransactionMasterLog";
            btnTransactionMasterLog.Size = new Size(145, 60);
            btnTransactionMasterLog.TabIndex = 1;
            btnTransactionMasterLog.Text = "Transaction Master Log";
            btnTransactionMasterLog.UseVisualStyleBackColor = false;
            btnTransactionMasterLog.Click += btnTransactionMasterLog_Click;
            // 
            // btnOutboundDeployments
            // 
            btnOutboundDeployments.BackColor = SystemColors.GradientActiveCaption;
            btnOutboundDeployments.Cursor = Cursors.Hand;
            btnOutboundDeployments.Font = new Font("Segoe UI", 10F);
            btnOutboundDeployments.Location = new Point(510, 213);
            btnOutboundDeployments.Name = "btnOutboundDeployments";
            btnOutboundDeployments.Size = new Size(145, 60);
            btnOutboundDeployments.TabIndex = 2;
            btnOutboundDeployments.Text = "Active Outbound Deployments";
            btnOutboundDeployments.UseVisualStyleBackColor = false;
            btnOutboundDeployments.Click += btnOutboundDeployments_Click;
            // 
            // btnAuditLogTrail
            // 
            btnAuditLogTrail.BackColor = SystemColors.GradientActiveCaption;
            btnAuditLogTrail.Cursor = Cursors.Hand;
            btnAuditLogTrail.Font = new Font("Segoe UI", 10F);
            btnAuditLogTrail.Location = new Point(328, 132);
            btnAuditLogTrail.Name = "btnAuditLogTrail";
            btnAuditLogTrail.Size = new Size(145, 60);
            btnAuditLogTrail.TabIndex = 3;
            btnAuditLogTrail.Text = "Audit Logs";
            btnAuditLogTrail.UseVisualStyleBackColor = false;
            btnAuditLogTrail.Click += btnAuditLogTrail_Click;
            // 
            // btnDecommissionedReport
            // 
            btnDecommissionedReport.BackColor = SystemColors.GradientActiveCaption;
            btnDecommissionedReport.Cursor = Cursors.Hand;
            btnDecommissionedReport.Font = new Font("Segoe UI", 10F);
            btnDecommissionedReport.Location = new Point(146, 213);
            btnDecommissionedReport.Name = "btnDecommissionedReport";
            btnDecommissionedReport.Size = new Size(145, 60);
            btnDecommissionedReport.TabIndex = 4;
            btnDecommissionedReport.Text = "Decommissioned Equipment";
            btnDecommissionedReport.UseVisualStyleBackColor = false;
            btnDecommissionedReport.Click += btnDecommissionedReport_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(345, 320);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 45);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(327, 25);
            label1.Name = "label1";
            label1.Size = new Size(146, 28);
            label1.TabIndex = 13;
            label1.Text = "Reports Menu";
            // 
            // ReportsMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnDecommissionedReport);
            Controls.Add(btnAuditLogTrail);
            Controls.Add(btnOutboundDeployments);
            Controls.Add(btnTransactionMasterLog);
            Controls.Add(btnActiveInventory);
            Name = "ReportsMenuForm";
            Text = "Equipment Checkout System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnActiveInventory;
        private Button btnTransactionMasterLog;
        private Button btnOutboundDeployments;
        private Button btnAuditLogTrail;
        private Button btnDecommissionedReport;
        private Button btnBack;
        private Label label1;
    }
}