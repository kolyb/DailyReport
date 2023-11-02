using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class ReportValidator
    {
        public static bool PersonExistsInReport(int? personid, int? reportdayid,
            IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x => x.PersonId == personid && x.ReportDayId == reportdayid);
        }

        public static bool StartTimeExistsInReport(TimeSpan? starttime, int? reportdayid,
            IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x => x.StartTime == starttime && x.ReportDayId == reportdayid);
        }

        public static bool FinishTimeExistsInReport(TimeSpan? finishtime, int? reportdayid,
            IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x => x.FinishTime == finishtime && x.ReportDayId == reportdayid);
        }

        public static bool StartTimeCorrect(TimeSpan? starttime, int? reportdayid,
            IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x => x.FinishTime > starttime && x.ReportDayId == reportdayid);
        }

        public static bool FinishTimeEqualStartTime(TimeSpan? starttime,
            TimeSpan? finishtime)
        {
            return starttime == finishtime;
        }

        public static bool FinishTimeLessThanlStartTime(TimeSpan? starttime,
            TimeSpan? finishtime)
        {
            return starttime > finishtime;
        }
    }
}
