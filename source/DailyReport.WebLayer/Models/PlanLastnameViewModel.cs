namespace DailyReport.WebLayer.Models
{
    public class PlanLastnameViewModel
    {   
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public TimeSpan IntervalTime { get; set; }

        public string? Lastname{ get; set; }

        public string? DescriptionWorkplace{ get; set; }
    }
}
