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
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public DetailsReportModel(IService<PersonDTO> servicePersonDTO,
            IService<ReportDTO> serviceReportDTO,
            IService<ReportDayDTO> serviceReportDayDTO,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _servicePersonDTO = servicePersonDTO;
            _serviceReportDTO = serviceReportDTO;
            _serviceReportDayDTO = serviceReportDayDTO;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        public List<PersonDTO>? PersonDTOs { get; set; }

        public IEnumerable<ReportDTO>? ReportDTOs { get; set; }

        public IEnumerable<ReportDayDTO>? ReportDayDTOs { get; set; }

        public IEnumerable<WorkplaceDTO>? WorkplaceDTOs { get; set; }

        public List<PlanLastnameViewModel>? ReportLastnames { get; set; }

        public void OnGetAsync(int id)
        {
            ReportDTOs = _serviceReportDTO.GetAll().ToList().Where(i => i.ReportDayId
            == id).ToList();
            PersonDTOs = _servicePersonDTO.GetAll().ToList();
            WorkplaceDTOs = _serviceWorkplaceDTO.GetAll().Where(i => i.UserIdentityEmail ==
            User?.Identity?.Name);
            ReportLastnames = (from p in PersonDTOs
                               join rp in ReportDTOs
                               on p.Id equals rp.PersonId
                               join wp in WorkplaceDTOs
                               on p.WorkplaceId equals wp.Id
                               orderby rp.StartTime
                               where rp.ReportDayId == id
                               select new PlanLastnameViewModel {Id = rp.Id,
                                   StartTime = rp.StartTime,
                                   FinishTime = rp.FinishTime,
                                   IntervalTime = rp.IntervalTime,
                                   Lastname = p.LastName,
                                 DescriptionWorkplace = wp.Description}).ToList();
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
