using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class PlanValidator
    {
        public static bool PersonExistsInPlan(int? personid, int? plandayid,
            IRepository<Plan> repositoryPlan)
        {
            return repositoryPlan.GetAll().Any(x => x.PersonId == personid && x.PlanDayId == plandayid);
        }

        public static bool StartTimeExistsInPlan(TimeSpan? starttime,
            IRepository<Plan> repositoryPlan)
        {
            return repositoryPlan.GetAll().Any(x => x.StartTime == starttime);
        }

        public static bool StartTimeCorrect(TimeSpan? starttime,
            IRepository<Plan> repositoryPlan)
        {
            return repositoryPlan.GetAll().Any(x => x.FinishTime > starttime);
        }

        //public static bool FinishTimeCorrect(TimeSpan? finishtime, TimeSpan? starttime,
        //            IRepository<Plan> repositoryPlan)
        //{
        //    return repositoryPlan.GetAll().Any(x => x.StartTime >= finishtime
        //    || starttime >= finishtime);
        //}
    }
}
