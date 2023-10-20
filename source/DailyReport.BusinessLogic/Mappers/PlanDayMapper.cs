using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class PlanDayMapper
    {
        public static PlanDay FromDTO(PlanDayDTO item)
        {
            PlanDay planDay = new PlanDay
            {
                Id = item.Id,
                Day = item.Day,

            };
            return planDay;
        }

        public static PlanDayDTO ToDTO(PlanDay item)
        {
            PlanDayDTO planDayDTO = new PlanDayDTO
            {
                Id = item.Id,
                Day = item.Day,

            };
            return planDayDTO;
        }

        public static List<PlanDayDTO> ToDTO(List<PlanDay> list)
        {
            List<PlanDayDTO> planDayDTOs = new List<PlanDayDTO>();
            foreach (var item in list)
            {
                planDayDTOs.Add(new PlanDayDTO
                {
                    Id = item.Id,
                    Day = item.Day,
                });
            }
            return planDayDTOs;
        }
    }
}
