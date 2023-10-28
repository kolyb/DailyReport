using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.PlanDay
{
    public class DeletePlanDayModel : PageModel
    {
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;

        public DeletePlanDayModel(IService<PlanDayDTO> servicePlanDayDTO)
        {
            _servicePlanDayDTO = servicePlanDayDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public DateTime Day { get; set; }

        [BindProperty]
        public string? UserName { get; set; }


        public async Task OnGet(int id)
        {
            PlanDayDTO planDayDTO = await _servicePlanDayDTO.GetByIdAsync(id);
            Id = planDayDTO.Id;
            Day = planDayDTO.Day;
            UserName = planDayDTO.UserName;

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PlanDayDTO planDayDTO = await _servicePlanDayDTO.GetByIdAsync(Id);
                if (planDayDTO != null)
                {
                    planDayDTO.Id = Id;
                    planDayDTO.Day = Day;
                    planDayDTO.UserName = UserName;

                    await _servicePlanDayDTO.DeleteAsync(planDayDTO);
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
