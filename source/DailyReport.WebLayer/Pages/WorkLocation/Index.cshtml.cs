using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.WorkLocation
{
    public class IndexModel : PageModel
    {
        private readonly IService<WorkLocationDTO> _serviceWorkLocationDTO;

        public IndexModel(IService<WorkLocationDTO> serviceWorkLocationDTO)
        {
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
        }

        public IEnumerable<WorkLocationDTO>? WorkLocationDTOs { get; set; }

        public void OnGet()
        {
            WorkLocationDTOs = _serviceWorkLocationDTO.GetAll();
        }
    }
}
