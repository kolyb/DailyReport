using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.WebLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Report
{
    public class DetailsReportModel : PageModel
    {
        private readonly IService<PersonDTO> _servicePersonDTO;
        private readonly IService<ReportDTO> _serviceReportDTO;
        private readonly IService<PlanDayDTO> _servicePlanDateDTO;

        public DetailsReportModel(IService<PersonDTO> servicePersonDTO,
            IService<ReportDTO> serviceReportDTO,
            IService<PlanDayDTO> servicePlanDateDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceReportDTO = serviceReportDTO;
            _servicePlanDateDTO = servicePlanDateDTO;
        }

        public List<PersonDTO>? PersonDTOs { get; set; }

        public List<ReportDTO>? ReportDTOs { get; set; }

        public List<PlanDayDTO>? PlanDateDTOs { get; set; }

        public List<PlanLastnameViewModel>? ReportLastnames { get; set; }

        public void OnGetAsync(int id)
        {
            ReportDTOs = _serviceReportDTO.GetAll().ToList().Where(i => i.PlanDateId == id).ToList();
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            ReportLastnames = (from p in PersonDTOs
                             join rp in ReportDTOs
                             on p.Id equals rp.PersonId
                             orderby rp.Time
                             where rp.PlanDateId == id
                             select new PlanLastnameViewModel { DateTime = rp.Time, Lastname = p.LastName }).ToList();
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
