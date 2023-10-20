using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class IndexModel : PageModel
    {
        private readonly IService<PlanDTO> _servicePlanDTO;
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;

        public IndexModel(IService<PlanDTO> servicePlanDTO,
            IService<PlanDayDTO> servicePlanDayDTO)
        {
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDayDTO = servicePlanDayDTO;
        }

        public IEnumerable<PlanDTO>? PlanDTOs { get; set; }

        public IEnumerable<PlanDayDTO>? PlanDayDTOs { get; set; }

        public void OnGet()
        {
            PlanDayDTOs = _servicePlanDayDTO.GetAll();
        }
    }
}
