using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Person
{
    public class DetailsPersonModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;
        private readonly IService<PositionDTO> _servicePositionDTO;
        private readonly IService<ProfessionDTO> _serviceProfessionDTO;

        public DetailsPersonModel(IService<PersonDTO> servicePersonDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO,
            IService<PositionDTO> servicePositionDTO,
            IService<ProfessionDTO> serviceProfessionDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
            _servicePositionDTO = servicePositionDTO;
            _serviceProfessionDTO = serviceProfessionDTO;
        }

        [BindProperty]
        public int? Id { get; set; }

        [BindProperty]
        public string? Birthday { get; set; }

        [BindProperty]
        public string? FirstName { get; set; }

        [BindProperty]
        public string? MiddleName { get; set; }

        [BindProperty]
        public string? LastName { get; set; }

        [BindProperty]
        public int WorkplaceId { get; set; }

        [BindProperty]
        public string? Workplace { get; set; }

        [BindProperty]
        public string? AdressCity { get; set; }

        [BindProperty]
        public string? AdressStreet { get; set; }

        [BindProperty]
        public string? AdressHouse { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public string? DescriptionProfession { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        [BindProperty]
        public List<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public List<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public List<PositionDTO>? PositionDTOs { get; set; }

        [BindProperty]
        public List<ProfessionDTO>? ProfessionDTOs { get; set; }

        public async Task OnGetAsync(int id)
        {
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().ToList();
            PositionDTOs = _servicePositionDTO.GetAll().ToList();
            ProfessionDTOs = _serviceProfessionDTO.GetAll().ToList();

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Id = personDTO.Id;
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            LastName = personDTO.LastName;
            Workplace = (from wl in WorkplaceDTOs
                         where wl.Id == personDTO.WorkplaceId
                         select wl.Description).FirstOrDefault();
            AdressCity = (from wl in WorkplaceDTOs
                          where wl.Id == personDTO.WorkplaceId
                          select wl.AdressCity).FirstOrDefault();
            AdressStreet = (from wl in WorkplaceDTOs
                            where wl.Id == personDTO.WorkplaceId
                            select wl.AdressStreet).FirstOrDefault();
            AdressHouse = (from wl in WorkplaceDTOs
                           where wl.Id == personDTO.WorkplaceId
                           select wl.AdressHouse).FirstOrDefault();
            Description = (from ps in PositionDTOs
                           where ps.Id == personDTO.PositionId
                           select ps.Description).FirstOrDefault();
            DescriptionProfession = (from pr in ProfessionDTOs
                                     where pr.Id == personDTO.ProfessionId
                                     select pr.Description).FirstOrDefault();
            PhoneNumber = personDTO.PhoneNumber;   

        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
