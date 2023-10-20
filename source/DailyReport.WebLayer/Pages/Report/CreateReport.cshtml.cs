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
        private readonly IService<PlanDayDTO> _servicePlanDateDTO;

        public CreateReportModel(IService<PersonDTO> servicePersonDTO,
            IService<ReportDTO> serviceReportDTO,
            IService<PlanDayDTO> servicePlanDateDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceReportDTO = serviceReportDTO;
            _servicePlanDateDTO = servicePlanDateDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public int PlanDateId { get; set; }

        [BindProperty]
        public TimeSpan Time { get; set; }

        [BindProperty]
        public DateTime PlanDay { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Persons { get; set; }

        public async Task OnGet(int id)
        {
            PlanDayDTO planDateDTO = await _servicePlanDateDTO.GetByIdAsync(id);
            Id = planDateDTO.Id;
            PlanDay = planDateDTO.PlanDay;


            Persons = _servicePersonDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.LastName
                                  }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ReportDTO reportDTO = new ReportDTO();
                reportDTO.Time = Time;
                reportDTO.PersonId = PersonId;
                reportDTO.PlanDateId = Id;

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
