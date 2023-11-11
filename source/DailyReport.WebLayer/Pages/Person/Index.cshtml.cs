using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.WebLayer.Models;
using Microsoft.AspNetCore.Mvc;
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

        [BindProperty]
        public List<PlanAndReportViewModel>? Persons { get; set; }

        public void OnGet()
        {   
            PersonDTOs = _servicePersonDTO.GetAll();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail
            == User?.Identity?.Name);
            Persons = (from ps in PersonDTOs
                             join wp in WorkplaceDTOs
                             on ps.WorkplaceId equals wp.Id
                             orderby ps.LastName
                             select new PlanAndReportViewModel
                             {   
                                 Id = ps.Id,
                                 Lastname = ps.LastName,
                                 DescriptionWorkplace = wp.Description,
                             }).ToList();

        }
    }
}
