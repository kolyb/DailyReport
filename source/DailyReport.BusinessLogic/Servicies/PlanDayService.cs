﻿using DailyReport.BusinessLogic.ExceptionValidators;
using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using DailyReport.DataAccess.Repositories;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

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
                throw new ValidationException("Can not create a person");
            }
            if (PlanDayValidator.PlanDayExists(item.Day, item.UserName, _planDayRepository))
            {
                throw new ValidationException($"Day '{item.Day}' already exists");
            }
            PlanDay planDay = PlanDayMapper.FromDTO(item);
            await _planDayRepository.CreateAsync(planDay);
        }

        public async Task DeleteAsync(PlanDayDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not delete a day");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
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
            if (id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            var planDay = await _planDayRepository.GetByIdAsync(id);
            PlanDayDTO planDayDTO = PlanDayMapper.ToDTO(planDay);
            return planDayDTO;
        }

        public async Task UpdateAsync(PlanDayDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not update a day");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            PlanDay planDay = PlanDayMapper.FromDTO(item);
            await _planDayRepository.UpdateAsync(planDay);
        }
    }
}
