using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Person
{
    public class DetailsPersonModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkLocationDTO> _serviceWorkLocationDTO;
        private readonly IService<PersonPositionDTO> _servicePersonPositionDTO;

        public DetailsPersonModel(IService<PersonDTO> servicePersonDTO,
            IService<WorkLocationDTO> serviceWorkLocationDTO,
            IService<PersonPositionDTO> servicePersonPositionDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
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
        public int WorkLocationId { get; set; }

        [BindProperty]
        public int PositionId { get; set; }

        [BindProperty]
        public string? WorkLocation { get; set; }

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

        public List<WorkLocationDTO>? WorkLocationDTOs { get; set; }

        public List<PersonPositionDTO>? PersonPositionDTOs { get; set; }

        public async Task OnGetAsync(int id)
        {
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            WorkLocationDTOs = _serviceWorkLocationDTO.GetAll().ToList();
            PersonPositionDTOs = _servicePersonPositionDTO.GetAll().ToList();

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Id = personDTO.Id;
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            WorkLocationId = personDTO.WorkLocationId;
            LastName = personDTO.LastName;
            WorkLocation = (from wl in WorkLocationDTOs
                            where wl.Id == personDTO.WorkLocationId
                            select wl.Description).FirstOrDefault();
            AdressCity = (from wl in WorkLocationDTOs
                            where wl.Id == personDTO.WorkLocationId
                            select wl.AdressCity).FirstOrDefault();
            AdressStreet = (from wl in WorkLocationDTOs
                            where wl.Id == personDTO.WorkLocationId
                            select wl.AdressStreet).FirstOrDefault();
            AdressHouse = (from wl in WorkLocationDTOs
                            where wl.Id == personDTO.WorkLocationId
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
