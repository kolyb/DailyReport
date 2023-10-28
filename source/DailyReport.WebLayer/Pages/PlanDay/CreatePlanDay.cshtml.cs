using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.PlanDay
{
    public class CreatePlanDayModel : PageModel
    {
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;

        public CreatePlanDayModel(IService<PlanDayDTO> servicePlanDayDTO)
        {
            _servicePlanDayDTO = servicePlanDayDTO;
        }

        [BindProperty]
        public DateTime Day { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlanDayDTO planDayDTO = new PlanDayDTO();
                    planDayDTO.Day = Day;
                    planDayDTO.UserName = User?.Identity?.Name;

                    await _servicePlanDayDTO.CreateAsync(planDayDTO);

                }
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
