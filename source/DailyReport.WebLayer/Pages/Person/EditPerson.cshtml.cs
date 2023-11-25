using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Person
{
    public class EditPersonModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;
        private readonly IService<PositionDTO> _servicePositionDTO;
        private readonly IService<ProfessionDTO> _serviceProfessionDTO;
        private readonly IService<PlanDTO> _servicePlanDTO;
        private readonly IService<ReportDTO> _serviceReportDTO;

        public EditPersonModel(IService<PersonDTO> servicePersonDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO,
            IService<PositionDTO> servicePositionDTO,
            IService<ProfessionDTO> serviceProfessionDTO,
            IService<PlanDTO> servicePlanDTO,
            IService<ReportDTO> serviceReportDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
            _servicePositionDTO = servicePositionDTO;
            _serviceProfessionDTO = serviceProfessionDTO;
            _servicePlanDTO = servicePlanDTO;
            _serviceReportDTO = serviceReportDTO;
        }

        [BindProperty]
        public int? PageId { get; set; }

        [BindProperty]
        public string? Birthday { get; set; }

        [BindProperty]
        public string? FirstName { get; set; }

        [BindProperty]
        public string? MiddleName { get; set; }

        [BindProperty]
        public string? LastName { get; set; }

        [BindProperty]
        public string? UserName { get; set; }

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

        [BindProperty]
        public List<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public List<WorkplaceDTO>? WorkplaceDTOsPost { get; set; }

        [BindProperty]
        public List<PositionDTO>? PositionDTOs { get; set; }

        [BindProperty]
        public List<ProfessionDTO>? ProfessionDTOs { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonNewDTOs { get; set; }

        [BindProperty]
        public IEnumerable<PlanDTO>? PlanDTOs { get; set; }

        [BindProperty]
        public IEnumerable<ReportDTO>? ReportDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Options { get; set; }

        [BindProperty]
        public List<SelectListItem>? Positions { get; set; }

        [BindProperty]
        public List<SelectListItem>? Professions { get; set; }

        public async Task OnGet(int id)
        {
            PageId = id;
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().ToList();
            PositionDTOs = _servicePositionDTO.GetAll().ToList();
            ProfessionDTOs = _serviceProfessionDTO.GetAll().ToList();

            Options = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail == User.Identity
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

            PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(id);
            PageId = personDTO.Id;
            Birthday = personDTO.Birthday;
            FirstName = personDTO.FirstName;
            MiddleName = personDTO.MiddleName;
            LastName = personDTO.LastName;
            UserName = User.Identity?.Name;
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
            try
            {
                PlanDTOs = _servicePlanDTO.GetAll().Where(i => i.PersonId == PageId);

                ReportDTOs = _serviceReportDTO.GetAll().Where(i => i.PersonId == PageId);

                PersonDTOs = _servicePersonDTO.GetAll().Where(i => i.Id == PageId);

                if (ModelState.IsValid)
                {

                    PersonDTO personDTO = await _servicePersonDTO.GetByIdAsync(PageId);
                    if (personDTO != null)
                    {
                        await _servicePersonDTO.DeleteAsync(personDTO);
                    }

                    PersonDTO personNewDTO = new PersonDTO();
                    personNewDTO.Birthday = Birthday;
                    personNewDTO.FirstName = FirstName;
                    personNewDTO.MiddleName = MiddleName;
                    personNewDTO.LastName = LastName;
                    personNewDTO.WorkplaceId = WorkplaceId;
                    personNewDTO.PositionId = PositionId;
                    personNewDTO.ProfessionId = ProfessionId;
                    personNewDTO.PhoneNumber= PhoneNumber;

                    await _servicePersonDTO.CreateAsync(personNewDTO);
                }

                PersonNewDTOs = _servicePersonDTO.GetAll();

                int? getId = (from ps in PersonNewDTOs
                              where ps.WorkplaceId == WorkplaceId
                              && ps.LastName == LastName
                              select ps.Id).FirstOrDefault();

                foreach (var i in PlanDTOs)
                {
                    PlanDTO planDTO = new PlanDTO();
                    planDTO.StartTime = i.StartTime;
                    planDTO.FinishTime = i.FinishTime;
                    planDTO.IntervalTime = i.FinishTime - i.StartTime;
                    planDTO.PersonId = getId;
                    planDTO.PlanDayId = i.PlanDayId;

                    await _servicePlanDTO.CreateAsync(planDTO);
                }

                foreach (var i in ReportDTOs)
                {
                    ReportDTO reportDTO = new ReportDTO();
                    reportDTO.StartTime = i.StartTime;
                    reportDTO.FinishTime = i.FinishTime;
                    reportDTO.IntervalTime = i.FinishTime - i.StartTime;
                    reportDTO.PersonId = getId;
                    reportDTO.ReportDayId = i.ReportDayId;

                    await _serviceReportDTO.CreateAsync(reportDTO);
                }
            }
            catch(ValidationException ex)
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
