using System;
using System.Collections.Generic;

namespace final_project.Models
{
    public enum LeagueType
    {
        First,
        Second,
        Third
    }

    public enum FieldType
    {
        Indoor,
        Outdoor
    }

    public class Game
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public LeagueType League { get; set; }
        public bool IsPlayoff { get; set; }
        public int ImportanceRating { get; set; }
        public FieldType Field { get; set; }

        // Optional: Assigned Referres
        public List<int> AssignedReferresIds { get; set; }

        public Game()
        {
            AssignedReferresIds = new List<int>();
        }

        public override string ToString()
        {
            return $"{League} League - {DateTime:dd/MM/yyyy HH:mm} @ {Location}";
        }
    }
}
