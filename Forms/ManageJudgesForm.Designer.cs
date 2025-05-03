using System;
using System.Drawing;
using System.Windows.Forms;

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
            this.cmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddTimeRange = new System.Windows.Forms.Button();
            this.lstAvailability = new System.Windows.Forms.ListBox();
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
            this.dgvJudges.Size = new System.Drawing.Size(820, 200);
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
            // cmbDayOfWeek
            // 
            this.cmbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayOfWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbDayOfWeek.Location = new System.Drawing.Point(500, 250);
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(100, 21);
            this.cmbDayOfWeek.TabIndex = 5;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(610, 250);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(80, 20);
            this.dtpStartTime.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(700, 250);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(80, 20);
            this.dtpEndTime.TabIndex = 7;
            // 
            // btnAddTimeRange
            // 
            this.btnAddTimeRange.Location = new System.Drawing.Point(790, 250);
            this.btnAddTimeRange.Name = "btnAddTimeRange";
            this.btnAddTimeRange.Size = new System.Drawing.Size(60, 23);
            this.btnAddTimeRange.TabIndex = 8;
            this.btnAddTimeRange.Text = "Add";
            this.btnAddTimeRange.Click += new System.EventHandler(this.btnAddTimeRange_Click);
            // 
            // lstAvailability
            // 
            this.lstAvailability.Location = new System.Drawing.Point(500, 280);
            this.lstAvailability.Name = "lstAvailability";
            this.lstAvailability.Size = new System.Drawing.Size(350, 69);
            this.lstAvailability.TabIndex = 9;
            this.lstAvailability.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstAvailability_MouseDoubleClick);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(130, 340);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(150, 20);
            this.txtLocation.TabIndex = 4;
            // 
            // chkOutdoorPreference
            // 
            this.chkOutdoorPreference.AutoSize = true;
            this.chkOutdoorPreference.Location = new System.Drawing.Point(500, 357);
            this.chkOutdoorPreference.Name = "chkOutdoorPreference";
            this.chkOutdoorPreference.Size = new System.Drawing.Size(178, 17);
            this.chkOutdoorPreference.TabIndex = 10;
            this.chkOutdoorPreference.Text = "Willing to Judge Outdoor Games";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(30, 250);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name:";
            // 
            // lblExperience
            // 
            this.lblExperience.Location = new System.Drawing.Point(30, 280);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(100, 23);
            this.lblExperience.TabIndex = 12;
            this.lblExperience.Text = "Years of Experience:";
            // 
            // lblLicense
            // 
            this.lblLicense.Location = new System.Drawing.Point(30, 310);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(100, 23);
            this.lblLicense.TabIndex = 13;
            this.lblLicense.Text = "License:";
            // 
            // lblAvailability
            // 
            this.lblAvailability.Location = new System.Drawing.Point(400, 250);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(100, 23);
            this.lblAvailability.TabIndex = 15;
            this.lblAvailability.Text = "Availability:";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(30, 340);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 23);
            this.lblLocation.TabIndex = 14;
            this.lblLocation.Text = "Location:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(130, 380);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add Judge";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(240, 380);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update Judge";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 380);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete Judge";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(460, 380);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManageJudgesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.dgvJudges);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtExperience);
            this.Controls.Add(this.cmbLicense);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.cmbDayOfWeek);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.btnAddTimeRange);
            this.Controls.Add(this.lstAvailability);
            this.Controls.Add(this.chkOutdoorPreference);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblAvailability);
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

        private DataGridView dgvJudges;
        private TextBox txtName;
        private TextBox txtExperience;
        private ComboBox cmbLicense;
        private TextBox txtLocation;
        private CheckBox chkOutdoorPreference;
        private Label lblName;
        private Label lblExperience;
        private Label lblLicense;
        private Label lblAvailability;
        private Label lblLocation;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnBack;
        private ComboBox cmbDayOfWeek;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Button btnAddTimeRange;
        private ListBox lstAvailability;
    }
}
