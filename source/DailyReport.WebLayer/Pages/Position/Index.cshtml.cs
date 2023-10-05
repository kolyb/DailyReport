using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Position
{
    public class IndexModel : PageModel
    {
        private readonly IService<PositionDTO> _servicePositionDTO;

        public IndexModel(IService<PositionDTO> servicePositionDTO)
        {
            _servicePositionDTO = servicePositionDTO;
        }

        public IEnumerable<PositionDTO>? PositionDTOs { get; set; }

        public void OnGet()
        {
            PositionDTOs = _servicePositionDTO.GetAll();
        }
    }
}
