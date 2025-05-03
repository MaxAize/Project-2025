using System;
using System.Linq;
using System.Windows.Forms;
using final_project.DataAccess;
using final_project.Models;

namespace final_project
{
    public partial class ViewScheduleForm : Form
    {
        private AssignmentResultRepository _assignmentResultRepository;

        public ViewScheduleForm()
        {
            InitializeComponent();
            _assignmentResultRepository = new AssignmentResultRepository();
            LoadSchedule();
        }

        // When the form is closed, dispose of resources properly.
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Refresh the schedule and show a loading indicator.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading schedule...";
            LoadSchedule();
            lblStatus.Text = "Schedule loaded successfully.";
        }

        // Synchronously loads the schedule from the database and updates the DataGridView.
        private void LoadSchedule()
        {
            // Fetch assignments from the repository
            var assignments = _assignmentResultRepository.GetAllAssignments();

            // Format the data for displaying in the DataGridView
            var displayData = assignments.Select(a => new
            {
                GameID = a.Game.ID,
                GameDate = a.Game.DateTime.ToString("dd/MM/yyyy HH:mm"),
                GameLocation = a.Game.Location,
                League = a.Game.League.ToString(),
                Referee = a.Referee.Name,
                License = a.Referee.License.ToString()
            }).ToList();

            // Bind the formatted data to the DataGridView.
            dgvSchedule.DataSource = displayData;
        }
    }
}
