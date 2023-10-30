using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Report
{
    public class DeleteReportModel : PageModel
    {
        private readonly IService<ReportDTO> _serviceReportDTO;

        public DeleteReportModel(IService<ReportDTO> serviceReportDTO)
        {
            _serviceReportDTO = serviceReportDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int ReportDayId { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public TimeSpan StartTime { get; set; }

        [BindProperty]
        public TimeSpan FinishTime { get; set; }

        [BindProperty]
        public TimeSpan IntervalTime { get; set; }


        public async Task OnGet(int id)
        {
            ReportDTO reportDTO = await _serviceReportDTO.GetByIdAsync(id);
            PersonId = reportDTO.PersonId;
            ReportDayId = reportDTO.ReportDayId;
            StartTime = reportDTO.StartTime;
            FinishTime = reportDTO.FinishTime;
            IntervalTime = reportDTO.IntervalTime;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ReportDTO reportDTO = await _serviceReportDTO.GetByIdAsync(Id);
                if (reportDTO != null)
                {
                    reportDTO.Id = Id;
                    reportDTO.PersonId = PersonId;
                    reportDTO.ReportDayId = ReportDayId;
                    reportDTO.StartTime = StartTime;
                    reportDTO.FinishTime = FinishTime;
                    reportDTO.IntervalTime = IntervalTime;

                    await _serviceReportDTO.DeleteAsync(reportDTO);
                }
            }

            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
