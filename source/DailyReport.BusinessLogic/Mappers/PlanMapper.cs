using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class PlanMapper
    {
        public static Plan FromDTO(PlanDTO item)
        {
            Plan plan = new Plan
            {
                Id = item.Id,
                //UserIdentityId = item.UserIdentityId,
                PersonId = item.PersonId,
                PlanDayId = item.PlanDayId,
                PlanTime = item.PlanTime,
            };
            return plan;
        }

        public static PlanDTO ToDTO(Plan item)
        {
            PlanDTO planDTO = new PlanDTO
            {
                Id = item.Id,
                //UserIdentityId = item.UserIdentityId,
                PersonId = item.PersonId,
                PlanDayId = item.PlanDayId,
                PlanTime = item.PlanTime,
            };
            return planDTO;
        }

        public static List<PlanDTO> ToDTO(List<Plan> list)
        {
            List<PlanDTO> planDTOs = new List<PlanDTO>();
            foreach (var item in list)
            {
                planDTOs.Add(new PlanDTO
                {
                    Id = item.Id,
                    //UserIdentityId = item.UserIdentityId,
                    PersonId = item.PersonId,
                    PlanDayId = item.PlanDayId,
                    PlanTime = item.PlanTime,
                });
            }
            return planDTOs;
        }
    }
}
