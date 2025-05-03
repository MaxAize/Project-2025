namespace final_project.Models
{
    public class AssignmentResult
    {
        public int ID { get; set; }
        public Game Game { get; set; }
        public Referee Referee { get; set; }

        public override string ToString()
        {
            return $"{Referee.Name} assigned to {Game.League} on {Game.DateTime:dd/MM/yyyy HH:mm}";
        }
    }
}
