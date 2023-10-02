using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Person
{
    public class DeletePersonModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;

        public DeletePersonModel(IService<PersonDTO> servicePersonDTO)
        {
            _servicePersonDTO = servicePersonDTO;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

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

        //[BindProperty]
        //public string? WorkLocation { get; set; }

        [BindProperty]
        public string? Position { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        public async Task OnGet(int id)
        {
            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            LastName = personDTO.LastName;
            WorkLocationId = personDTO.WorkLocationId;
            //WorkLocation = personDTO.WorkLocation;
            Position = personDTO.Position;
            PhoneNumber = personDTO.PhoneNumber;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(Id);
                if (personDTO != null)
                {
                    personDTO.Id = Id;
                    personDTO.Birthday = Birthday;
                    personDTO.FirstName = FirstName;
                    personDTO.MiddleName = MiddleName;
                    personDTO.LastName = LastName;
                    personDTO.WorkLocationId = WorkLocationId;
                    //personDTO.WorkLocation = WorkLocation;
                    personDTO.Position = Position;
                    personDTO.PhoneNumber = PhoneNumber;


                    await _servicePersonDTO.DeleteAsync(personDTO);
                }
            }

            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}