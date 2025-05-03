using final_project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace final_project.DataAccess
{
    public class JudgeRepository
    {
        private string connectionString = "Server=localhost;Database=basketball_db;Uid=admin;Pwd=admin;";

        // Method to get all judges along with their availability
        public List<Judge> GetAllJudges()
        {
            List<Judge> judges = new List<Judge>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Judges";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Judge judge = new Judge();
                            judge.ID = reader.GetInt32("ID");
                            judge.Name = reader.GetString("Name");
                            judge.YearsOfExperience = reader.GetInt32("YearsOfExperience");
                            judge.License = (LicenseType)Enum.Parse(typeof(LicenseType), reader.GetString("License"));
                            judge.Location = reader.GetString("Location");
                            judge.AcceptsOutdoorGames = reader.GetBoolean("AcceptsOutdoorGames");

                            // Load availability for this judge
                            LoadJudgeAvailability(judge);

                            judges.Add(judge);
                        }
                    }
                }
            }

            return judges;
        }

        private void LoadJudgeAvailability(Judge judge)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM JudgeAvailability WHERE JudgeID = @judgeID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@judgeID", judge.ID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JudgeAvailability availability = new JudgeAvailability
                            {
                                JudgeID = reader.GetInt32("JudgeID"),
                                Day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), reader.GetString("DayOfWeek")),
                                StartTime = reader.GetTimeSpan("StartTime"),
                                EndTime = reader.GetTimeSpan("EndTime")
                            };

                            judge.Availability.Add(availability);
                        }
                    }
                }
            }
        }

        public void AddJudge(Judge judge)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Judges 
                                 (Name, YearsOfExperience, License, Location, AcceptsOutdoorGames) 
                                 VALUES (@name, @exp, @license, @location, @outdoor)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, judge);
                    cmd.ExecuteNonQuery();

                    judge.ID = (int)cmd.LastInsertedId;

                    SaveJudgeAvailability(judge);
                }
            }
        }

        public void UpdateJudge(Judge judge)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Judges SET 
                                 Name = @name,
                                 YearsOfExperience = @exp,
                                 License = @license,
                                 Location = @location,
                                 AcceptsOutdoorGames = @outdoor
                                 WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, judge);
                    cmd.Parameters.AddWithValue("@id", judge.ID);
                    cmd.ExecuteNonQuery();

                    SaveJudgeAvailability(judge);
                }
            }
        }

        // Save or update the judge's availability in the database
        private void SaveJudgeAvailability(Judge judge)
        {
            // Delete existing availability records
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM JudgeAvailability WHERE JudgeID = @judgeID";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@judgeID", judge.ID);
                    cmd.ExecuteNonQuery();
                }

                // Insert new availability records
                foreach (var availability in judge.Availability)
                {
                    string insertQuery = @"INSERT INTO JudgeAvailability 
                                           (JudgeID, DayOfWeek, StartTime, EndTime) 
                                           VALUES (@judgeID, @dayOfWeek, @startTime, @endTime)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@judgeID", judge.ID);
                        cmd.Parameters.AddWithValue("@dayOfWeek", availability.Day.ToString());
                        cmd.Parameters.AddWithValue("@startTime", availability.StartTime);
                        cmd.Parameters.AddWithValue("@endTime", availability.EndTime);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteJudge(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Judges WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AddParameters(MySqlCommand cmd, Judge judge)
        {
            cmd.Parameters.AddWithValue("@name", judge.Name);
            cmd.Parameters.AddWithValue("@exp", judge.YearsOfExperience);
            cmd.Parameters.AddWithValue("@license", judge.License.ToString());
            cmd.Parameters.AddWithValue("@location", judge.Location);
            cmd.Parameters.AddWithValue("@outdoor", judge.AcceptsOutdoorGames);
        }
    }
}
