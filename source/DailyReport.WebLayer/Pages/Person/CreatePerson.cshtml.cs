using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyReport.WebLayer.Pages.Person
{
    public class CreatePersonModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;
        private readonly IService<PositionDTO> _servicePositionDTO;
        private readonly IService<ProfessionDTO> _serviceProfessionDTO;

        public CreatePersonModel(IService<PersonDTO> servicePersonDTO,
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
        public string? Description { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        [BindProperty]
        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public IEnumerable<PositionDTO>? PositionDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Options { get; set; }

        [BindProperty]
        public List<SelectListItem>? Positions { get; set; }

        [BindProperty]
        public List<SelectListItem>? Professions { get; set; }

        public void OnGet()
        {
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll();
            PersonDTOs = _servicePersonDTO.GetAll();

            //Options = (from ps in PersonDTOs
            //           join wp in WorkplaceDTOs
            //           on ps.WorkplaceId equals wp.Id
            //           where wp.UserIdentityEmail == User.Identity?.Name
            //           select new SelectListItem
            //           {
            //               Value = wp.Id.ToString(),
            //               Text = wp.Description
            //           }).ToList();

            Options = _serviceWorkplaceDTO.GetAll().Where(i =>i.UserIdentityEmail == User.Identity
            ?.Name).
            Select(a =>
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
        }

        public async Task<IActionResult> OnPost()
        {

            //WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.Id == WorkplaceId);
            //PositionDTOs = _servicePositionDTO.GetAll().Where(i => i.Id == PositionId);

            //foreach (var item in WorkLocationDTOs)
            //{
            //    WorkLocation = item.Description;
            //}

            if (WorkplaceId == 0)
            {
                return RedirectToPage("Index");
            }

            if (ModelState.IsValid)
            {
                PersonDTO personDTO = new PersonDTO();
                personDTO.Birthday = Birthday;
                personDTO.FirstName = FirstName;
                personDTO.MiddleName = MiddleName;
                personDTO.LastName = LastName;
                personDTO.UserIdentityEmail = User.Identity?.Name;
                personDTO.WorkplaceId = WorkplaceId;
                personDTO.PositionId = PositionId;
                personDTO.ProfessionId = ProfessionId;
                personDTO.PhoneNumber = PhoneNumber;


                await _servicePersonDTO.CreateAsync(personDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
