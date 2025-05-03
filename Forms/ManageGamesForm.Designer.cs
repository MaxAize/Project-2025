namespace final_project
{
    partial class ManageGamesForm
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
            this.dgvGames = new System.Windows.Forms.DataGridView();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cmbLeague = new System.Windows.Forms.ComboBox();
            this.chkPlayoff = new System.Windows.Forms.CheckBox();
            this.cmbFieldType = new System.Windows.Forms.ComboBox();
            this.numImportance = new System.Windows.Forms.NumericUpDown();
            this.dtpGameDate = new System.Windows.Forms.DateTimePicker();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblLeague = new System.Windows.Forms.Label();
            this.lblPlayoff = new System.Windows.Forms.Label();
            this.lblFieldType = new System.Windows.Forms.Label();
            this.lblImportance = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImportance)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGames
            // 
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Location = new System.Drawing.Point(30, 30);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.Size = new System.Drawing.Size(740, 200);
            this.dgvGames.TabIndex = 0;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(130, 250);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(150, 22);
            this.txtLocation.TabIndex = 1;
            // 
            // cmbLeague
            // 
            this.cmbLeague.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeague.Items.AddRange(new object[] { "First", "Second", "Third" });
            this.cmbLeague.Location = new System.Drawing.Point(130, 280);
            this.cmbLeague.Name = "cmbLeague";
            this.cmbLeague.Size = new System.Drawing.Size(150, 24);
            this.cmbLeague.TabIndex = 2;
            // 
            // chkPlayoff
            // 
            this.chkPlayoff.Location = new System.Drawing.Point(130, 310);
            this.chkPlayoff.Text = "Is Playoff";
            this.chkPlayoff.AutoSize = true;
            this.chkPlayoff.TabIndex = 3;
            // 
            // cmbFieldType
            // 
            this.cmbFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFieldType.Items.AddRange(new object[] { "Indoor", "Outdoor" });
            this.cmbFieldType.Location = new System.Drawing.Point(500, 250);
            this.cmbFieldType.Name = "cmbFieldType";
            this.cmbFieldType.Size = new System.Drawing.Size(150, 24);
            this.cmbFieldType.TabIndex = 4;
            // 
            // numImportance
            // 
            this.numImportance.Location = new System.Drawing.Point(500, 280);
            this.numImportance.Maximum = 5000;
            this.numImportance.Name = "numImportance";
            this.numImportance.Size = new System.Drawing.Size(150, 22);
            this.numImportance.TabIndex = 5;
            // 
            // dtpGameDate
            // 
            this.dtpGameDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGameDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpGameDate.Location = new System.Drawing.Point(500, 310);
            this.dtpGameDate.Name = "dtpGameDate";
            this.dtpGameDate.Size = new System.Drawing.Size(150, 22);
            this.dtpGameDate.TabIndex = 6;
            // 
            // Labels
            this.lblLocation.Location = new System.Drawing.Point(30, 250);
            this.lblLocation.Text = "Location:";
            this.lblLocation.AutoSize = true;

            this.lblLeague.Location = new System.Drawing.Point(30, 280);
            this.lblLeague.Text = "League:";
            this.lblLeague.AutoSize = true;

            this.lblPlayoff.Location = new System.Drawing.Point(30, 310);
            this.lblPlayoff.Text = "Playoff:";
            this.lblPlayoff.AutoSize = true;

            this.lblFieldType.Location = new System.Drawing.Point(400, 250);
            this.lblFieldType.Text = "Field Type:";
            this.lblFieldType.AutoSize = true;

            this.lblImportance.Location = new System.Drawing.Point(400, 280);
            this.lblImportance.Text = "Importance:";
            this.lblImportance.AutoSize = true;

            this.lblDate.Location = new System.Drawing.Point(400, 310);
            this.lblDate.Text = "Date & Time:";
            this.lblDate.AutoSize = true;

            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(130, 360);
            this.btnAdd.Text = "Add Game";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);

            this.btnUpdate.Location = new System.Drawing.Point(240, 360);
            this.btnUpdate.Text = "Update Game";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);

            this.btnDelete.Location = new System.Drawing.Point(350, 360);
            this.btnDelete.Text = "Delete Game";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);

            this.btnBack.Location = new System.Drawing.Point(460, 360);
            this.btnBack.Text = "Back";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.dgvGames);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.cmbLeague);
            this.Controls.Add(this.chkPlayoff);
            this.Controls.Add(this.cmbFieldType);
            this.Controls.Add(this.numImportance);
            this.Controls.Add(this.dtpGameDate);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblLeague);
            this.Controls.Add(this.lblPlayoff);
            this.Controls.Add(this.lblFieldType);
            this.Controls.Add(this.lblImportance);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBack);
            this.Name = "ManageGamesForm";
            this.Text = "Manage Games";
            this.Load += new System.EventHandler(this.ManageGamesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImportance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGames;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox cmbLeague;
        private System.Windows.Forms.CheckBox chkPlayoff;
        private System.Windows.Forms.ComboBox cmbFieldType;
        private System.Windows.Forms.NumericUpDown numImportance;
        private System.Windows.Forms.DateTimePicker dtpGameDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblLeague;
        private System.Windows.Forms.Label lblPlayoff;
        private System.Windows.Forms.Label lblFieldType;
        private System.Windows.Forms.Label lblImportance;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}
