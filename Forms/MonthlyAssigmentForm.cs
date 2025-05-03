using final_project.Models;
using final_project.DataAccess;
using System;
using System.Linq;
using System.Windows.Forms;
using final_project.Services;

namespace final_project
{
    public partial class MonthlyAssigmentForm : Form
    {
        private SchedulerService scheduler;
        private AssignmentResultRepository assignmentResultRepo;

        public MonthlyAssigmentForm()
        {
            InitializeComponent();
            scheduler = new SchedulerService();
            assignmentResultRepo = new AssignmentResultRepository();
        }

        // Generate assignment and save it to the database
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Clear any existing assignments
            scheduler.GenerateInitialAssignments();
            scheduler.PerformTabuSearch();

            // Save assignment results to the database
            foreach (var result in scheduler.AssignedResults)
            {
                assignmentResultRepo.AddAssignmentResult(result);
            }

            // Fetch all assignment results and display them in the DataGridView
            var displayData = assignmentResultRepo.GetAllAssignments().Select(a => new
            {
                GameID = a.Game.ID,
                GameDate = a.Game.DateTime.ToString("dd/MM/yyyy HH:mm"),
                GameLocation = a.Game.Location,
                League = a.Game.League.ToString(),
                Referee = a.Referee.Name,
                License = a.Referee.License.ToString()
            }).ToList();

            dgvAssignmentResults.DataSource = displayData;
            lblStatus.Text = "Assignment generated and optimized!";
        }

        // Reset the DataGridView when clicking Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvAssignmentResults.DataSource = null;
            lblStatus.Text = "Assignment reset.";
        }
    }
}
