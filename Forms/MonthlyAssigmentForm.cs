using final_project.Models;
using final_project.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace final_project
{
    public partial class MonthlyAssigmentForm : Form
    {
        private SchedulerService scheduler;

        public MonthlyAssigmentForm()
        {
            InitializeComponent();
            scheduler = new SchedulerService();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            scheduler.GenerateInitialAssignments();
            scheduler.PerformTabuSearch();  // Optimize with Tabu Search

            var displayData = scheduler.AssignedResults.Select(a => new
            {
                GameDate = a.Game.DateTime.ToString("dd/MM/yyyy HH:mm"),
                GameLocation = a.Game.Location,
                League = a.Game.League.ToString(),
                Referee = a.Referee.Name,
                License = a.Referee.License.ToString()
            }).ToList();

            dgvAssignmentResults.DataSource = displayData;
            lblStatus.Text = "Assignment generated and optimized!";
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvAssignmentResults.DataSource = null;
            lblStatus.Text = "Assignment reset.";
        }
    }
}
