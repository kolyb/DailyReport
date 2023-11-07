using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Report
{
    public class IndexModel : PageModel
    {
        private readonly IService<ReportDayDTO> _serviceReportDayDTO;

        public IndexModel(IService<ReportDayDTO> serviceReportDayDTO)
        {
            _serviceReportDayDTO = serviceReportDayDTO;
        }

        public IEnumerable<ReportDayDTO>? ReportDayDTOs { get; set; }

        public void OnGet()
        {
            ReportDayDTOs = _serviceReportDayDTO.GetAll().Where(i => i.UserName
             == User.Identity?.Name);
        }
    }
}
