using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class PlanDayService : IService<PlanDayDTO>
    {
        private readonly IRepository<PlanDay> _planDayRepository;

        public PlanDayService(IRepository<PlanDay> planDayRepository)
        {
            _planDayRepository = planDayRepository;
        }

        public async Task CreateAsync(PlanDayDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            PlanDay planDay = PlanDayMapper.FromDTO(item);
            await _planDayRepository.CreateAsync(planDay);
        }

        public async Task DeleteAsync(PlanDayDTO item)
        {
            PlanDay planDay = PlanDayMapper.FromDTO(item);
            await _planDayRepository.DeleteAsync(planDay);
        }

        public void Dispose()
        {
            _planDayRepository.Dispose();
        }

        public IList<PlanDayDTO> GetAll()
        {
            List<PlanDay> planDays = _planDayRepository.GetAll().ToList();
            List<PlanDayDTO> list = PlanDayMapper.ToDTO(planDays);
            return list;
        }

        public async Task<PlanDayDTO> GetByIdAsync(int? id)
        {
            var planDay = await _planDayRepository.GetByIdAsync(id);
            PlanDayDTO planDayDTO = PlanDayMapper.ToDTO(planDay);
            return planDayDTO;
        }

        public async Task UpdateAsync(PlanDayDTO item)
        {
            PlanDay planDay = PlanDayMapper.FromDTO(item);
            await _planDayRepository.UpdateAsync(planDay);
        }
    }
}
