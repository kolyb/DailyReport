﻿using DailyReport.BusinessLogic.ExceptionValidators;
using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.BusinessLogic.Servicies
{
    public class ReportService : IService<ReportDTO>
    {
        private readonly IRepository<Report> _reportRepository;

        public ReportService(IRepository<Report> reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task CreateAsync(ReportDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not create a report");
            }
            if (ReportValidator.PersonExistsInReport(item.PersonId, _reportRepository))
            {
                throw new ValidationException($"This Person already exists in the report");
            }
            if (ReportValidator.StartTimeExistsInReport(item.StartTime, _reportRepository))
            {
                throw new ValidationException($"Start Time'{item.StartTime}' already exists in the report");
            }
            Report report = ReportMapper.FromDTO(item);
            await _reportRepository.CreateAsync(report);
        }

        public async Task DeleteAsync(ReportDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not delete a report");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            Report report = ReportMapper.FromDTO(item);
            await _reportRepository.DeleteAsync(report);
        }

        public void Dispose()
        {
            _reportRepository.Dispose();
        }

        public IList<ReportDTO> GetAll()
        {
            List<Report> reports = _reportRepository.GetAll().ToList();
            List<ReportDTO> list = ReportMapper.ToDTO(reports);
            return list;
        }

        public async Task<ReportDTO> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Can not get a report");
            }
            if (id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            var report = await _reportRepository.GetByIdAsync(id);
            ReportDTO reportDTO = ReportMapper.ToDTO(report);
            return reportDTO;
        }

        public async Task UpdateAsync(ReportDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not update a report");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }
            Report report = ReportMapper.FromDTO(item);
            await _reportRepository.UpdateAsync(report);
        }
    }
}
