using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class PlanDateMapper
    {
        public static PlanDate FromDTO(PlanDateDTO item)
        {
            PlanDate planDate = new PlanDate
            {
                Id = item.Id,
                PlanDay = item.PlanDay,

            };
            return planDate;
        }

        public static PlanDateDTO ToDTO(PlanDate item)
        {
            PlanDateDTO planDateDTO = new PlanDateDTO
            {
                Id = item.Id,
                PlanDay = item.PlanDay,

            };
            return planDateDTO;
        }

        public static List<PlanDateDTO> ToDTO(List<PlanDate> list)
        {
            List<PlanDateDTO> planDateDTOs = new List<PlanDateDTO>();
            foreach (var item in list)
            {
                planDateDTOs.Add(new PlanDateDTO
                {
                    Id = item.Id,
                    PlanDay = item.PlanDay,
                });
            }
            return planDateDTOs;
        }
    }
}
