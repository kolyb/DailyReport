using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class IndexModel : PageModel
    {
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;
        private readonly IService<PersonDTO> _servicePersonDTO;

        public IndexModel(IService<WorkplaceDTO> serviceWorkplaceDTO,
            IService<PersonDTO> servicePersonDTO)
        {
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
            _servicePersonDTO = servicePersonDTO;
        }

        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        public int? PersonId { get; set; }


        public void OnGet()
        {
            //PersonDTOs = _servicePersonDTO.GetAll().Where(x => x.UserIdentityEmail
            //== User?.Identity?.Name);

            //foreach(var i in PersonDTOs)
            //{
            //    PersonId = i.Id;
            //}

            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll();
   
            
        }
    }
}
