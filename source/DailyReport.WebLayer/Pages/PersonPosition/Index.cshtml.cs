using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.PersonPosition
{
    public class IndexModel : PageModel
    {
        private readonly IService<PersonPositionDTO> _servicePersonPositionDTO;

        public IndexModel(IService<PersonPositionDTO> servicePersonPositionDTO)
        {
            _servicePersonPositionDTO = servicePersonPositionDTO;
        }

        public IEnumerable<PersonPositionDTO>? PersonPositionDTOs { get; set; }

        public void OnGet()
        {
            PersonPositionDTOs = _servicePersonPositionDTO.GetAll();
        }
    }
}
