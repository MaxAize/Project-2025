using final_project.Models;
using final_project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace final_project
{
    public partial class ManageRefereesForm : Form
    {
        private RefereeRepository refereeRepo = new RefereeRepository();
        private AvailabilitySchedule currentAvailability = new AvailabilitySchedule();
        private Referee selectedReferee = null;
        private List<RefereeAvailability> ConvertToRefereeAvailability(AvailabilitySchedule schedule, int refereeId)
        {
            var list = new List<RefereeAvailability>();

            foreach (var entry in schedule.WeeklyAvailability)
            {
                foreach (var timeRange in entry.Value)
                {
                    list.Add(new RefereeAvailability
                    {
                        RefereeID = refereeId,
                        Day = entry.Key,
                        StartTime = timeRange.Start,
                        EndTime = timeRange.End
                    });
                }
            }

            return list;
        }


        private AvailabilitySchedule ConvertToAvailabilitySchedule(List<RefereeAvailability> dbAvailability)
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


        public ManageRefereesForm()
        {
            InitializeComponent();
            RefreshRefereeGrid();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Referee referee = CreateRefereeFromForm();
                refereeRepo.AddReferee(referee);
                RefreshRefereeGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private Referee CreateRefereeFromForm()
        {
            return new Referee
            {
                Name = txtName.Text.Trim(),
                YearsOfExperience = int.Parse(txtExperience.Text),
                License = (LicenseType)Enum.Parse(typeof(LicenseType), cmbLicense.SelectedItem.ToString()),
                Location = txtLocation.Text.Trim(),
                AcceptsOutdoorGames = chkOutdoorPreference.Checked,
                Availability = ConvertToRefereeAvailability(currentAvailability, 0)
            };
        }

        private void RefreshRefereeGrid()
        {
            List<Referee> referees = refereeRepo.GetAllReferees();

            dgvReferees.DataSource = null;
            dgvReferees.DataSource = referees.Select(referee => new
            {
                referee.ID,
                referee.Name,
                referee.YearsOfExperience,
                License = referee.License.ToString(),
                referee.Location,
                Outdoor = referee.AcceptsOutdoorGames ? "Yes" : "No",
                Availability = referee.AvailabilitySummary
            }).ToList();

            dgvReferees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReferees.CellDoubleClick += dgvReferees_CellDoubleClick;
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
            selectedReferee = null;
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

        private void dgvReferees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvReferees.Rows[e.RowIndex].Cells["ID"].Value);
            List<Referee> referees = refereeRepo.GetAllReferees();
            selectedReferee = referees.FirstOrDefault(referee => referee.ID == id);

            if (selectedReferee != null)
            {
                txtName.Text = selectedReferee.Name;
                txtExperience.Text = selectedReferee.YearsOfExperience.ToString();
                cmbLicense.SelectedItem = selectedReferee.License.ToString();
                txtLocation.Text = selectedReferee.Location;
                chkOutdoorPreference.Checked = selectedReferee.AcceptsOutdoorGames;
                currentAvailability = ConvertToAvailabilitySchedule(selectedReferee.Availability);
                UpdateAvailabilityListBox();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedReferee == null)
            {
                MessageBox.Show("Please select a referee to update.");
                return;
            }

            try
            {
                selectedReferee.Name = txtName.Text.Trim();
                selectedReferee.YearsOfExperience = int.Parse(txtExperience.Text);
                selectedReferee.License = (LicenseType)Enum.Parse(typeof(LicenseType), cmbLicense.SelectedItem.ToString());
                selectedReferee.Location = txtLocation.Text.Trim();
                selectedReferee.AcceptsOutdoorGames = chkOutdoorPreference.Checked;
                selectedReferee.Availability = ConvertToRefereeAvailability(currentAvailability, selectedReferee.ID);

                refereeRepo.UpdateReferee(selectedReferee);
                RefreshRefereeGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedReferee == null)
            {
                MessageBox.Show("Please select a referee to delete.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                string.Format("Are you sure you want to delete Referee '{0}'?", selectedReferee.Name),
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                refereeRepo.DeleteReferee(selectedReferee.ID);
                RefreshRefereeGrid();
                ClearForm();
            }
        }
    }
}
