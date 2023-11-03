using DailyReport.BusinessLogic.ExceptionValidators;
using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.BusinessLogic.Servicies
{
    public class ReportDayService : IService<ReportDayDTO>
    {
        private readonly IRepository<ReportDay> _reportDayRepository;

        public ReportDayService(IRepository<ReportDay> reportDayRepository)
        {
            _reportDayRepository = reportDayRepository;
        }

        public async Task CreateAsync(ReportDayDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not create a report day");
            }

            if (ReportDayValidator.ReportDayExists(item.RecordDay, item.UserName, _reportDayRepository))
            {
                throw new ValidationException($"Day '{item.RecordDay}' already exists");
            }

            if (ReportDayValidator.ReportDayMoreThanToday(item.RecordDay))
            {
                throw new ValidationException($"Day '{item.RecordDay}' can not create");
            }

            ReportDay reportDay = ReportDayMapper.FromDTO(item);
            await _reportDayRepository.CreateAsync(reportDay);
        }

        public async Task DeleteAsync(ReportDayDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not delete a day");
            }

            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }

            ReportDay reportDay = ReportDayMapper.FromDTO(item);
            await _reportDayRepository.DeleteAsync(reportDay);
        }

        public void Dispose()
        {
            _reportDayRepository.Dispose();
        }

        public IList<ReportDayDTO> GetAll()
        {
            List<ReportDay> reportDays = _reportDayRepository.GetAll().ToList();
            List<ReportDayDTO> list = ReportDayMapper.ToDTO(reportDays);
            return list;
        }

        public async Task<ReportDayDTO> GetByIdAsync(int? id)
        {
            if (id <= 0)
            {
                throw new ValidationException("It is impossible");
            }

            var reportDay = await _reportDayRepository.GetByIdAsync(id);
            ReportDayDTO reportDayDTO = ReportDayMapper.ToDTO(reportDay);
            return reportDayDTO;
        }

        public async Task UpdateAsync(ReportDayDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not update a day");
            }

            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }

            ReportDay reportDay = ReportDayMapper.FromDTO(item);
            await _reportDayRepository.UpdateAsync(reportDay);
        }
    }
}
