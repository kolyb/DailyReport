using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyReport.WebLayer.Pages.Report
{
    public class CreateReportModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<ReportDTO> _serviceReportDTO;
        private readonly IService<ReportDayDTO> _serviceReportDayDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public CreateReportModel(IService<PersonDTO> servicePersonDTO,
            IService<ReportDTO> serviceReportDTO,
            IService<ReportDayDTO> serviceReportDayDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceReportDTO = serviceReportDTO;
            _serviceReportDayDTO = serviceReportDayDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public int ReportDayId { get; set; }

        [BindProperty]
        public TimeSpan Time { get; set; }

        [BindProperty]
        public DateTime RecordDay { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Persons { get; set; }

        public async Task OnGet(int id)
        {
            ReportDayDTO reportDayDTO = await _serviceReportDayDTO.GetByIdAsync(id);
            Id = reportDayDTO.Id;
            RecordDay = reportDayDTO.RecordDay;


            PersonDTOs = _servicePersonDTO.GetAll();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail
            == User?.Identity?.Name);
            Persons = (from ps in PersonDTOs
                       join wp in WorkplaceDTOs
                       on ps.WorkplaceId equals wp.Id
                       select new SelectListItem
                       {
                           Value = ps.Id.ToString(),
                           Text = ps.LastName
                       }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ReportDTO reportDTO = new ReportDTO();
                reportDTO.Time = Time;
                reportDTO.PersonId = PersonId;
                reportDTO.ReportDayId = Id;

                await _serviceReportDTO.CreateAsync(reportDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
