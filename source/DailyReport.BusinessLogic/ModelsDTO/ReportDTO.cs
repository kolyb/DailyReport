namespace DailyReport.BusinessLogic.ModelsDTO
{
    public class ReportDTO
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int ReportDayId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public TimeSpan IntervalTime { get; set; }
    }
}
