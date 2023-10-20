namespace DailyReport.DataAccess.Models
{
    public class Report
    {
        public int Id {  get; set; }

        public int PersonId { get; set; }

        public int ReportDayId { get; set; }

        public TimeSpan Time { get; set; }
    }
}
