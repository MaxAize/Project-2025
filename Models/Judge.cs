using System;
using System.Collections.Generic;
using System.Linq;

namespace final_project.Models
{
    public enum LicenseType
    {
        A, B, C
    }

    public class Judge
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public LicenseType License { get; set; }
        public string Location { get; set; }
        public bool AcceptsOutdoorGames { get; set; }

        // Availability is now a list of JudgeAvailability records
        public List<JudgeAvailability> Availability { get; set; }

        public string AvailabilitySummary
        {
            get
            {
                if (Availability == null || Availability.Count == 0)
                {
                    return "Not Set";
                }

                return string.Join("; ",
                    Availability.Select(avail => $"{avail.Day}: {avail.StartTime:hh\\:mm} - {avail.EndTime:hh\\:mm}"));
            }
        }

        public Judge()
        {
            Availability = new List<JudgeAvailability>();
        }
    }

    public class JudgeAvailability
    {
        public int JudgeID { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
