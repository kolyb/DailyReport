using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class PlanDateService : IService<PlanDateDTO>
    {
        private readonly IRepository<PlanDate> _planDateRepository;

        public PlanDateService(IRepository<PlanDate> planDateRepository)
        {
            _planDateRepository = planDateRepository;
        }

        public async Task CreateAsync(PlanDateDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            PlanDate planDate = PlanDateMapper.FromDTO(item);
            await _planDateRepository.CreateAsync(planDate);
        }

        public async Task DeleteAsync(PlanDateDTO item)
        {
            PlanDate planDate = PlanDateMapper.FromDTO(item);
            await _planDateRepository.DeleteAsync(planDate);
        }

        public void Dispose()
        {
            _planDateRepository.Dispose();
        }

        public IList<PlanDateDTO> GetAll()
        {
            List<PlanDate> planDates = _planDateRepository.GetAll().ToList();
            List<PlanDateDTO> list = PlanDateMapper.ToDTO(planDates);
            return list;
        }

        public async Task<PlanDateDTO> GetByIdAsync(int id)
        {
            var planDate = await _planDateRepository.GetByIdAsync(id);
            PlanDateDTO planDateDTO = PlanDateMapper.ToDTO(planDate);
            return planDateDTO;
        }

        public async Task UpdateAsync(PlanDateDTO item)
        {
            PlanDate planDate = PlanDateMapper.FromDTO(item);
            await _planDateRepository.UpdateAsync(planDate);
        }
    }
}
