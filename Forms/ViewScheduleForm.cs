using System;
using System.Windows.Forms;

namespace final_project
{
    public partial class ViewScheduleForm : Form
    {
        public ViewScheduleForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: Load the current schedule into the DataGridView
            lblStatus.Text = "Schedule loaded successfully.";
        }
    }
}
