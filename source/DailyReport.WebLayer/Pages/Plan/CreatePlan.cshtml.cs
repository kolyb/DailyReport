using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
        public int Id { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public int PlanDateId { get; set; }

        [BindProperty]
        public TimeSpan PlanTime { get; set; }

        [BindProperty]
        public DateTime PlanDay { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Persons { get; set; }

        public async Task OnGet(int id)
        {
            PlanDateDTO planDateDTO = await _servicePlanDateDTO.GetByIdAsync(id);
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
                PlanDTO planDTO = new PlanDTO();
                planDTO.PlanTime = PlanTime;
                planDTO.PersonId = PersonId;
                planDTO.PlanDateId = Id;

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
