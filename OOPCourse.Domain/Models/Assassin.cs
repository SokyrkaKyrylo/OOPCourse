namespace OOPCourse.Domain.Models
{
    public class Assassin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double LowRewardBound { get; set; }
        public double HighRewardBound { get; set; }
        public bool Status { get; set; }
    }
}
