using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class DeleteWorkplaceModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public DeleteWorkplaceModel(IService<PersonDTO> servicePersonDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public int WithoutWorkplaceId { get; set; }

        [BindProperty]
        public string? AdressCity { get; set; }

        [BindProperty]
        public string? AdressStreet { get; set; }

        [BindProperty]
        public string? AdressHouse { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public async Task OnGet(int id)
        {
            try
            {
                WorkplaceDTOs = _serviceWorkplaceDTO.GetAll();

                WithoutWorkplaceId = (from wp in WorkplaceDTOs
                                      where wp.Description == "Without workplace"
                                      && wp.UserIdentityEmail == User?.Identity?.Name
                                      select wp.Id).FirstOrDefault();

                WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(id);
                Id = workplaceDTO.Id;
                Description = workplaceDTO.Description;
                AdressCity = workplaceDTO.AdressCity;
                AdressStreet = workplaceDTO.AdressStreet;
                AdressHouse = workplaceDTO.AdressHouse;
            }
            catch (ValidationException ex) 
            {
                Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                PersonDTOs = _servicePersonDTO.GetAll().Where(i => i.WorkplaceId == Id);

                if (ModelState.IsValid)
                {
                    WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(Id);
                    if (workplaceDTO != null)
                    {
                        workplaceDTO.Id = Id;
                        workplaceDTO.UserIdentityEmail = User?.Identity?.Name;
                        workplaceDTO.Description = Description;
                        workplaceDTO.AdressCity = AdressCity;
                        workplaceDTO.AdressStreet = AdressStreet;
                        workplaceDTO.AdressHouse = AdressHouse;

                        await _serviceWorkplaceDTO.DeleteAsync(workplaceDTO);

                        foreach (var i in PersonDTOs)
                        {
                            PersonDTO personNewDTO = new PersonDTO();
                            personNewDTO.Birthday = i.Birthday;
                            personNewDTO.FirstName = i.FirstName;
                            personNewDTO.MiddleName = i.MiddleName;
                            personNewDTO.LastName = i.LastName;
                            personNewDTO.WorkplaceId = WithoutWorkplaceId;
                            personNewDTO.PositionId = i.PositionId;
                            personNewDTO.ProfessionId = i.ProfessionId;
                            personNewDTO.PhoneNumber = i.PhoneNumber;

                            await _servicePersonDTO.CreateAsync(personNewDTO);
                        }
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
