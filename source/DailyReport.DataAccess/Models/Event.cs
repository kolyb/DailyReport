namespace DailyReport.DataAccess.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public DateTime EventTime { get; set; }
    }
}
