using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using final_project.DataAccess;
using final_project.Models;

namespace final_project
{
    public partial class ManageGamesForm : Form
    {
        private GameRepository gameRepo = new GameRepository();
        private Game selectedGame = null;

        public ManageGamesForm()
        {
            InitializeComponent();
            RefreshGameGrid();
        }

        private void ManageGamesForm_Load(object sender, EventArgs e)
        {
            RefreshGameGrid();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Game newGame = CreateGameFromForm();
                gameRepo.AddGame(newGame);
                RefreshGameGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding game: " + ex.Message);
            }
        }

        private Game CreateGameFromForm()
        {
            return new Game
            {
                DateTime = dtpGameDate.Value,
                Location = txtLocation.Text.Trim(),
                League = (LeagueType)Enum.Parse(typeof(LeagueType), cmbLeague.SelectedItem.ToString()),
                IsPlayoff = chkPlayoff.Checked,
                ImportanceRating = (int)numImportance.Value,
                Field = (FieldType)Enum.Parse(typeof(FieldType), cmbFieldType.SelectedItem.ToString())
            };
        }

        private void RefreshGameGrid()
        {
            List<Game> games = gameRepo.GetAllGames();

            dgvGames.DataSource = null;
            dgvGames.DataSource = games.Select(g => new
            {
                g.ID,
                Date = g.DateTime.ToString("dd/MM/yyyy HH:mm"),
                g.Location,
                League = g.League.ToString(),
                Playoff = g.IsPlayoff ? "Yes" : "No",
                g.ImportanceRating,
                Field = g.Field.ToString()
            }).ToList();

            dgvGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGames.CellDoubleClick += dgvGames_CellDoubleClick;
        }

        private void ClearForm()
        {
            txtLocation.Text = "";
            cmbLeague.SelectedIndex = -1;
            chkPlayoff.Checked = false;
            cmbFieldType.SelectedIndex = -1;
            numImportance.Value = 0;
            dtpGameDate.Value = DateTime.Now;
            selectedGame = null;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvGames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvGames.Rows[e.RowIndex].Cells["ID"].Value);
            List<Game> games = gameRepo.GetAllGames();
            selectedGame = games.FirstOrDefault(g => g.ID == id);

            if (selectedGame != null)
            {
                txtLocation.Text = selectedGame.Location;
                cmbLeague.SelectedItem = selectedGame.League.ToString();
                chkPlayoff.Checked = selectedGame.IsPlayoff;
                cmbFieldType.SelectedItem = selectedGame.Field.ToString();
                numImportance.Value = selectedGame.ImportanceRating;
                dtpGameDate.Value = selectedGame.DateTime;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedGame == null)
            {
                MessageBox.Show("Please select a game to update.");
                return;
            }

            try
            {
                selectedGame.DateTime = dtpGameDate.Value;
                selectedGame.Location = txtLocation.Text.Trim();
                selectedGame.League = (LeagueType)Enum.Parse(typeof(LeagueType), cmbLeague.SelectedItem.ToString());
                selectedGame.IsPlayoff = chkPlayoff.Checked;
                selectedGame.ImportanceRating = (int)numImportance.Value;
                selectedGame.Field = (FieldType)Enum.Parse(typeof(FieldType), cmbFieldType.SelectedItem.ToString());

                gameRepo.UpdateGame(selectedGame);
                RefreshGameGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating game: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedGame == null)
            {
                MessageBox.Show("Please select a game to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete the game at '{selectedGame.Location}' on {selectedGame.DateTime:dd/MM/yyyy HH:mm}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                gameRepo.DeleteGame(selectedGame.ID);
                RefreshGameGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting game: " + ex.Message);
            }
        }
    }
}
