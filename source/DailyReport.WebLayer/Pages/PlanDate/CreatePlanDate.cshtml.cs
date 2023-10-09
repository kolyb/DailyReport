using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.PlanDate
{
    public class CreatePlanDateModel : PageModel
    {
        private readonly IService<PlanDateDTO> _servicePlanDateDTO;

        public CreatePlanDateModel(IService<PlanDateDTO> servicePlanDateDTO)
        {
            _servicePlanDateDTO = servicePlanDateDTO;
        }

        [BindProperty]
        public DateTime PlanDay { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PlanDateDTO planDateDTO = new PlanDateDTO();
                planDateDTO.PlanDay = PlanDay;

                await _servicePlanDateDTO.CreateAsync(planDateDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
