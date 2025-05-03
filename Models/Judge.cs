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

        public AvailabilitySchedule Availability { get; set; }

        public string AvailabilitySummary
        {
            get
            {
                if (Availability == null || Availability.WeeklyAvailability.Count == 0)
                {
                    return "Not Set";
                }    

                return string.Join("; ",
                    Availability.WeeklyAvailability
                    .Select(pair => $"{pair.Key}: {string.Join(", ", pair.Value)}"));
            }
        }

        public Judge()
        {
            Availability = new AvailabilitySchedule();
        }
    }
}
