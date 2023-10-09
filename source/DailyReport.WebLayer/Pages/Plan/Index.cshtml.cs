using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class IndexModel : PageModel
    {
        private readonly IService<PlanDTO> _servicePlanDTO;
        private readonly IService<PlanDateDTO> _servicePlanDateDTO;

        public IndexModel(IService<PlanDTO> servicePlanDTO,
            IService<PlanDateDTO> servicePlanDateDTO)
        {
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDateDTO = servicePlanDateDTO;
        }

        public IEnumerable<PlanDTO>? PlanDTOs { get; set; }

        public IEnumerable<PlanDateDTO>? PlanDateDTOs { get; set; }

        public void OnGet()
        {
            PlanDateDTOs = _servicePlanDateDTO.GetAll();
        }
    }
}
