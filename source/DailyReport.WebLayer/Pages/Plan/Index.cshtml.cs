using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class IndexModel : PageModel
    {
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;

        public IndexModel(IService<PlanDayDTO> servicePlanDayDTO)
        {
            _servicePlanDayDTO = servicePlanDayDTO;
        }

        public IEnumerable<PlanDayDTO>? PlanDayDTOs { get; set; }

        public void OnGet()
        {
            PlanDayDTOs = _servicePlanDayDTO.GetAll().Where(i =>i.UserName 
            == User.Identity?.Name);
        }
    }
}
