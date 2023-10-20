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
        private readonly IService<ReportDayDTO> _serviceReportDayDTO;

        public DetailsReportModel(IService<PersonDTO> servicePersonDTO,
            IService<ReportDTO> serviceReportDTO,
            IService<ReportDayDTO> serviceReportDayDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceReportDTO = serviceReportDTO;
            _serviceReportDayDTO = serviceReportDayDTO;
        }

        public List<PersonDTO>? PersonDTOs { get; set; }

        public List<ReportDTO>? ReportDTOs { get; set; }

        public List<ReportDayDTO>? ReportDayDTOs { get; set; }

        public List<PlanLastnameViewModel>? ReportLastnames { get; set; }

        public void OnGetAsync(int id)
        {
            ReportDTOs = _serviceReportDTO.GetAll().ToList().Where(i => i.ReportDayId == id).ToList();
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            ReportLastnames = (from p in PersonDTOs
                             join rp in ReportDTOs
                             on p.Id equals rp.PersonId
                             orderby rp.Time
                             where rp.ReportDayId == id
                             select new PlanLastnameViewModel {Id = rp.Id, DateTime = rp.Time, Lastname = p.LastName }).ToList();
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
