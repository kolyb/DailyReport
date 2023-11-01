using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class PlanDayValidator
    {
        public static bool PlanDayExists(DateTime? day, string? username, 
            IRepository<PlanDay> repositoryPlanDay)
        {
            return repositoryPlanDay.GetAll().Any(x => x.Day == day 
            && x.UserName == username);
        }
        public static bool PlanDayIsToday(DateTime? day)
        {
            return DateTime.Today == day;
        }
    } 
}
