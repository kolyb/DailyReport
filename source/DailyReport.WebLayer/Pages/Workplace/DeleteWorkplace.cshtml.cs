using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class DeleteWorkplaceModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;
        private readonly IService<PositionDTO> _servicePositionDTO;
        private readonly IService<ProfessionDTO> _serviceProfessionDTO;

        public DeleteWorkplaceModel(IService<PersonDTO> servicePersonDTO,
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
        public int Id { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public int? WithoutWorkplaceId { get; set; }

        [BindProperty]
        public string? AdressCity { get; set; }

        [BindProperty]
        public string? AdressStreet { get; set; }

        [BindProperty]
        public string? AdressHouse { get; set; }

        //to create a new person
        [BindProperty]
        public int? PersonId { get; set; }

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
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public async Task OnGet(int id)
        {
            PersonDTOs = _servicePersonDTO.GetAll();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll();

            WithoutWorkplaceId = (from wp in WorkplaceDTOs
                                  where wp.Description == "Without workplace"
                                  select wp.Id).FirstOrDefault();

            WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(id);
            Id = workplaceDTO.Id;
            Description = workplaceDTO.Description;
            AdressCity = workplaceDTO.AdressCity;
            AdressStreet = workplaceDTO.AdressStreet;
            AdressHouse = workplaceDTO.AdressHouse;

            PersonId = (from ps in PersonDTOs
                        where ps.WorkplaceId == id
                             select ps.Id).FirstOrDefault();

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(PersonId);
            if (personDTO != null)
            {
                //Id = personDTO.Id;
                Birthday = personDTO.Birthday;
                FirstName = personDTO.FirstName;
                MiddleName = personDTO.MiddleName;
                LastName = personDTO.LastName;
                PositionId = personDTO.PositionId;
                ProfessionId = personDTO.ProfessionId;
                PhoneNumber = personDTO.PhoneNumber;

            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(Id);
                if (workplaceDTO != null)
                {
                    workplaceDTO.Id = Id;
                    workplaceDTO.Description = Description;
                    workplaceDTO.AdressCity = AdressCity;
                    workplaceDTO.AdressStreet = AdressStreet;
                    workplaceDTO.AdressHouse = AdressHouse;
                    

                    await _serviceWorkplaceDTO.DeleteAsync(workplaceDTO);
                }


                PersonDTO personNewDTO = new PersonDTO();
                personNewDTO.Birthday = Birthday;
                personNewDTO.FirstName = FirstName;
                personNewDTO.MiddleName = MiddleName;
                personNewDTO.LastName = LastName;
                personNewDTO.UserIdentityEmail = User.Identity?.Name;
                personNewDTO.WorkplaceId = (int)WithoutWorkplaceId;
                personNewDTO.PositionId = PositionId;
                personNewDTO.ProfessionId = ProfessionId;
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
