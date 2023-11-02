using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class ReportDayValidator
    {
        public static bool ReportDayExists(DateTime? recordday, string? username,
            IRepository<ReportDay> repositoryReportDay)
        {
            return repositoryReportDay.GetAll().Any(x => x.RecordDay == recordday
            && x.UserName == username);
        }
        public static bool ReportDayMoreThanToday(DateTime? day)
        {
            return DateTime.Today < day;
        }
    }
}
