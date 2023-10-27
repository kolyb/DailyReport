using DailyReport.BusinessLogic.ExceptionValidators;
using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

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
                throw new ValidationException("Can not create a position");
            }
            if (PositionValidator.PositionExists(item.Description, _positionRepository))
            {
                throw new ValidationException($"Position '{item.Description}' already exists");
            }
            Position position = PositionMapper.FromDTO(item);
            await _positionRepository.CreateAsync(position);
        }

        public async Task DeleteAsync(PositionDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not delete a position");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
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

        public async Task<PositionDTO> GetByIdAsync(int? id)
        {
            if (id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            var position = await _positionRepository.GetByIdAsync(id);
            PositionDTO positionDTO = PositionMapper.ToDTO(position);
            return positionDTO;
        }

        public async Task UpdateAsync(PositionDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not update a position");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            Position position = PositionMapper.FromDTO(item);
            await _positionRepository.UpdateAsync(position);
        }
    }
}
