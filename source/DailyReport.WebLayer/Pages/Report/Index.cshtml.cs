using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Report
{
    public class IndexModel : PageModel
    {
        private readonly IService<ReportDTO> _serviceReportDTO;
        private readonly IService<ReportDayDTO> _serviceReportDayDTO;

        public IndexModel(IService<ReportDTO> serviceReportDTO,
            IService<ReportDayDTO> serviceReportDayDTO)
        {
            _serviceReportDTO = serviceReportDTO;
            _serviceReportDayDTO = serviceReportDayDTO;
        }

        public IEnumerable<ReportDTO>? ReportDTOs { get; set; }

        public IEnumerable<ReportDayDTO>? ReportDayDTOs { get; set; }

        public void OnGet()
        {
            ReportDayDTOs = _serviceReportDayDTO.GetAll();
        }
    }
}
