﻿namespace DailyReport.BusinessLogic.ModelsDTO
{
    public class ReportDTO
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int PlanDateId { get; set; }

        public TimeSpan Time { get; set; }
    }
}