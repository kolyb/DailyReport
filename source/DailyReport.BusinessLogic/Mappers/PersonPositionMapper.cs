using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class PersonPositionMapper
    {
        public static PersonPosition FromDTO(PersonPositionDTO item)
        {
            PersonPosition personPosition = new PersonPosition
            {
                Id = item.Id,
                Position = item.Position,
                Expert = item.Expert,
            };
            return personPosition;
        }

        public static PersonPositionDTO ToDTO(PersonPosition item)
        {
            PersonPositionDTO personPositionDTO = new PersonPositionDTO
            {
                Id = item.Id,
                Position = item.Position,
                Expert = item.Expert,
            };
            return personPositionDTO;
        }

        public static List<PersonPositionDTO> ToDTO(List<PersonPosition> list)
        {
            List<PersonPositionDTO> personPositionDTOs = new List<PersonPositionDTO>();
            foreach (var item in list)
            {
                personPositionDTOs.Add(new PersonPositionDTO
                {
                    Id = item.Id,
                    Position = item.Position,
                    Expert = item.Expert,
                });
            }
            return personPositionDTOs;
        }
    }
}
