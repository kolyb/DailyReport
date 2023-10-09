using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.PlanDate
{
    public class IndexModel : PageModel
    {
        private readonly IService<PlanDateDTO> _servicePlanDateDTO;

        public IndexModel(IService<PlanDateDTO> servicePlanDateDTO)
        {
            _servicePlanDateDTO = servicePlanDateDTO;
        }

        public IEnumerable<PlanDateDTO>? PlanDateDTOs { get; set; }

        public void OnGet()
        {
            PlanDateDTOs = _servicePlanDateDTO.GetAll();
        }
    }
}
