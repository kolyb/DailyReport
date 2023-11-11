using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class CreatePlanModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<PlanDTO> _servicePlanDTO;
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public CreatePlanModel(IService<PersonDTO> servicePersonDTO,
            IService<PlanDTO> servicePlanDTO,
            IService<PlanDayDTO> servicePlanDayDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDayDTO = servicePlanDayDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public int PlanDayId { get; set; }

        [BindProperty]
        public TimeSpan StartTime { get; set; }

        [BindProperty]
        public TimeSpan FinishTime { get; set; }

        [BindProperty]
        public TimeSpan IntervalTime { get; set; }

        [BindProperty]
        public DateTime Day { get; set; }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }
        
        [BindProperty]
        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public List<SelectListItem>? Persons { get; set; }

        public async Task OnGet(int id)
        {
            PlanDayDTO planDayDTO = await _servicePlanDayDTO.GetByIdAsync(id);
            Id = planDayDTO.Id;
            Day = planDayDTO.Day;

            StartTime = TimeSpan.FromHours(8);
            FinishTime = TimeSpan.FromHours(8);

            PersonDTOs = _servicePersonDTO.GetAll();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail
            == User?.Identity?.Name);
            Persons = (from ps in PersonDTOs
                       join wp in WorkplaceDTOs
                       on ps.WorkplaceId equals wp.Id
                       select new SelectListItem
                              {
                                 Value = ps.Id.ToString(),
                                 Text = ps.LastName
                              }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlanDTO planDTO = new PlanDTO();
                    planDTO.StartTime = StartTime;
                    planDTO.FinishTime = FinishTime;
                    planDTO.IntervalTime = FinishTime - StartTime;
                    planDTO.PersonId = PersonId;
                    planDTO.PlanDayId = Id;

                    await _servicePlanDTO.CreateAsync(planDTO);
                }
            }
            catch (ValidationException ex) 
            { 
                return Content(ex.Message);
            }
            return RedirectToPage("DetailsPlan", new {id = Id});
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("DetailsPlan", new { id = Id });
        }
    }
}
