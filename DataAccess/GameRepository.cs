using final_project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace final_project.DataAccess
{
    public class GameRepository
    {
        private string connectionString = "Server=localhost;Database=basketball_db;Uid=admin;Pwd=admin;";

        public void AddGame(Game game)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Games 
                    (DateTime, Location, League, IsPlayoff, ImportanceRating, Field) 
                    VALUES (@dateTime, @location, @league, @isPlayoff, @rating, @field)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dateTime", game.DateTime);
                    cmd.Parameters.AddWithValue("@location", game.Location);
                    cmd.Parameters.AddWithValue("@league", game.League.ToString());
                    cmd.Parameters.AddWithValue("@isPlayoff", game.IsPlayoff);
                    cmd.Parameters.AddWithValue("@rating", game.ImportanceRating);
                    cmd.Parameters.AddWithValue("@field", game.Field.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Games";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Game game = new Game();
                            game.ID = reader.GetInt32("ID");
                            game.DateTime = reader.GetDateTime("DateTime");
                            game.Location = reader.GetString("Location");
                            game.League = (LeagueType)Enum.Parse(typeof(LeagueType), reader.GetString("League"));
                            game.IsPlayoff = reader.GetBoolean("IsPlayoff");
                            game.ImportanceRating = reader.GetInt32("ImportanceRating");
                            game.Field = (FieldType)Enum.Parse(typeof(FieldType), reader.GetString("Field"));
                            games.Add(game);
                        }
                    }
                }
            }

            return games;
        }

        public void UpdateGame(Game game)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Games SET 
                            DateTime = @dateTime,
                            Location = @location,
                            League = @league,
                            IsPlayoff = @isPlayoff,
                            ImportanceRating = @rating,
                            Field = @field
                         WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dateTime", game.DateTime);
                    cmd.Parameters.AddWithValue("@location", game.Location);
                    cmd.Parameters.AddWithValue("@league", game.League.ToString());
                    cmd.Parameters.AddWithValue("@isPlayoff", game.IsPlayoff);
                    cmd.Parameters.AddWithValue("@rating", game.ImportanceRating);
                    cmd.Parameters.AddWithValue("@field", game.Field.ToString());
                    cmd.Parameters.AddWithValue("@id", game.ID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteGame(int gameId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Games WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", gameId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
