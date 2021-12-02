namespace OOPCourse.Domain.Models
{
    public class Assassin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal LowRewardBound { get; set; }
        public decimal HighRewardBound { get; set; }
        public bool Status { get; set; }
    }
}
