using final_project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace final_project.DataAccess
{
    public class RefereeRepository
    {
        private string connectionString = "Server=localhost;Database=basketball_db;Uid=admin;Pwd=admin;";

        // Method to get all referees along with their availability
        public List<Referee> GetAllReferees()
        {
            List<Referee> referees = new List<Referee>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM referees";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Referee referee = new Referee();
                            referee.ID = reader.GetInt32("ID");
                            referee.Name = reader.GetString("Name");
                            referee.YearsOfExperience = reader.GetInt32("YearsOfExperience");
                            referee.License = (LicenseType)Enum.Parse(typeof(LicenseType), reader.GetString("License"));
                            referee.Location = reader.GetString("Location");
                            referee.AcceptsOutdoorGames = reader.GetBoolean("AcceptsOutdoorGames");

                            // Load availability for this referee
                            LoadRefereeAvailability(referee);

                            referees.Add(referee);
                        }
                    }
                }
            }

            return referees;
        }

        private void LoadRefereeAvailability(Referee referee)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM RefereeAvailability WHERE RefereeID = @refereeID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@refereeID", referee.ID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RefereeAvailability availability = new RefereeAvailability
                            {
                                RefereeID = reader.GetInt32("RefereeID"),
                                Day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), reader.GetString("DayOfWeek")),
                                StartTime = reader.GetTimeSpan("StartTime"),
                                EndTime = reader.GetTimeSpan("EndTime")
                            };

                            referee.Availability.Add(availability);
                        }
                    }
                }
            }
        }

        public void AddReferee(Referee referee)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO referees 
                                 (Name, YearsOfExperience, License, Location, AcceptsOutdoorGames) 
                                 VALUES (@name, @exp, @license, @location, @outdoor)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, referee);
                    cmd.ExecuteNonQuery();

                    referee.ID = (int)cmd.LastInsertedId;

                    SaveRefereeAvailability(referee);
                }
            }
        }

        public void UpdateReferee(Referee referee)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE referees SET 
                                 Name = @name,
                                 YearsOfExperience = @exp,
                                 License = @license,
                                 Location = @location,
                                 AcceptsOutdoorGames = @outdoor
                                 WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, referee);
                    cmd.Parameters.AddWithValue("@id", referee.ID);
                    cmd.ExecuteNonQuery();

                    SaveRefereeAvailability(referee);
                }
            }
        }

        // Save or update the referee's availability in the database
        private void SaveRefereeAvailability(Referee referee)
        {
            // Delete existing availability records
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM RefereeAvailability WHERE RefereeID = @refereeID";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@refereeID", referee.ID);
                    cmd.ExecuteNonQuery();
                }

                // Insert new availability records
                foreach (var availability in referee.Availability)
                {
                    string insertQuery = @"INSERT INTO RefereeAvailability 
                                           (RefereeID, DayOfWeek, StartTime, EndTime) 
                                           VALUES (@refereeID, @dayOfWeek, @startTime, @endTime)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@refereeID", referee.ID);
                        cmd.Parameters.AddWithValue("@dayOfWeek", availability.Day.ToString());
                        cmd.Parameters.AddWithValue("@startTime", availability.StartTime);
                        cmd.Parameters.AddWithValue("@endTime", availability.EndTime);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteReferee(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM referees WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AddParameters(MySqlCommand cmd, Referee referee)
        {
            cmd.Parameters.AddWithValue("@name", referee.Name);
            cmd.Parameters.AddWithValue("@exp", referee.YearsOfExperience);
            cmd.Parameters.AddWithValue("@license", referee.License.ToString());
            cmd.Parameters.AddWithValue("@location", referee.Location);
            cmd.Parameters.AddWithValue("@outdoor", referee.AcceptsOutdoorGames);
        }
    }
}
