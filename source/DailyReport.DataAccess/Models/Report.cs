namespace DailyReport.DataAccess.Models
{
    public class Report
    {
        public int Id {  get; set; }

        public int PersonId { get; set; }

        public int ReportDayId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public TimeSpan IntervalTime { get; set; }
    }
}
