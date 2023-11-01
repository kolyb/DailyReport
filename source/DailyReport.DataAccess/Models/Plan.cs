namespace DailyReport.DataAccess.Models
{
    public class Plan
    {
        public int Id { get; set; }

        public int? PersonId { get; set; }

        public int? PlanDayId { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? FinishTime { get; set; }

        public TimeSpan? IntervalTime { get; set; }
    }
}
