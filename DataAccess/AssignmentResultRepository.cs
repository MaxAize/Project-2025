using final_project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace final_project.DataAccess
{
    public class AssignmentResultRepository
    {
        private string connectionString = "Server=localhost;Database=basketball_db;Uid=admin;Pwd=admin;";

        // Method to save an assignment result to the database
        public void AddAssignmentResult(AssignmentResult assignmentResult)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO AssignmentResults 
                                 (GameID, RefereeID) 
                                 VALUES (@gameID, @refereeID)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gameID", assignmentResult.Game.ID);
                    cmd.Parameters.AddWithValue("@refereeID", assignmentResult.Referee.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to get all assignment results
        public List<AssignmentResult> GetAllAssignments()
        {
            List<AssignmentResult> assignments = new List<AssignmentResult>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT ar.ID, ar.GameID, ar.RefereeID, g.Location as GameLocation, 
                         g.DateTime as GameDateTime, r.Name as RefereeName, r.License as RefereeLicense 
                         FROM AssignmentResults ar
                         JOIN Games g ON ar.GameID = g.ID
                         JOIN Referees r ON ar.RefereeID = r.ID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssignmentResult assignment = new AssignmentResult
                            {
                                ID = reader.GetInt32("ID"),
                                Game = new Game
                                {
                                    ID = reader.GetInt32("GameID"),
                                    Location = reader.GetString("GameLocation"),
                                    DateTime = reader.GetDateTime("GameDateTime")
                                },
                                Referee = new Referee
                                {
                                    ID = reader.GetInt32("RefereeID"),
                                    Name = reader.GetString("RefereeName"),
                                    License = (LicenseType)Enum.Parse(typeof(LicenseType), reader.GetString("RefereeLicense"))
                                }
                            };

                            assignments.Add(assignment);
                        }
                    }
                }
            }

            return assignments;
        }

        // Method to update an assignment result
        public void UpdateAssignmentResult(AssignmentResult assignmentResult)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE AssignmentResults SET 
                                 GameID = @gameID, 
                                 RefereeID = @refereeID 
                                 WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gameID", assignmentResult.Game.ID);
                    cmd.Parameters.AddWithValue("@refereeID", assignmentResult.Referee.ID);
                    cmd.Parameters.AddWithValue("@id", assignmentResult.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to delete an assignment result by ID
        public void DeleteAssignmentResult(int assignmentResultID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM AssignmentResults WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", assignmentResultID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
