using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class ProfessionMapper
    {
        public static Profession FromDTO(ProfessionDTO item)
        {
            Profession profession = new Profession
            {
                Id = item.Id,
                Description = item.Description,
            };
            return profession;
        }

        public static ProfessionDTO ToDTO(Profession item)
        {
            ProfessionDTO professionDTO = new ProfessionDTO
            {
                Id = item.Id,
                Description = item.Description,
            };
            return professionDTO;
        }

        public static List<ProfessionDTO> ToDTO(List<Profession> list)
        {
            List<ProfessionDTO> professionDTOs = new List<ProfessionDTO>();
            foreach (var item in list)
            {
                professionDTOs.Add(new ProfessionDTO
                {
                    Id = item.Id,
                    Description = item.Description,
                });
            }
            return professionDTOs;
        }
    }
}
