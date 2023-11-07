namespace DailyReport.WebLayer.Models
{
    public class PlanAndReportViewModel
    {   
        public int? Id { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? FinishTime { get; set; }

        public TimeSpan? IntervalTime { get; set; }

        public string? Lastname{ get; set; }

        public string? DescriptionWorkplace{ get; set; }
    }
}
