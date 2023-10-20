using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.ReportDay
{
    public class CreateReportDayModel : PageModel
    {
        private readonly IService<ReportDayDTO> _serviceReportDayDTO;

        public CreateReportDayModel(IService<ReportDayDTO> serviceReportDayDTO)
        {
            _serviceReportDayDTO = serviceReportDayDTO;
        }

        [BindProperty]
        public DateTime RecordDay { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ReportDayDTO reportDayDTO = new ReportDayDTO();
                reportDayDTO.RecordDay = RecordDay;

                await _serviceReportDayDTO.CreateAsync(reportDayDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
