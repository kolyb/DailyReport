namespace DailyReport.DataAccess.Models
{
    public class Workplace
    {
        public int Id { get; set; }

        public string? UserIdentityEmail { get; set; }

        public string? Description { get; set; }

        public string? AdressCity { get; set; } 

        public string? AdressStreet { get; set; }
        
        public string? AdressHouse { get; set; } 
    }
}
