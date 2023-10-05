using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class PositionService : IService<PositionDTO>
    {
        private readonly IRepository<Position> _positionRepository;

        public PositionService(IRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task CreateAsync(PositionDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            Position position = PositionMapper.FromDTO(item);
            await _positionRepository.CreateAsync(position);
        }

        public async Task DeleteAsync(PositionDTO item)
        {
            Position position = PositionMapper.FromDTO(item);
            await _positionRepository.DeleteAsync(position);
        }

        public void Dispose()
        {
            _positionRepository.Dispose();
        }

        public IList<PositionDTO> GetAll()
        {
            List<Position> positions = _positionRepository.GetAll().ToList();
            List<PositionDTO> list = PositionMapper.ToDTO(positions);
            return list;
        }

        public async Task<PositionDTO> GetByIdAsync(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            PositionDTO positionDTO = PositionMapper.ToDTO(position);
            return positionDTO;
        }

        public async Task UpdateAsync(PositionDTO item)
        {
            Position position = PositionMapper.FromDTO(item);
            await _positionRepository.UpdateAsync(position);
        }
    }
}
