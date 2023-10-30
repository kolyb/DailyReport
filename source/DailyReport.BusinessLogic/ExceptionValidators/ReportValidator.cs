using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class ReportValidator
    {
        public static bool PersonExistsInReport(int? personid,
            IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x =>x.PersonId == personid);
        }

        public static bool StartTimeExistsInReport(TimeSpan? starttime,
            IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x => x.StartTime == starttime);
        }

        public static bool StartTimeCorrect(TimeSpan? starttime,
            IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x => x.FinishTime >= starttime);
        }

        public static bool FinishTimeCorrect(TimeSpan? finishtime, TimeSpan? starttime,
                    IRepository<Report> repositoryReport)
        {
            return repositoryReport.GetAll().Any(x => x.StartTime >= finishtime
            || finishtime <= starttime);
        }
    }
}
