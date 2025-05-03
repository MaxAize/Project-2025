namespace final_project
{
    partial class ManageJudgesForm
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
            this.dgvJudges = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtExperience = new System.Windows.Forms.TextBox();
            this.cmbLicense = new System.Windows.Forms.ComboBox();
            this.txtAvailability = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.chkOutdoorPreference = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJudges)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJudges
            // 
            this.dgvJudges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJudges.Location = new System.Drawing.Point(30, 30);
            this.dgvJudges.Name = "dgvJudges";
            this.dgvJudges.Size = new System.Drawing.Size(700, 200);
            this.dgvJudges.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 250);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtExperience
            // 
            this.txtExperience.Location = new System.Drawing.Point(130, 280);
            this.txtExperience.Name = "txtExperience";
            this.txtExperience.Size = new System.Drawing.Size(150, 20);
            this.txtExperience.TabIndex = 2;
            // 
            // cmbLicense
            // 
            this.cmbLicense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLicense.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cmbLicense.Location = new System.Drawing.Point(130, 310);
            this.cmbLicense.Name = "cmbLicense";
            this.cmbLicense.Size = new System.Drawing.Size(150, 21);
            this.cmbLicense.TabIndex = 3;
            // 
            // txtAvailability
            // 
            this.txtAvailability.Location = new System.Drawing.Point(500, 250);
            this.txtAvailability.Multiline = true;
            this.txtAvailability.Name = "txtAvailability";
            this.txtAvailability.Size = new System.Drawing.Size(200, 50);
            this.txtAvailability.TabIndex = 4;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(500, 310);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(200, 20);
            this.txtLocation.TabIndex = 5;
            // 
            // chkOutdoorPreference
            // 
            this.chkOutdoorPreference.AutoSize = true;
            this.chkOutdoorPreference.Location = new System.Drawing.Point(500, 340);
            this.chkOutdoorPreference.Name = "chkOutdoorPreference";
            this.chkOutdoorPreference.Size = new System.Drawing.Size(178, 17);
            this.chkOutdoorPreference.TabIndex = 6;
            this.chkOutdoorPreference.Text = "Willing to Judge Outdoor Games";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 250);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(30, 280);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(105, 13);
            this.lblExperience.TabIndex = 8;
            this.lblExperience.Text = "Years of Experience:";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(30, 310);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(47, 13);
            this.lblLicense.TabIndex = 9;
            this.lblLicense.Text = "License:";
            // 
            // lblAvailability
            // 
            this.lblAvailability.AutoSize = true;
            this.lblAvailability.Location = new System.Drawing.Point(400, 250);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(59, 13);
            this.lblAvailability.TabIndex = 10;
            this.lblAvailability.Text = "Availability:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(400, 310);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 11;
            this.lblLocation.Text = "Location:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(130, 370);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add Judge";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(240, 370);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update Judge";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 370);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete Judge";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(460, 370);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManageJudgesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 430);
            this.Controls.Add(this.dgvJudges);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtExperience);
            this.Controls.Add(this.cmbLicense);
            this.Controls.Add(this.txtAvailability);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.chkOutdoorPreference);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblAvailability);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBack);
            this.Name = "ManageJudgesForm";
            this.Text = "Manage Judges";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJudges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJudges;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtExperience;
        private System.Windows.Forms.ComboBox cmbLicense;
        private System.Windows.Forms.TextBox txtAvailability;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.CheckBox chkOutdoorPreference;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}
