using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public IndexModel(IService<PersonDTO> servicePersonDTO, 
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        public IEnumerable<PersonDTO>? PersonNewDTOs { get; set; }

        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public void OnGet()
        {   
            PersonDTOs = _servicePersonDTO.GetAll();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail
            == User?.Identity?.Name);
            PersonNewDTOs = (from ps in PersonDTOs
                             join wp in WorkplaceDTOs
                             on ps.WorkplaceId equals wp.Id
                             select ps).ToList();

        }
    }
}
