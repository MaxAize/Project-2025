using System;
using System.Windows.Forms;

namespace final_project
{
    public partial class ManageGamesForm : Form
    {
        public ManageGamesForm()
        {
            InitializeComponent();
        }

        private void ManageGamesForm_Load(object sender, EventArgs e)
        {
            // Future logic for loading existing games
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
