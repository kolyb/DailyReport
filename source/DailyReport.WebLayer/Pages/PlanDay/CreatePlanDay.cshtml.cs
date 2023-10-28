using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DailyReport.WebLayer.Pages.PlanDay
{
    public class CreatePlanDayModel : PageModel
    {
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;

        public CreatePlanDayModel(IService<PlanDayDTO> servicePlanDayDTO)
        {
            _servicePlanDayDTO = servicePlanDayDTO;
        }

        [BindProperty, DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime Day { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PlanDayDTO planDayDTO = new PlanDayDTO();
                planDayDTO.Day = Day;
                planDayDTO.UserName = User?.Identity?.Name;

                await _servicePlanDayDTO.CreateAsync(planDayDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
