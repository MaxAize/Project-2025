namespace final_project
{
    partial class ViewScheduleForm
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
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(30, 30);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(740, 300);
            this.dgvSchedule.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(200, 350);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh Schedule";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(400, 350);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 35);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            // ViewScheduleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblStatus);
            this.Name = "ViewScheduleForm";
            this.Text = "View Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStatus;
    }
}