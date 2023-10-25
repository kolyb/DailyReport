using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Person
{
    public class DeletePersonModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<PlanDTO> _servicePlanDTO;

        public DeletePersonModel(IService<PersonDTO> servicePersonDTO, 
            IService<PlanDTO> servicePlanDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _servicePlanDTO = servicePlanDTO;
        }

        [BindProperty]
        public int? Id { get; set; }

        [BindProperty]
        public int PageId { get; set; }

        [BindProperty]
        public string? Birthday { get; set; }

        [BindProperty]
        public string? FirstName { get; set; }

        [BindProperty]
        public string? MiddleName { get; set; }

        [BindProperty]
        public string? LastName { get; set; }

        [BindProperty]
        public int PositionId { get; set; }

        [BindProperty]
        public int ProfessionId { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        [BindProperty]
        public IEnumerable<PlanDTO>? PlanDTOS { get; set; }

        public async Task OnGet(int id)
        {
            PageId = id;

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Id = personDTO.Id;
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            LastName = personDTO.LastName;
            PositionId = personDTO.PositionId;
            ProfessionId = personDTO.ProfessionId;
            PhoneNumber = personDTO.PhoneNumber;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                PlanDTOS = _servicePlanDTO.GetAll().Where(i => i.PersonId == PageId);
                if (ModelState.IsValid)
                {
                    PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(PageId);
                    if (personDTO != null)
                    {
                        personDTO.Id = Id;
                        personDTO.Birthday = Birthday;
                        personDTO.FirstName = FirstName;
                        personDTO.MiddleName = MiddleName;
                        personDTO.LastName = LastName;
                        personDTO.PositionId = PositionId;
                        personDTO.ProfessionId = ProfessionId;
                        personDTO.PhoneNumber = PhoneNumber;


                        await _servicePersonDTO.DeleteAsync(personDTO);
                    }
                }
            } 
            catch (ValidationException ex) 
            {
                return Content(ex.Message);
            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
