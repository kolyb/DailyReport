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
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;

        public CreatePlanModel(IService<PersonDTO> servicePersonDTO,
            IService<PlanDTO> servicePlanDTO,
            IService<PlanDayDTO> servicePlanDayDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDayDTO = servicePlanDayDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public int PlanDayId { get; set; }

        [BindProperty]
        public TimeSpan PlanTime { get; set; }

        [BindProperty]
        public DateTime Day { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Persons { get; set; }

        public async Task OnGet(int id)
        {
            PlanDayDTO planDayDTO = await _servicePlanDayDTO.GetByIdAsync(id);
            Id = planDayDTO.Id;
            Day = planDayDTO.Day;


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
                PlanDTO planDTO = new PlanDTO();
                planDTO.PlanTime = PlanTime;
                planDTO.PersonId = PersonId;
                planDTO.PlanDayId = Id;

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
