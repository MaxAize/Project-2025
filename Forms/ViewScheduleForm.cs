using final_project.DataAccess;
using final_project.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace final_project
{
    public partial class ViewScheduleForm : Form
    {
        private AssignmentResultRepository assignmentResultRepository;

        public ViewScheduleForm()
        {
            InitializeComponent();
            assignmentResultRepository = new AssignmentResultRepository();
            LoadSchedule();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading schedule...";
            LoadSchedule();
            lblStatus.Text = "Schedule loaded successfully.";
        }

        private void LoadSchedule()
        {
            var assignments = assignmentResultRepository.GetAllAssignments();
            var displayData = assignments.Select(a => new
            {
                GameID = a.Game.ID,
                GameDate = a.Game.DateTime.ToString("dd/MM/yyyy HH:mm"),
                GameLocation = a.Game.Location,
                League = a.Game.League.ToString(),
                Referee = a.Referee.Name,
                License = a.Referee.License.ToString(),
                RefereeID = a.Referee.ID
            }).ToList();
            dgvSchedule.DataSource = displayData;
            AddHiddenRefereeIDColumn();
        }

        private void AddHiddenRefereeIDColumn()
        {
            if (!dgvSchedule.Columns.Contains("RefereeID"))
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    Name = "RefereeID",
                    HeaderText = "RefereeID",
                    Visible = false
                };
                dgvSchedule.Columns.Add(column);
            }
        }

        private void btnDeleteAssignment_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSchedule.SelectedRows[0];
                int gameId = Convert.ToInt32(selectedRow.Cells["GameID"].Value);
                int refereeId = Convert.ToInt32(selectedRow.Cells["RefereeID"].Value);
                ConfirmDelete(gameId, refereeId);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void ConfirmDelete(int gameId, int refereeId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this assignment?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteAssignment(gameId, refereeId);
            }
        }

        private void DeleteAssignment(int gameId, int refereeId)
        {
            var assignmentToDelete = assignmentResultRepository.GetAllAssignments()
                .FirstOrDefault(a => a.Game.ID == gameId && a.Referee.ID == refereeId);
            if (assignmentToDelete != null)
            {
                assignmentResultRepository.DeleteAssignmentResult(assignmentToDelete.ID);
                MessageBox.Show("Assignment successfully deleted!");
                LoadSchedule();
            }
            else
            {
                MessageBox.Show("Assignment not found!");
            }
        }
    }
}
