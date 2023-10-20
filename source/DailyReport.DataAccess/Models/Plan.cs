namespace DailyReport.DataAccess.Models
{
    public class Plan
    {
        public int Id { get; set; }

        //public int UserIdentityId { get; set; }

        public int PersonId { get; set; }

        public int PlanDayId { get; set; }

        public TimeSpan PlanTime { get; set; }
    }
}
