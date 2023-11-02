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

        public static bool StartTimeExistsInPlan(TimeSpan? starttime, int? plandayid,
            IRepository<Plan> repositoryPlan)
        {
            return repositoryPlan.GetAll().Any(x => x.StartTime == starttime && x.PlanDayId == plandayid);
        }

        public static bool StartTimeCorrect(TimeSpan? starttime, int? plandayid,
            IRepository<Plan> repositoryPlan)
        {
            return repositoryPlan.GetAll().Any(x => x.FinishTime > starttime && x.PlanDayId == plandayid);
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
        //public static bool FinishTimeCorrect(TimeSpan? finishtime, TimeSpan? starttime,
        //            IRepository<Plan> repositoryPlan)
        //{
        //    return repositoryPlan.GetAll().Any(x => x.StartTime >= finishtime
        //    || starttime >= finishtime);
        //}
    }
}
