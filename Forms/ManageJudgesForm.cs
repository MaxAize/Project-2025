using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using final_project.Models;

namespace final_project
{
    public partial class ManageJudgesForm : Form
    {
        private List<Judge> judges = new List<Judge>();
        private int nextJudgeId = 1;
        private AvailabilitySchedule currentAvailability = new AvailabilitySchedule();
        private Judge selectedJudge = null;

        public ManageJudgesForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var judge = createNewJudge();
                judges.Add(judge);
                RefreshJudgeGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private Judge createNewJudge()
        {
            return new Judge
            {
                ID = nextJudgeId++,
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
            dgvJudges.DataSource = null;
            dgvJudges.DataSource = judges.Select(judge => new
            {
                judge.ID,
                judge.Name,
                judge.YearsOfExperience,
                License = judge.License.ToString(),
                judge.Location,
                Outdoor = judge.AcceptsOutdoorGames ? "Yes" : "No",
                Availability = judge.AvailabilitySummary
            }).ToList();

            dgvJudges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJudges.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJudges_CellDoubleClick);
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
        }

        private AvailabilitySchedule ParseAvailability(string input)
        {
            var schedule = new AvailabilitySchedule();
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ' }, 2);

                if (parts.Length != 2)
                {
                    return schedule;
                }

                bool validDay = Enum.TryParse(parts[0], true, out DayOfWeek day);

                if (!validDay)
                {
                    return schedule;
                }

                if (!ParseAndAddTimeRanges(schedule, day, parts[1]))
                {
                    return schedule;
                }

            }

            return schedule;
        }

        private bool ParseAndAddTimeRanges(AvailabilitySchedule schedule, DayOfWeek day, string timeRangesString)
        {
            var timeRanges = timeRangesString.Split(',');

            foreach (var timeRange in timeRanges)
            {
                var range = timeRange.Trim().Split('-');

                if (range.Length != 2)
                {
                    return false;
                }

                bool validStart = TimeSpan.TryParse(range[0], out var start);
                bool validEnd = TimeSpan.TryParse(range[1], out var end);

                if (!validStart || !validEnd)
                {
                    return false;
                }


                if (!schedule.WeeklyAvailability.ContainsKey(day))
                {
                    schedule.WeeklyAvailability[day] = new List<TimeRange>();
                }

                schedule.WeeklyAvailability[day].Add(new TimeRange(start, end));
            }

            return true;
        }

        private void btnAddTimeRange_Click(object sender, EventArgs e)
        {
            if (cmbDayOfWeek.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a day.");
                return;
            }

            var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), cmbDayOfWeek.SelectedItem.ToString());
            var start = dtpStartTime.Value.TimeOfDay;
            var end = dtpEndTime.Value.TimeOfDay;

            if (start >= end)
            {
                MessageBox.Show("Start time must be before end time.");
                return;
            }

            if (!currentAvailability.WeeklyAvailability.ContainsKey(day))
                currentAvailability.WeeklyAvailability[day] = new List<TimeRange>();

            currentAvailability.WeeklyAvailability[day].Add(new TimeRange(start, end));
            UpdateAvailabilityListBox();
        }

        private void UpdateAvailabilityListBox()
        {
            lstAvailability.Items.Clear();

            foreach (var pair in currentAvailability.WeeklyAvailability)
            {
                foreach (var range in pair.Value)
                {
                    lstAvailability.Items.Add($"{pair.Key}: {range}");
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

            var clickedColumn = dgvJudges.Columns[e.ColumnIndex];

            if (clickedColumn.HeaderText == "Availability")
            {
                ShowAvailabilityDetails(e.RowIndex, e.ColumnIndex);
                return;
            }

            LoadJudgeForEditing(e.RowIndex);
        }

        private void ShowAvailabilityDetails(int rowIndex, int columnIndex)
        {
            var value = dgvJudges.Rows[rowIndex].Cells[columnIndex].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show(value, "Availability Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadJudgeForEditing(int rowIndex)
        {
            selectedJudge = judges[rowIndex];
            txtName.Text = selectedJudge.Name;
            txtExperience.Text = selectedJudge.YearsOfExperience.ToString();
            cmbLicense.SelectedItem = selectedJudge.License.ToString();
            txtLocation.Text = selectedJudge.Location;
            chkOutdoorPreference.Checked = selectedJudge.AcceptsOutdoorGames;
            currentAvailability = selectedJudge.Availability;
            UpdateAvailabilityListBox();
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

                RefreshJudgeGrid();
                ClearForm();
                selectedJudge = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
