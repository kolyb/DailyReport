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
        private readonly IService<PositionDTO> _servicePositionDTO;
        private readonly IService<ProfessionDTO> _serviceProfessionDTO;

        public EditPersonModel(IService<PersonDTO> servicePersonDTO, 
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
        public int ProfessionId { get; set; }

        [BindProperty]
        public string? Workplace { get; set; }

        [BindProperty]
        public string? Position { get; set; }

        [BindProperty]
        public string? Profession { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        public List<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public List<PositionDTO>? PositionDTOs { get; set; }

        public List<ProfessionDTO>? ProfessionDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Options { get; set; }

        [BindProperty]
        public List<SelectListItem>? Positions { get; set; }

        [BindProperty]
        public List<SelectListItem>? Professions { get; set; }

        public async Task OnGet(int id)
        {
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().ToList();
            PositionDTOs = _servicePositionDTO.GetAll().ToList();
            ProfessionDTOs = _serviceProfessionDTO.GetAll().ToList();

            Options = _serviceWorkplaceDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Description
                                  }).ToList();
            Positions = _servicePositionDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Description
                                  }).ToList();
            Professions = _serviceProfessionDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Description
                                  }).ToList();

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            LastName = personDTO.LastName;
            Workplace = (from wl in WorkplaceDTOs
                         where wl.Id == personDTO.WorkplaceId
                         select wl.Description).FirstOrDefault();
            Position = (from ps in PositionDTOs
                        where ps.Id == personDTO.PositionId
                        select ps.Description).FirstOrDefault();
            Profession = (from pr in ProfessionDTOs
                          where pr.Id == personDTO.ProfessionId
                          select pr.Description).FirstOrDefault();
            PhoneNumber = personDTO.PhoneNumber;

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(Id);
                personDTO.Id = Id;
                personDTO.Birthday = Birthday;
                personDTO.FirstName = FirstName;
                personDTO.MiddleName = MiddleName;
                personDTO.LastName = LastName;
                //personDTO.WorkplaceId = WorkplaceId;
                //personDTO.PositionId = PositionId;
                //personDTO.ProfessionId = ProfessionId;
                personDTO.PhoneNumber = PhoneNumber;

                await _servicePersonDTO.DeleteAsync(personDTO);

                PersonDTO personNewDTO = new PersonDTO();
                personNewDTO.Birthday = Birthday;
                personNewDTO.FirstName = FirstName;
                personNewDTO.MiddleName = MiddleName;
                personNewDTO.LastName = LastName;
                personNewDTO.WorkplaceId = WorkplaceId;
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
