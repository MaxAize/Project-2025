namespace final_project
{
    partial class MainScreenForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnManageJudges = new System.Windows.Forms.Button();
            this.btnManageGames = new System.Windows.Forms.Button();
            this.btnMonthlyAssignment = new System.Windows.Forms.Button();
            this.btnViewSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(250, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.Text = "Judge Assignment System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManageJudges
            // 
            this.btnManageJudges.Location = new System.Drawing.Point(300, 100);
            this.btnManageJudges.Name = "btnManageJudges";
            this.btnManageJudges.Size = new System.Drawing.Size(200, 40);
            this.btnManageJudges.Text = "Manage Judges";
            this.btnManageJudges.Click += new System.EventHandler(this.btnManageJudges_Click);
            // 
            // btnManageGames
            // 
            this.btnManageGames.Location = new System.Drawing.Point(300, 160);
            this.btnManageGames.Name = "btnManageGames";
            this.btnManageGames.Size = new System.Drawing.Size(200, 40);
            this.btnManageGames.Text = "Manage Games";
            this.btnManageGames.Click += new System.EventHandler(this.btnManageGames_Click);
            // 
            // btnMonthlyAssignment
            // 
            this.btnMonthlyAssignment.Location = new System.Drawing.Point(300, 220);
            this.btnMonthlyAssignment.Name = "btnMonthlyAssignment";
            this.btnMonthlyAssignment.Size = new System.Drawing.Size(200, 40);
            this.btnMonthlyAssignment.Text = "Monthly Assignment";
            this.btnMonthlyAssignment.Click += new System.EventHandler(this.btnMonthlyAssignment_Click);
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.Location = new System.Drawing.Point(300, 280);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(200, 40);
            this.btnViewSchedule.Text = "View Schedule";
            this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnManageJudges);
            this.Controls.Add(this.btnManageGames);
            this.Controls.Add(this.btnMonthlyAssignment);
            this.Controls.Add(this.btnViewSchedule);
            this.Name = "Form1";
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnManageJudges;
        private System.Windows.Forms.Button btnManageGames;
        private System.Windows.Forms.Button btnMonthlyAssignment;
        private System.Windows.Forms.Button btnViewSchedule;
    }
}
