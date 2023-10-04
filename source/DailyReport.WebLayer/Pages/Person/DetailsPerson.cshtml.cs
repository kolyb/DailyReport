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
        private readonly IService<PersonPositionDTO> _servicePersonPositionDTO;

        public DetailsPersonModel(IService<PersonDTO> servicePersonDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO,
            IService<PersonPositionDTO> servicePersonPositionDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
            _servicePersonPositionDTO = servicePersonPositionDTO;
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
        public int PositionId { get; set; }

        [BindProperty]
        public string? Workplace { get; set; }

        [BindProperty]
        public string? AdressCity { get; set; }

        [BindProperty]
        public string? AdressStreet { get; set; }

        [BindProperty]
        public string? AdressHouse { get; set; }

        [BindProperty]
        public string? Position { get; set; }

        [BindProperty]
        public string? Expert { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        public List<PersonDTO>? PersonDTOs { get; set; }

        public List<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public List<PersonPositionDTO>? PersonPositionDTOs { get; set; }

        public async Task OnGetAsync(int id)
        {
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().ToList();
            PersonPositionDTOs = _servicePersonPositionDTO.GetAll().ToList();

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Id = personDTO.Id;
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            WorkplaceId = personDTO.WorkplaceId;
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
            Position = (from ps in PersonPositionDTOs
                        where ps.Id == personDTO.PositionId
                        select ps.Position).FirstOrDefault();
            Expert = (from ps in PersonPositionDTOs
                      where ps.Id == personDTO.PositionId
                      select ps.Expert).FirstOrDefault();
            PhoneNumber = personDTO.PhoneNumber;   

        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
