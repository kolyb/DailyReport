namespace DailyReport.DataAccess.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Birthday { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int WorkLocationId { get; set; }      

        public string WorkLocation { get; set; }

        public string PositionWorkLocation { get; set; }

        public int UserIdentityId { get; set; }

        public int EventId { get; set; }

        public string PhoneNumber { get; set; }
    }
}
