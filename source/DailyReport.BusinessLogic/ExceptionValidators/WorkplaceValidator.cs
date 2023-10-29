using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class WorkplaceValidator
    {
        public static bool WorkplaceExists(string? description,
            string? adresscity,
            string? adressstreet,
            string? adresshouse,
            string? useridentityemail,
            IRepository<Workplace> repositoryWorkplace)
        {
            return repositoryWorkplace.GetAll().Any(x => x.Description == description 
            && x.AdressCity == adresscity && x.AdressStreet == adressstreet 
            && x.AdressHouse == adresshouse && x.UserIdentityEmail == useridentityemail);
        }
    }
}
 