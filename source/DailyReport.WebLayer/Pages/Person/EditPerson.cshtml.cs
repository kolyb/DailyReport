using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyReport.WebLayer.Pages.Person
{
    public class EditPersonModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkLocationDTO> _serviceWorkLocationDTO;

        public EditPersonModel(IService<PersonDTO> servicePersonDTO, IService<WorkLocationDTO> serviceWorkLocationDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string? Birthday { get; set; }

        [BindProperty]
        public string? FirstName { get; set; }

        [BindProperty]
        public string? MiddleName { get; set; }

        [BindProperty]
        public string? LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int WorkLocationId { get; set; }

        [BindProperty]
        public string? WorkLocation { get; set; }

        
        [BindProperty]
        public string? PhoneNumber { get; set; }

        public List<WorkLocationDTO>? WorkLocationDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Options { get; set; }

        public async Task OnGet(int id)
        {
            Options = _serviceWorkLocationDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Description
                                  }).ToList();

            WorkLocationDTOs = _serviceWorkLocationDTO.GetAll().ToList();

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            LastName = personDTO.LastName;
            //WorkLocationId = personDTO.WorkLocationId;
            WorkLocation = (from wl in WorkLocationDTOs
                            where wl.Id == personDTO.WorkLocationId
                            select wl.Description).FirstOrDefault();
            //Position = personDTO.Position;
            PhoneNumber = personDTO.PhoneNumber;

            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(Id);
                personDTO.Birthday = Birthday;
                personDTO.FirstName = FirstName;
                personDTO.MiddleName = MiddleName;
                personDTO.LastName = LastName;
                personDTO.WorkLocationId = WorkLocationId;
                //personDTO.WorkLocation = WorkLocation;
                personDTO.PositionId = 1;
                personDTO.PhoneNumber = PhoneNumber;

                await _servicePersonDTO.DeleteAsync(personDTO);

                PersonDTO personNewDTO = new PersonDTO();
                personNewDTO.Birthday = Birthday;
                personNewDTO.FirstName = FirstName;
                personNewDTO.MiddleName = MiddleName;
                personNewDTO.LastName = LastName;
                personNewDTO.WorkLocationId = WorkLocationId;
                //personDTO.WorkLocation = WorkLocation;
                personNewDTO.PositionId = 1;
                personNewDTO.PhoneNumber = PhoneNumber;

                await _servicePersonDTO.CreateAsync(personNewDTO);
                
            }

            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
