using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;

        public IndexModel(IService<PersonDTO> servicePersonDTO)
        {
            _servicePersonDTO = servicePersonDTO;
        }

        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        public void OnGet()
        {   
            PersonDTOs = _servicePersonDTO.GetAll().Where(i =>i.UserIdentityEmail
            == User.Identity?.Name);                           
        }
    }
}
