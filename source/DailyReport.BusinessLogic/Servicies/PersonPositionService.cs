using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class PersonPositionService : IService<PersonPositionDTO>
    {
        private readonly IRepository<PersonPosition> _personPositionRepository;

        public PersonPositionService(IRepository<PersonPosition> personPositionRepository)
        {
            _personPositionRepository = personPositionRepository;
        }

        public async Task CreateAsync(PersonPositionDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            PersonPosition personPosition = PersonPositionMapper.FromDTO(item);
            await _personPositionRepository.CreateAsync(personPosition);
        }

        public async Task DeleteAsync(PersonPositionDTO item)
        {
            PersonPosition personPosition = PersonPositionMapper.FromDTO(item);
            await _personPositionRepository.DeleteAsync(personPosition);
        }

        public void Dispose()
        {
            _personPositionRepository.Dispose();
        }

        public IList<PersonPositionDTO> GetAll()
        {
            List<PersonPosition> personPositions = _personPositionRepository.GetAll().ToList();
            List<PersonPositionDTO> list = PersonPositionMapper.ToDTO(personPositions);
            return list;
        }

        public async Task<PersonPositionDTO> GetByIdAsync(int id)
        {
            var personPosition = await _personPositionRepository.GetByIdAsync(id);
            PersonPositionDTO personPositionDTO = PersonPositionMapper.ToDTO(personPosition);
            return personPositionDTO;
        }

        public async Task UpdateAsync(PersonPositionDTO item)
        {
            PersonPosition personPosition = PersonPositionMapper.FromDTO(item);
            await _personPositionRepository.UpdateAsync(personPosition);
        }
    }
}
