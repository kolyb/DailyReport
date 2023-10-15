using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class DeletePlanModel : PageModel
    {
        private readonly IService<PlanDTO> _servicePlanDTO;

        public DeletePlanModel(IService<PlanDTO> servicePlanDTO)
        {
            _servicePlanDTO = servicePlanDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int PlanDateId { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public TimeSpan PlanTime { get; set; }


        public async Task OnGet(int id)
        {
            PlanDTO planDTO = await _servicePlanDTO.GetByIdAsync(id);           
            PersonId = planDTO.PersonId;
            PlanDateId = planDTO.PlanDateId;
            PlanTime = planDTO.PlanTime;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PlanDTO planDTO = await _servicePlanDTO.GetByIdAsync(Id);
                if (planDTO != null)
                {
                    planDTO.Id = Id;
                    planDTO.PersonId = PersonId;
                    planDTO.PlanDateId = PlanDateId;
                    planDTO.PlanTime = PlanTime;

                    await _servicePlanDTO.DeleteAsync(planDTO);
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
