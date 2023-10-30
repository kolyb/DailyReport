using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class ReportMapper
    {
        public static Report FromDTO(ReportDTO item)
        {
            Report report = new Report
            {
                Id = item.Id,
                PersonId = item.PersonId,
                ReportDayId = item.ReportDayId,
                StartTime = item.StartTime,
                FinishTime = item.FinishTime,
                IntervalTime = item.IntervalTime,
            };
            return report;
        }

        public static ReportDTO ToDTO(Report item)
        {
            ReportDTO reportDTO = new ReportDTO
            {
                Id = item.Id,
                PersonId = item.PersonId,
                ReportDayId = item.ReportDayId,
                StartTime = item.StartTime,
                FinishTime = item.FinishTime,
                IntervalTime = item.IntervalTime,
            };
            return reportDTO;
        }

        public static List<ReportDTO> ToDTO(List<Report> list)
        {
            List<ReportDTO> reportDTOs = new List<ReportDTO>();
            foreach (var item in list)
            {
                reportDTOs.Add(new ReportDTO
                {
                    Id = item.Id,
                    PersonId = item.PersonId,
                    ReportDayId = item.ReportDayId,
                    StartTime = item.StartTime,
                    FinishTime = item.FinishTime,
                    IntervalTime = item.IntervalTime,
                });
            }
            return reportDTOs;
        }
    }
}
