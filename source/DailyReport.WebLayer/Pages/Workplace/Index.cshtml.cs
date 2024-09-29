using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class IndexModel : PageModel
    {
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public IndexModel(IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        public void OnGet()
        {

            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().OrderBy(i => i.AdressCity).
                Where(i => i.UserIdentityEmail == User.Identity?.Name);
        }
    }
}
