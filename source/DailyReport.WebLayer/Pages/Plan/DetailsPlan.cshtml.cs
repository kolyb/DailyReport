using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.WebLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class DetailsPlanModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<PlanDTO> _servicePlanDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public DetailsPlanModel(IService<PersonDTO> servicePersonDTO,
            IService<PlanDTO> servicePlanDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _servicePlanDTO = servicePlanDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        [BindProperty]
        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        [BindProperty]
        public IEnumerable<PlanDTO>? PlanDTOs { get; set; }

        [BindProperty]
        public List<PlanAndReportViewModel>? Persons { get; set; }

        [BindProperty]
        public int GetId { get; set; }

        public void OnGetAsync(int id)
        {
            GetId = id;
            PlanDTOs = _servicePlanDTO.GetAll().ToList().Where(i => i.PlanDayId == id);
            PersonDTOs = _servicePersonDTO.GetAll();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail ==
            User?.Identity?.Name);
            Persons = (from p in PersonDTOs
                             join pl in PlanDTOs
                             on p.Id equals pl.PersonId
                             join wp in WorkplaceDTOs
                             on p.WorkplaceId equals wp.Id
                             orderby pl.StartTime
                             where pl.PlanDayId == id
                             select new PlanAndReportViewModel{
                                 Id = pl.Id,
                                 StartTime = pl.StartTime,
                                 FinishTime = pl.FinishTime,
                                 IntervalTime = pl.IntervalTime,
                                 Lastname = p.LastName, 
                                 DescriptionWorkplace = wp.Description,
                             }).ToList();
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
