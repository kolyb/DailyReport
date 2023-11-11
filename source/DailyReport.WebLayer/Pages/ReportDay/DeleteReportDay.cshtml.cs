using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.ReportDay
{
    public class DeleteReportDayModel : PageModel
    {
        private readonly IService<ReportDayDTO> _serviceReportDayDTO;

        public DeleteReportDayModel(IService<ReportDayDTO> serviceReportDayDTO)
        {
            _serviceReportDayDTO = serviceReportDayDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public DateTime RecordDay { get; set; }

        [BindProperty]
        public string? UserName { get; set; }


        public async Task OnGet(int id)
        {
            ReportDayDTO reportDayDTO = await _serviceReportDayDTO.GetByIdAsync(id);
            Id = reportDayDTO.Id;
            RecordDay = reportDayDTO.RecordDay;
            UserName = reportDayDTO.UserName;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ReportDayDTO reportDayDTO = await _serviceReportDayDTO.GetByIdAsync(Id);
                if (reportDayDTO != null)
                {
                    reportDayDTO.Id = Id;
                    reportDayDTO.RecordDay = RecordDay;
                    reportDayDTO.UserName = UserName;

                    await _serviceReportDayDTO.DeleteAsync(reportDayDTO);
                }
            }
            return RedirectToPage("/Report/Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("/Report/Index");
        }
    }
}
