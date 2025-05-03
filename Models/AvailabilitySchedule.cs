using System;
using System.Collections.Generic;

namespace final_project.Models
{
    public class AvailabilitySchedule
    {
        // Dictionary where key = day of week, value = list of available time ranges
        public Dictionary<DayOfWeek, List<TimeRange>> WeeklyAvailability { get; set; }

        public AvailabilitySchedule()
        {
            WeeklyAvailability = new Dictionary<DayOfWeek, List<TimeRange>>();
        }
    }

    public class TimeRange
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public TimeRange(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"{Start:hh\\:mm} - {End:hh\\:mm}";
        }
    }
}
