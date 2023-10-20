using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public class ReportDayMapper
    {
        public static ReportDay FromDTO(ReportDayDTO item)
        {
            ReportDay reportDay = new ReportDay
            {
                Id = item.Id,
                RecordDay = item.RecordDay,

            };
            return reportDay;
        }

        public static ReportDayDTO ToDTO(ReportDay item)
        {
            ReportDayDTO reportDayDTO = new ReportDayDTO
            {
                Id = item.Id,
                RecordDay = item.RecordDay,

            };
            return reportDayDTO;
        }

        public static List<ReportDayDTO> ToDTO(List<ReportDay> list)
        {
            List<ReportDayDTO> reportDayDTOs = new List<ReportDayDTO>();
            foreach (var item in list)
            {
                reportDayDTOs.Add(new ReportDayDTO
                {
                    Id = item.Id,
                    RecordDay = item.RecordDay,
                });
            }
            return reportDayDTOs;
        }
    }
}
