namespace DailyReport.DataAccess.Models
{
    public class PlanDay
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public string? UserName { get; set; }
    }
}
