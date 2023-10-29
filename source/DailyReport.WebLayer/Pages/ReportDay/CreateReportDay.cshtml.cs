using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

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
            try
            {
                if (ModelState.IsValid)
                {
                    ReportDayDTO reportDayDTO = new ReportDayDTO();
                    reportDayDTO.RecordDay = RecordDay;
                    reportDayDTO.UserName = User?.Identity?.Name;


                    await _serviceReportDayDTO.CreateAsync(reportDayDTO);

                }
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }

            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
