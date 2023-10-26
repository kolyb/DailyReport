using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class PersonValidator
    {
        public static bool PersonExists(string? firstname, string? middlename, 
            string? lastname, IRepository<Person> repositoryPerson)
        {
            return repositoryPerson.GetAll().Any(x => x.FirstName == firstname 
            && x.MiddleName == middlename && x.LastName == lastname);
        }

    }
}
