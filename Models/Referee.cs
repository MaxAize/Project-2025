using System;
using System.Collections.Generic;
using System.Linq;

namespace final_project.Models
{
    public enum LicenseType
    {
        A, B, C
    }

    public class Referee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public LicenseType License { get; set; }
        public string Location { get; set; }
        public bool AcceptsOutdoorGames { get; set; }

        // Availability is now a list of RefereeAvailability records
        public List<RefereeAvailability> Availability { get; set; }

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

        public Referee()
        {
            Availability = new List<RefereeAvailability>();
        }
    }

    public class RefereeAvailability
    {
        public int RefereeID { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
