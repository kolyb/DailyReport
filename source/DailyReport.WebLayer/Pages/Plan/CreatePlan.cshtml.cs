using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class CreatePlanModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<PlanDTO> _servicePlanDTO;
        private readonly IService<PlanDateDTO> _servicePlanDateDTO;

        public CreatePlanModel(IService<PersonDTO> servicePersonDTO,
            IService<PlanDTO> servicePlanDTO,
            IService<PlanDateDTO> servicePlanDateDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDateDTO = servicePlanDateDTO;
        }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public int PlanDateId { get; set; }

        [BindProperty]
        public DateTime PlanTime { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Persons { get; set; }

        [BindProperty]
        public List<SelectListItem>? PlanDates { get; set; }

        public void OnGet()
        {
            Persons = _servicePersonDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.LastName
                                  }).ToList();
            PlanDates = _servicePlanDateDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.PlanDay.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PlanDTO planDTO = new PlanDTO();
                planDTO.PlanTime = PlanTime;
                planDTO.PersonId = PersonId;
                planDTO.PlanDateId = PlanDateId;

                await _servicePlanDTO.CreateAsync(planDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
