using System.ComponentModel.DataAnnotations;

namespace DailyReport.BusinessLogic.ModelsDTO
{
    public class PlanDTO
    {
        public int Id { get; set; }

        //public int UserIdentityId { get; set; }

        public int PersonId { get; set; }

        public int PlanDayId { get; set; }

        public TimeSpan PlanTime { get; set; }
    }
}
