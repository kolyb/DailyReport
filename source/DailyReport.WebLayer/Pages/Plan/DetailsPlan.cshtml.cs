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
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public DetailsPlanModel(IService<PersonDTO> servicePersonDTO,
            IService<PlanDTO> servicePlanDTO,
            IService<PlanDayDTO> servicePlanDayDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDayDTO = servicePlanDayDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public IEnumerable<PlanDTO>? PlanDTOs { get; set; }

        public List<PlanDayDTO>? PlanDayDTOs { get; set; }

        public List<PlanLastnameViewModel>? PlanLastnames { get; set; }

        public void OnGetAsync(int id)
        {
            PlanDTOs = _servicePlanDTO.GetAll().ToList().Where(i => i.PlanDayId == id);
            PersonDTOs = _servicePersonDTO.GetAll();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail ==
            User?.Identity?.Name);
            PlanLastnames = (from p in PersonDTOs
                             join pl in PlanDTOs
                             on p.Id equals pl.PersonId
                             join wp in WorkplaceDTOs
                             on p.WorkplaceId equals wp.Id
                             orderby pl.StartTime
                             where pl.PlanDayId == id
                             select new PlanLastnameViewModel{ Id = pl.Id, 
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
