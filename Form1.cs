using System;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form1 : Form
    {
        public Form1()
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
            MessageBox.Show("Navigate to Manage Games");
        }

        private void btnMonthlyAssignment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigate to Monthly Assignment");
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigate to View Schedule");
        }
    }
}
