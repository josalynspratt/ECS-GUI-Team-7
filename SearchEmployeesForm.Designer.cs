namespace ECS_GUI
{
    partial class SearchEmployeesForm
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
            Button btnExecuteSearch;
            txtEmployeeSearch = new TextBox();
            txtSearchQuery = new Label();
            dgvSearchResults = new DataGridView();
            btnBackToMenu = new Button();
            label2 = new Label();
            btnExecuteSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).BeginInit();
            SuspendLayout();
            // 
            // btnExecuteSearch
            // 
            btnExecuteSearch.BackColor = SystemColors.GradientActiveCaption;
            btnExecuteSearch.Cursor = Cursors.Hand;
            btnExecuteSearch.Font = new Font("Segoe UI", 10F);
            btnExecuteSearch.Location = new Point(520, 95);
            btnExecuteSearch.Name = "btnExecuteSearch";
            btnExecuteSearch.Size = new Size(88, 40);
            btnExecuteSearch.TabIndex = 3;
            btnExecuteSearch.Text = "Search";
            btnExecuteSearch.UseVisualStyleBackColor = false;
            btnExecuteSearch.Click += btnExecuteSearch_Click;
            // 
            // txtEmployeeSearch
            // 
            txtEmployeeSearch.Cursor = Cursors.IBeam;
            txtEmployeeSearch.Font = new Font("Segoe UI", 10F);
            txtEmployeeSearch.Location = new Point(372, 107);
            txtEmployeeSearch.Name = "txtEmployeeSearch";
            txtEmployeeSearch.Size = new Size(100, 25);
            txtEmployeeSearch.TabIndex = 1;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.AutoSize = true;
            txtSearchQuery.Font = new Font("Segoe UI", 10F);
            txtSearchQuery.Location = new Point(172, 107);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.Size = new Size(182, 19);
            txtSearchQuery.TabIndex = 2;
            txtSearchQuery.Text = "Enter Employee ID or Name:";
            // 
            // dgvSearchResults
            // 
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchResults.Location = new Point(134, 166);
            dgvSearchResults.Name = "dgvSearchResults";
            dgvSearchResults.Size = new Size(533, 211);
            dgvSearchResults.TabIndex = 4;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.BackColor = SystemColors.GradientActiveCaption;
            btnBackToMenu.Cursor = Cursors.Hand;
            btnBackToMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBackToMenu.Location = new Point(328, 398);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(145, 40);
            btnBackToMenu.TabIndex = 5;
            btnBackToMenu.Text = "Back";
            btnBackToMenu.UseVisualStyleBackColor = false;
            btnBackToMenu.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(278, 26);
            label2.Name = "label2";
            label2.Size = new Size(245, 28);
            label2.TabIndex = 6;
            label2.Text = "Employee Record Search";
            // 
            // SearchEmployeesForm
            // 
            AcceptButton = btnExecuteSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnBackToMenu);
            Controls.Add(dgvSearchResults);
            Controls.Add(btnExecuteSearch);
            Controls.Add(txtSearchQuery);
            Controls.Add(txtEmployeeSearch);
            Name = "SearchEmployeesForm";
            Text = "Equipment Checkout System";
            Load += SearchEmployeesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEmployeeSearch;
        private Label txtSearchQuery;
        private DataGridView dgvSearchResults;
        private Button btnBackToMenu;
        private Label label2;
    }
}