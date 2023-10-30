namespace DailyReport.BusinessLogic.ModelsDTO
{
    public class ReportDTO
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int ReportDayId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan FinishTime { get; set; }

        public TimeSpan IntervalTime { get; set; }
    }
}
