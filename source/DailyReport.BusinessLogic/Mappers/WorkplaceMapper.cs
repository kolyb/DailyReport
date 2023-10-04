using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public static class WorkplaceMapper
    {
        public static Workplace FromDTO(WorkplaceDTO item)
        {
            Workplace workplace = new Workplace
            {
                Id = item.Id,
                Description = item.Description,
                AdressCity = item.AdressCity,
                AdressStreet = item.AdressStreet,
                AdressHouse = item.AdressHouse,
            };
            return workplace;
        }

        public static WorkplaceDTO ToDTO(Workplace item)
        {
            WorkplaceDTO workplaceDTO = new WorkplaceDTO
            {
                Id = item.Id,
                Description = item.Description,
                AdressCity = item.AdressCity,
                AdressStreet = item.AdressStreet,
                AdressHouse = item.AdressHouse,
            };
            return workplaceDTO;
        }

        public static List<WorkplaceDTO> ToDTO(List<Workplace> list)
        {
            List<WorkplaceDTO> workplaceDTOs = new List<WorkplaceDTO>();
            foreach (var item in list)
            {
                workplaceDTOs.Add(new WorkplaceDTO
                {
                    Id = item.Id,
                    Description = item.Description,
                    AdressCity = item.AdressCity,
                    AdressStreet = item.AdressStreet,
                    AdressHouse = item.AdressHouse,
                });
            }
            return workplaceDTOs;
        }
    }
}
