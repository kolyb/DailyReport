using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

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
                //
                throw new ArgumentNullException("item");
            }
            ReportDay reportDay = ReportDayMapper.FromDTO(item);
            await _reportDayRepository.CreateAsync(reportDay);
        }

        public async Task DeleteAsync(ReportDayDTO item)
        {
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
            var reportDay = await _reportDayRepository.GetByIdAsync(id);
            ReportDayDTO reportDayDTO = ReportDayMapper.ToDTO(reportDay);
            return reportDayDTO;
        }

        public async Task UpdateAsync(ReportDayDTO item)
        {
            ReportDay reportDay = ReportDayMapper.FromDTO(item);
            await _reportDayRepository.UpdateAsync(reportDay);
        }
    }
}
