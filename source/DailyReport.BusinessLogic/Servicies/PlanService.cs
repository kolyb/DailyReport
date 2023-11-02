using DailyReport.BusinessLogic.ExceptionValidators;
using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

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
                throw new ValidationException("Can not create a plan");
            }
            if (PlanValidator.PersonExistsInPlan(item.PersonId, item.PlanDayId, _planRepository))
            {
                throw new ValidationException($"This Person already exists in the plan");
            }
            if (PlanValidator.StartTimeExistsInPlan(item.StartTime, item.PlanDayId, _planRepository))
            {
                throw new ValidationException($"Start Time'{item.StartTime}' already exists in the plan");
            }
            if (PlanValidator.StartTimeCorrect(item.StartTime, item.PlanDayId, _planRepository))
            {
                throw new ValidationException($"Start Time'{item.StartTime}' is not correct");
            }
            if (PlanValidator.FinishTimeEqualStartTime(item.StartTime, item.FinishTime))
            {
                throw new ValidationException($"Finish Time'{item.FinishTime}' is not correct");
            }
            if (PlanValidator.FinishTimeLessThanlStartTime(item.StartTime, item.FinishTime))
            {
                throw new ValidationException($"Finish Time'{item.FinishTime}' is not correct");
            }
            //if (PlanValidator.FinishTimeCorrect(item.FinishTime, item.StartTime, _planRepository))
            //{
            //    throw new ValidationException($"Finish Time'{item.FinishTime}' is not correct");
            //}
            Plan plan = PlanMapper.FromDTO(item);
            await _planRepository.CreateAsync(plan);
        }

        public async Task DeleteAsync(PlanDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not delete a plan");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
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

        public async Task<PlanDTO> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Can not get a plan");
            }
            if (id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            var plan = await _planRepository.GetByIdAsync(id);
            PlanDTO planDTO = PlanMapper.ToDTO(plan);
            return planDTO;
        }

        public async Task UpdateAsync(PlanDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not update a plan");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            Plan plan = PlanMapper.FromDTO(item);
            await _planRepository.UpdateAsync(plan);
        }
    }
}
