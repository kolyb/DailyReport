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

        public DetailsPersonModel(IService<PersonDTO> servicePersonDTO,
            IService<WorkLocationDTO> serviceWorkLocationDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
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
        public string? WorkLocation { get; set; }

        [BindProperty]
        public string? Position { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        public List<PersonDTO>? PersonDTOs { get; set; }

        public List<WorkLocationDTO>? WorkLocationDTOs { get; set; }

        public async Task OnGetAsync(int id)
        {
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            WorkLocationDTOs = _serviceWorkLocationDTO.GetAll().ToList();

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
            Position = personDTO.Position;
            PhoneNumber = personDTO.PhoneNumber;   

        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
