using System;
using System.Windows.Forms;

namespace final_project
{
    public partial class MonthlyAssigmentForm : Form
    {
        public MonthlyAssigmentForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // TODO: Add call to Greedy + Tabu Assignment logic
            lblStatus.Text = "Assignment generated!";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // TODO: Clear assignment result
            dgvAssignmentResults.DataSource = null;
            lblStatus.Text = "Assignment reset.";
        }
    }
}
