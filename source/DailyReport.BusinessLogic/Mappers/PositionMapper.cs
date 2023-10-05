using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class PositionMapper
    {
        public static Position FromDTO(PositionDTO item)
        {
            Position position = new Position
            {
                Id = item.Id,
                Description = item.Description,
            };
            return position;
        }

        public static PositionDTO ToDTO(Position item)
        {
            PositionDTO positionDTO = new PositionDTO
            {
                Id = item.Id,
                Description = item.Description,
            };
            return positionDTO;
        }

        public static List<PositionDTO> ToDTO(List<Position> list)
        {
            List<PositionDTO> positionDTOs = new List<PositionDTO>();
            foreach (var item in list)
            {
                positionDTOs.Add(new PositionDTO
                {
                    Id = item.Id,
                    Description = item.Description,
                });
            }
            return positionDTOs;
        }
    }
}
