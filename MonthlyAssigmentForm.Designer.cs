namespace final_project
{
    partial class MonthlyAssigmentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvAssignmentResults = new System.Windows.Forms.DataGridView();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignmentResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAssignmentResults
            // 
            this.dgvAssignmentResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignmentResults.Location = new System.Drawing.Point(30, 30);
            this.dgvAssignmentResults.Name = "dgvAssignmentResults";
            this.dgvAssignmentResults.Size = new System.Drawing.Size(740, 280);
            this.dgvAssignmentResults.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(200, 340);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 40);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate Assignment";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(400, 340);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 40);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset Assignment";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(30, 400);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(740, 30);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: Waiting...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MonthlyAssigmentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAssignmentResults);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblStatus);
            this.Name = "MonthlyAssigmentForm";
            this.Text = "Monthly Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignmentResults)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssignmentResults;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblStatus;
    }
}