using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class PlanService : IService<PlanDTO>
    {
        private readonly IRepository<Plan> _planRepository;

        public PlanService(IRepository<Plan> planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task CreateAsync(PlanDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            Plan plan = PlanMapper.FromDTO(item);
            await _planRepository.CreateAsync(plan);
        }

        public async Task DeleteAsync(PlanDTO item)
        {
            Plan plan = PlanMapper.FromDTO(item);
            await _planRepository.DeleteAsync(plan);
        }

        public void Dispose()
        {
            _planRepository.Dispose();
        }

        public IList<PlanDTO> GetAll()
        {
            List<Plan> plans = _planRepository.GetAll().ToList();
            List<PlanDTO> list = PlanMapper.ToDTO(plans);
            return list;
        }

        public async Task<PlanDTO> GetByIdAsync(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            PlanDTO planDTO = PlanMapper.ToDTO(plan);
            return planDTO;
        }

        public async Task UpdateAsync(PlanDTO item)
        {
            Plan plan = PlanMapper.FromDTO(item);
            await _planRepository.UpdateAsync(plan);
        }
    }
}
