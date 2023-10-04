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
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public EditPersonModel(IService<PersonDTO> servicePersonDTO, 
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
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
        public int WorkplaceId { get; set; }

        [BindProperty]
        public string? Workplace { get; set; }

        
        [BindProperty]
        public string? PhoneNumber { get; set; }

        public List<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Options { get; set; }

        public async Task OnGet(int id)
        {
            Options = _serviceWorkplaceDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Description
                                  }).ToList();

            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().ToList();

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            LastName = personDTO.LastName;
            //WorkLocationId = personDTO.WorkLocationId;
            Workplace = (from wl in WorkplaceDTOs
                            where wl.Id == personDTO.WorkplaceId
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
                personDTO.WorkplaceId = WorkplaceId;
                //personDTO.WorkLocation = WorkLocation;
                personDTO.PositionId = 1;
                personDTO.PhoneNumber = PhoneNumber;

                await _servicePersonDTO.DeleteAsync(personDTO);

                PersonDTO personNewDTO = new PersonDTO();
                personNewDTO.Birthday = Birthday;
                personNewDTO.FirstName = FirstName;
                personNewDTO.MiddleName = MiddleName;
                personNewDTO.LastName = LastName;
                personNewDTO.WorkplaceId = WorkplaceId;
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
