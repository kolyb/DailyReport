using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public static class WorkLocationMapper
    {
        public static WorkLocation FromDTO(WorkLocationDTO item)
        {
            WorkLocation workLocation = new WorkLocation
            {
                Id = item.Id,
                PersonId = item.PersonId,
                Description = item.Description,
                AdressWorkLocation = item.AdressWorkLocation,
            };
            return workLocation;
        }

        public static WorkLocationDTO ToDTO(WorkLocation item)
        {
            WorkLocationDTO workLoacationDTO = new WorkLocationDTO
            {
                Id = item.Id,
                PersonId = item.PersonId,
                Description = item.Description,
                AdressWorkLocation = item.AdressWorkLocation,
            };
            return workLoacationDTO;
        }

        public static List<WorkLocationDTO> ToDTO(List<WorkLocation> list)
        {
            List<WorkLocationDTO> workLocationDTOs = new List<WorkLocationDTO>();
            foreach (var item in list)
            {
                workLocationDTOs.Add(new WorkLocationDTO
                {
                    Id = item.Id,
                    PersonId = item.PersonId,
                    Description = item.Description,
                    AdressWorkLocation = item.AdressWorkLocation,
                });
            }
            return workLocationDTOs;
        }
    }
}
