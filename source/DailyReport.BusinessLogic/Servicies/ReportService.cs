using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

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
                //
                throw new ArgumentNullException("item");
            }
            Report report = ReportMapper.FromDTO(item);
            await _reportRepository.CreateAsync(report);
        }

        public async Task DeleteAsync(ReportDTO item)
        {
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

        public async Task<ReportDTO> GetByIdAsync(int id)
        {
            var report = await _reportRepository.GetByIdAsync(id);
            ReportDTO reportDTO = ReportMapper.ToDTO(report);
            return reportDTO;
        }

        public async Task UpdateAsync(ReportDTO item)
        {
            Report report = ReportMapper.FromDTO(item);
            await _reportRepository.UpdateAsync(report);
        }
    }
}
