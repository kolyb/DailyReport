using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Profession
{
    public class IndexModel : PageModel
    {
        private readonly IService<ProfessionDTO> _serviceProfessionDTO;

        public IndexModel(IService<ProfessionDTO> serviceProfessionDTO)
        {
            _serviceProfessionDTO = serviceProfessionDTO;
        }

        [BindProperty]
        public IEnumerable<ProfessionDTO>? ProfessionDTOs { get; set; }

        public void OnGet()
        {
            ProfessionDTOs = _serviceProfessionDTO.GetAll();
        }
    }
}
