namespace DailyReport.DataAccess.Models
{
    public class Person
    {
        public int? Id { get; set; }

        public string? Birthday { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public int WorkplaceId { get; set; }

        public int PositionId { get; set; }

        public int ProfessionId { get; set; }

        //public int UserIdentityId { get; set; }

        public string? PhoneNumber { get; set;}

    }
}
