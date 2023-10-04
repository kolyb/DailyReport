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
        private readonly IService<PersonPositionDTO> _servicePersonPositionDTO;

        public CreatePersonModel(IService<PersonDTO> servicePersonDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO,
            IService<PersonPositionDTO> servicePersonPositionDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
            _servicePersonPositionDTO = servicePersonPositionDTO;
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
        public string? Position { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        [BindProperty]
        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public IEnumerable<PersonPositionDTO>? PersonPositionDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Options { get; set; }

        [BindProperty]
        public List<SelectListItem>? Positions { get; set; }

        public void OnGet()
        {
            Options = _serviceWorkplaceDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Description
                                  }).ToList();
            Positions = _servicePersonPositionDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Expert
                                  }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {

            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.Id == WorkplaceId);
            PersonPositionDTOs = _servicePersonPositionDTO.GetAll().Where(i => i.Id == PositionId);

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
                personDTO.WorkplaceId = WorkplaceId;
                //personDTO.WorkLocation = WorkLocation;
                personDTO.PositionId = PositionId;
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
