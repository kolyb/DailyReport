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

        public DetailsPlanModel(IService<PersonDTO> servicePersonDTO,
            IService<PlanDTO> servicePlanDTO,
            IService<PlanDayDTO> servicePlanDayDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _servicePlanDTO = servicePlanDTO;
            _servicePlanDayDTO = servicePlanDayDTO;
        }

        public List<PersonDTO>? PersonDTOs { get; set; }

        public List<PlanDTO>? PlanDTOs { get; set; }

        public List<PlanDayDTO>? PlanDayDTOs { get; set; }

        public List<PlanLastnameViewModel>? PlanLastnames { get; set; }

        public void OnGetAsync(int id)
        {
            PlanDTOs = _servicePlanDTO.GetAll().ToList().Where(i => i.PlanDayId == id).ToList();
            //PlanDateDTOs = _servicePlanDateDTO.GetAll().Where(i => i.Id == id).ToList();
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            PlanLastnames = (from p in PersonDTOs
                             join pl in PlanDTOs
                             on p.Id equals pl.PersonId
                             orderby pl.PlanTime
                             where pl.PlanDayId == id
                             select new PlanLastnameViewModel{ Id = pl.Id, DateTime = pl.PlanTime,Lastname = p.LastName }).ToList();
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
