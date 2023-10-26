using DailyReport.BusinessLogic.ModelsDTO.IdentityDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using DailyReport.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class WorkplaceValidator
    {
        public static bool WorkplaceExists(string? description, 
            IRepository<Workplace> repositoryWorkplace, UserManager<UserIdentity> user)
        {
            return repositoryWorkplace.GetAll().Any(x => x.Description == description);
        }
    }
}
