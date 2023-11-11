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
        public int? PlanDayId { get; set; }

        [BindProperty]
        public int? PersonId { get; set; }

        [BindProperty]
        public TimeSpan? StartTime { get; set; }

        [BindProperty]
        public TimeSpan? FinishTime { get; set; }

        [BindProperty]
        public TimeSpan? IntervalTime { get; set; }


        public async Task OnGet(int id)
        {
            PlanDTO planDTO = await _servicePlanDTO.GetByIdAsync(id);           
            PersonId = planDTO.PersonId;
            PlanDayId = planDTO.PlanDayId;
            StartTime = planDTO.StartTime;
            FinishTime = planDTO.FinishTime;
            IntervalTime = planDTO.IntervalTime;
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
                    planDTO.PlanDayId = PlanDayId;
                    planDTO.StartTime = StartTime;
                    planDTO.FinishTime = FinishTime;
                    planDTO.IntervalTime = IntervalTime;

                    await _servicePlanDTO.DeleteAsync(planDTO);
                }
            }
            return RedirectToPage("DetailsPlan", new { id = PlanDayId });
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("DetailsPlan", new { id = PlanDayId });
        }
    }
}
