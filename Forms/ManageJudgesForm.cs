using final_project.Models;
using final_project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace final_project
{
    public partial class ManageJudgesForm : Form
    {
        private JudgeRepository judgeRepo = new JudgeRepository();
        private AvailabilitySchedule currentAvailability = new AvailabilitySchedule();
        private Judge selectedJudge = null;
        private List<JudgeAvailability> ConvertToJudgeAvailability(AvailabilitySchedule schedule, int judgeId)
        {
            var list = new List<JudgeAvailability>();

            foreach (var entry in schedule.WeeklyAvailability)
            {
                foreach (var timeRange in entry.Value)
                {
                    list.Add(new JudgeAvailability
                    {
                        JudgeID = judgeId,
                        Day = entry.Key,
                        StartTime = timeRange.Start,
                        EndTime = timeRange.End
                    });
                }
            }

            return list;
        }


        private AvailabilitySchedule ConvertToAvailabilitySchedule(List<JudgeAvailability> dbAvailability)
        {
            var schedule = new AvailabilitySchedule();

            foreach (var entry in dbAvailability)
            {
                if (!schedule.WeeklyAvailability.ContainsKey(entry.Day))
                {
                    schedule.WeeklyAvailability[entry.Day] = new List<TimeRange>();
                }

                schedule.WeeklyAvailability[entry.Day].Add(new TimeRange(entry.StartTime, entry.EndTime));
            }

            return schedule;
        }


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
                Availability = ConvertToJudgeAvailability(currentAvailability, 0)
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
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvJudges.Rows[e.RowIndex].Cells["ID"].Value);
            List<Judge> judges = judgeRepo.GetAllJudges();
            selectedJudge = judges.FirstOrDefault(j => j.ID == id);

            if (selectedJudge != null)
            {
                txtName.Text = selectedJudge.Name;
                txtExperience.Text = selectedJudge.YearsOfExperience.ToString();
                cmbLicense.SelectedItem = selectedJudge.License.ToString();
                txtLocation.Text = selectedJudge.Location;
                chkOutdoorPreference.Checked = selectedJudge.AcceptsOutdoorGames;
                currentAvailability = ConvertToAvailabilitySchedule(selectedJudge.Availability);
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
                selectedJudge.Availability = ConvertToJudgeAvailability(currentAvailability, selectedJudge.ID);

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
