namespace ECS_GUI
{
    partial class TrackEquipmentForm
    {
        private System.ComponentModel.IContainer components = null;

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
            label2 = new Label();
            dgvActiveCheckouts = new DataGridView();
            label1 = new Label();
            cmbStatusFilter = new ComboBox();
            btnBackToMenu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvActiveCheckouts).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(263, 32);
            label2.Name = "label2";
            label2.Size = new Size(274, 28);
            label2.TabIndex = 7;
            label2.Text = "Equipment Tracking System";
            // 
            // dgvActiveCheckouts
            // 
            dgvActiveCheckouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveCheckouts.Location = new Point(74, 138);
            dgvActiveCheckouts.Name = "dgvActiveCheckouts";
            dgvActiveCheckouts.Size = new Size(653, 212);
            dgvActiveCheckouts.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(271, 95);
            label1.Name = "label1";
            label1.Size = new Size(103, 19);
            label1.TabIndex = 10;
            label1.Text = "Filter by Status:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Cursor = Cursors.Hand;
            cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(394, 95);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(121, 25);
            cmbStatusFilter.TabIndex = 11;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.BackColor = SystemColors.GradientActiveCaption;
            btnBackToMenu.Cursor = Cursors.Hand;
            btnBackToMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBackToMenu.Location = new Point(328, 385);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(145, 40);
            btnBackToMenu.TabIndex = 12;
            btnBackToMenu.Text = "Back";
            btnBackToMenu.UseVisualStyleBackColor = false;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // TrackEquipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBackToMenu);
            Controls.Add(cmbStatusFilter);
            Controls.Add(label1);
            Controls.Add(dgvActiveCheckouts);
            Controls.Add(label2);
            Name = "TrackEquipmentForm";
            Text = "Equipment Checkout System";
            ((System.ComponentModel.ISupportInitialize)dgvActiveCheckouts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private DataGridView dgvActiveCheckouts;
        private Label label1;
        private ComboBox cmbStatusFilter;
        private Button btnBackToMenu;
    }
}