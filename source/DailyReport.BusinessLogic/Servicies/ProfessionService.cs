using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class ProfessionService : IService<ProfessionDTO>
    {
        private readonly IRepository<Profession> _professionRepository;

        public ProfessionService(IRepository<Profession> professionRepository)
        {
            _professionRepository = professionRepository;
        }

        public async Task CreateAsync(ProfessionDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            Profession profession = ProfessionMapper.FromDTO(item);
            await _professionRepository.CreateAsync(profession);
        }

        public async Task DeleteAsync(ProfessionDTO item)
        {
            Profession profession = ProfessionMapper.FromDTO(item);
            await _professionRepository.DeleteAsync(profession);
        }

        public void Dispose()
        {
            _professionRepository.Dispose();
        }

        public IList<ProfessionDTO> GetAll()
        {
            List<Profession> professions = _professionRepository.GetAll().ToList();
            List<ProfessionDTO> list = ProfessionMapper.ToDTO(professions);
            return list;
        }

        public async Task<ProfessionDTO> GetByIdAsync(int? id)
        {
            var profession = await _professionRepository.GetByIdAsync(id);
            ProfessionDTO professionDTO = ProfessionMapper.ToDTO(profession);
            return professionDTO;
        }

        public async Task UpdateAsync(ProfessionDTO item)
        {
            Profession profession = ProfessionMapper.FromDTO(item);
            await _professionRepository.UpdateAsync(profession);
        }
    }
}
