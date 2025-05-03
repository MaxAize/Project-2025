using System;
using System.Windows.Forms;

namespace final_project
{
    public partial class MainScreenForm : Form
    {
        public MainScreenForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnManageJudges_Click(object sender, EventArgs e)
        {
            ManageJudgesForm judgesForm = new ManageJudgesForm();
            judgesForm.ShowDialog();
        }

        private void btnManageGames_Click(object sender, EventArgs e)
        {
            ManageGamesForm gamesForm = new ManageGamesForm();
            gamesForm.ShowDialog(); 
        }

        private void btnMonthlyAssignment_Click(object sender, EventArgs e)
        {
            MonthlyAssigmentForm assigmentForm = new MonthlyAssigmentForm();
            assigmentForm.ShowDialog();
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            ViewScheduleForm scheduleForm = new ViewScheduleForm();
            scheduleForm.ShowDialog();
        }
    }
}
