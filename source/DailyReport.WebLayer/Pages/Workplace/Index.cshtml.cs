using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.WebLayer.Models;
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

        public IEnumerable<WorkplaceViewModel>? WorkplaceViewModels { get; set; }


        public void OnGet()
        {
            //PersonDTOs = _servicePersonDTO.GetAll();

            //WorkplaceDTOs = _serviceWorkplaceDTO.GetAll();

            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().OrderBy(i => i.AdressCity).
                Where(i => i.UserIdentityEmail == User.Identity?.Name);

            //WorkplaceViewModels = (from wp in WorkplaceDTOs
            //                       join ps in PersonDTOs
            //                       on wp.Id equals ps.WorkplaceId
            //                       where ps.UserIdentityEmail == User.Identity?.Name
            //                       select new WorkplaceViewModel
            //                       {
            //                           Id = wp.Id,
            //                           Description = wp.Description,
            //                           AdressCity = wp.AdressCity,
            //                           AdressStreet = wp.AdressStreet,
            //                           AdressHouse = wp.AdressHouse
            //                       }).ToList();
        }
    }
}
