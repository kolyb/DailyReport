using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Plan
{
    public class IndexModel : PageModel
    {
        private readonly IService<PlanDTO> _servicePlanDTO;
        private readonly IService<PlanDayDTO> _servicePlanDayDTO;
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public IndexModel(IService<PlanDTO> servicePlanDTO,
            IService<PlanDayDTO> servicePlanDayDTO,
            IService<PersonDTO> servicePersonDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDayDTO = servicePlanDayDTO;
            _servicePersonDTO = servicePersonDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        public IEnumerable<PlanDTO>? PlanDTOs { get; set; }

        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public IEnumerable<PlanDayDTO>? PlanDayNewDTOs { get; set; }

        public IEnumerable<PlanDayDTO>? PlanDayDTOs { get; set; }

        public void OnGet()
        {
            //PersonDTOs = _servicePersonDTO.GetAll();
            //WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail
            //== User?.Identity?.Name);
            //PlanDTOs = _servicePlanDTO.GetAll();
            //PlanDayDTOs = _servicePlanDayDTO.GetAll();
            //PlanDayNewDTOs = (from ps in PersonDTOs
            //                  join wp in WorkplaceDTOs
            //                  on ps.WorkplaceId equals wp.Id
            //                  join pl in PlanDTOs
            //                  on ps.Id equals pl.PersonId
            //                  join pld in PlanDayDTOs
            //                  on pl.PlanDayId equals pld.Id
            //                  select pld).ToList();
            PlanDayDTOs = _servicePlanDayDTO.GetAll();
        }
    }
}
