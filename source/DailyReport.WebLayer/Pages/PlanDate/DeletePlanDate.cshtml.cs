using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.PlanDate
{
    public class DeletePlanDateModel : PageModel
    {
        private readonly IService<PlanDateDTO> _servicePlanDateDTO;

        public DeletePlanDateModel(IService<PlanDateDTO> servicePlanDateDTO)
        {
            _servicePlanDateDTO = servicePlanDateDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public DateTime PlanDay { get; set; }


        public async Task OnGet(int id)
        {
            PlanDateDTO planDateDTO = await _servicePlanDateDTO.GetByIdAsync(id);
            Id = planDateDTO.Id;
            PlanDay = planDateDTO.PlanDay;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PlanDateDTO planDateDTO = await _servicePlanDateDTO.GetByIdAsync(Id);
                if (planDateDTO != null)
                {
                    planDateDTO.Id = Id;
                    planDateDTO.PlanDay = PlanDay;

                    await _servicePlanDateDTO.DeleteAsync(planDateDTO);
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
