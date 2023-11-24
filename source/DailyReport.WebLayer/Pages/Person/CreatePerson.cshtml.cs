using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ValidationException = DailyReport.BusinessLogic.Exceptions.ExceptionValidator.ValidationException;

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
        [DataType(DataType.Date)]
        public string? Birthday { get; set; }

        [BindProperty]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }

        [BindProperty]
        [DataType(DataType.Text)]
        public string? MiddleName { get; set; }

        [BindProperty]
        [DataType(DataType.Text)]
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
        public List<SelectListItem>? Workplaces { get; set; }

        [BindProperty]
        public List<SelectListItem>? Positions { get; set; }

        [BindProperty]
        public List<SelectListItem>? Professions { get; set; }

        public void OnGet()
        {
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll();
            PersonDTOs = _servicePersonDTO.GetAll();

            Workplaces = _serviceWorkplaceDTO.GetAll().Where(i =>i.UserIdentityEmail == User.Identity
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
            try
            {
                var reg = "^[^à-ÿ¸À-ß¨a-zA-Z!@#$%^&*()_={}<>?:,.|'¹;?]+$";

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
                    personDTO.PositionId = PositionId;
                    personDTO.ProfessionId = ProfessionId;

                    if (PhoneNumber == null)
                    {
                        personDTO.PhoneNumber = PhoneNumber;
                    }

                    else if (PhoneNumber != null)
                    {
                        if (Regex.IsMatch(PhoneNumber, reg))
                        {
                            personDTO.PhoneNumber = PhoneNumber;
                        }
                    }                   

                    await _servicePersonDTO.CreateAsync(personDTO);
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
