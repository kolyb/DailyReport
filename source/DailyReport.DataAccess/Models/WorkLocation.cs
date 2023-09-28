namespace DailyReport.DataAccess.Models
{
    public class WorkLocation
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string? Description { get; set; }

        public string? AdressWorkLocation { get; set; } 
    }
}
