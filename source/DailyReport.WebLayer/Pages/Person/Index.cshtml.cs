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

        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        //public IEnumerable<WorkplaceViewModel>? PersonViewModels { get; set; }

        public void OnGet()
        {
            //WorkplaceDTOs = _serviceWorkplaceDTO.GetAll();
            PersonDTOs = _servicePersonDTO.GetAll().OrderBy(i =>i.LastName).
                Where(i => i.UserIdentityEmail == User.Identity?.Name).ToList();

            //PersonViewModels = (from ps in PersonDTOs
            //                    join wp in WorkplaceDTOs
            //                    on ps.WorkplaceId equals wp.Id
            //                    where wp.UserIdentityEmail == User.Identity?.Name
            //                    select new PersonViewModel
            //                    {
            //                        Id = wp.Id,
            //                        LastName = ps.LastName,
            //                        PhoneNumber = ps.PhoneNumber,
            //                    }).ToList();

        }
    }
}
