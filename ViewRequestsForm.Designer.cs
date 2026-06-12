namespace ECS_GUI
{
    partial class ViewRequestsForm
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
            dgvRequests = new DataGridView();
            btnApprove = new Button();
            btnDeny = new Button();
            btnBack = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(82, 58);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.Size = new Size(471, 279);
            dgvRequests.TabIndex = 0;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.Lime;
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.Font = new Font("Segoe UI", 10F);
            btnApprove.Location = new Point(619, 130);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(100, 40);
            btnApprove.TabIndex = 1;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnDeny
            // 
            btnDeny.BackColor = Color.Red;
            btnDeny.Cursor = Cursors.Hand;
            btnDeny.Font = new Font("Segoe UI", 10F);
            btnDeny.Location = new Point(619, 200);
            btnDeny.Name = "btnDeny";
            btnDeny.Size = new Size(100, 40);
            btnDeny.TabIndex = 2;
            btnDeny.Text = "Deny";
            btnDeny.UseVisualStyleBackColor = false;
            btnDeny.Click += btnDeny_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.Location = new Point(328, 374);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 40);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(352, 9);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 5;
            label3.Text = "Requests";
            // 
            // ViewRequestsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnBack);
            Controls.Add(btnDeny);
            Controls.Add(btnApprove);
            Controls.Add(dgvRequests);
            Name = "ViewRequestsForm";
            Text = "Equipment Checkout System";
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRequests;
        private Button btnApprove;
        private Button btnDeny;
        private Button btnBack;
        private Label label3;
    }
}