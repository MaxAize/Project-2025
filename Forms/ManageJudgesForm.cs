using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using final_project.Models;
using final_project.DataAccess;

namespace final_project
{
    public partial class ManageJudgesForm : Form
    {
        private JudgeRepository judgeRepo = new JudgeRepository();
        private AvailabilitySchedule currentAvailability = new AvailabilitySchedule();
        private Judge selectedJudge = null;

        public ManageJudgesForm()
        {
            InitializeComponent();
            RefreshJudgeGrid();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Judge judge = CreateJudgeFromForm();
                judgeRepo.AddJudge(judge);
                RefreshJudgeGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private Judge CreateJudgeFromForm()
        {
            return new Judge
            {
                Name = txtName.Text.Trim(),
                YearsOfExperience = int.Parse(txtExperience.Text),
                License = (LicenseType)Enum.Parse(typeof(LicenseType), cmbLicense.SelectedItem.ToString()),
                Location = txtLocation.Text.Trim(),
                AcceptsOutdoorGames = chkOutdoorPreference.Checked,
                Availability = currentAvailability
            };
        }

        private void RefreshJudgeGrid()
        {
            List<Judge> judges = judgeRepo.GetAllJudges();

            dgvJudges.DataSource = null;
            dgvJudges.DataSource = judges.Select(j => new
            {
                j.ID,
                j.Name,
                j.YearsOfExperience,
                License = j.License.ToString(),
                j.Location,
                Outdoor = j.AcceptsOutdoorGames ? "Yes" : "No",
                Availability = j.AvailabilitySummary
            }).ToList();

            dgvJudges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJudges.CellDoubleClick += dgvJudges_CellDoubleClick;
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtExperience.Text = "";
            cmbLicense.SelectedIndex = -1;
            txtLocation.Text = "";
            chkOutdoorPreference.Checked = false;
            cmbDayOfWeek.SelectedIndex = -1;
            lstAvailability.Items.Clear();
            currentAvailability = new AvailabilitySchedule();
            selectedJudge = null;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAddTimeRange_Click(object sender, EventArgs e)
        {
            if (cmbDayOfWeek.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a day.");
                return;
            }

            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), cmbDayOfWeek.SelectedItem.ToString());
            TimeSpan start = dtpStartTime.Value.TimeOfDay;
            TimeSpan end = dtpEndTime.Value.TimeOfDay;

            if (start >= end)
            {
                MessageBox.Show("Start time must be before end time.");
                return;
            }

            if (!currentAvailability.WeeklyAvailability.ContainsKey(day))
            {
                currentAvailability.WeeklyAvailability[day] = new List<TimeRange>();
            }

            currentAvailability.WeeklyAvailability[day].Add(new TimeRange(start, end));
            UpdateAvailabilityListBox();
        }

        private void UpdateAvailabilityListBox()
        {
            lstAvailability.Items.Clear();

            foreach (KeyValuePair<DayOfWeek, List<TimeRange>> pair in currentAvailability.WeeklyAvailability)
            {
                foreach (TimeRange range in pair.Value)
                {
                    lstAvailability.Items.Add(string.Format("{0}: {1}", pair.Key, range.ToString()));
                }
            }
        }

        private void lstAvailability_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstAvailability.SelectedItem != null)
            {
                string selectedText = lstAvailability.SelectedItem.ToString();
                MessageBox.Show(selectedText, "Availability Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvJudges_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = dgvJudges.Columns[e.ColumnIndex].HeaderText;
            if (columnName == "Availability")
            {
                ShowAvailabilityDetails(e.RowIndex, e.ColumnIndex);
            }
            else
            {
                LoadJudgeForEditing(e.RowIndex);
            }
        }

        private void ShowAvailabilityDetails(int rowIndex, int columnIndex)
        {
            object value = dgvJudges.Rows[rowIndex].Cells[columnIndex].Value;
            if (value != null)
            {
                MessageBox.Show(value.ToString(), "Availability Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadJudgeForEditing(int rowIndex)
        {
            int id = Convert.ToInt32(dgvJudges.Rows[rowIndex].Cells["ID"].Value);
            List<Judge> judges = judgeRepo.GetAllJudges();
            selectedJudge = judges.Find(j => j.ID == id);

            if (selectedJudge != null)
            {
                txtName.Text = selectedJudge.Name;
                txtExperience.Text = selectedJudge.YearsOfExperience.ToString();
                cmbLicense.SelectedItem = selectedJudge.License.ToString();
                txtLocation.Text = selectedJudge.Location;
                chkOutdoorPreference.Checked = selectedJudge.AcceptsOutdoorGames;
                currentAvailability = selectedJudge.Availability;
                UpdateAvailabilityListBox();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedJudge == null)
            {
                MessageBox.Show("Please select a judge to update.");
                return;
            }

            try
            {
                selectedJudge.Name = txtName.Text.Trim();
                selectedJudge.YearsOfExperience = int.Parse(txtExperience.Text);
                selectedJudge.License = (LicenseType)Enum.Parse(typeof(LicenseType), cmbLicense.SelectedItem.ToString());
                selectedJudge.Location = txtLocation.Text.Trim();
                selectedJudge.AcceptsOutdoorGames = chkOutdoorPreference.Checked;
                selectedJudge.Availability = currentAvailability;

                judgeRepo.UpdateJudge(selectedJudge);
                RefreshJudgeGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedJudge == null)
            {
                MessageBox.Show("Please select a judge to delete.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                string.Format("Are you sure you want to delete Judge '{0}'?", selectedJudge.Name),
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                judgeRepo.DeleteJudge(selectedJudge.ID);
                RefreshJudgeGrid();
                ClearForm();
            }
        }
    }
}
