using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class ProfessionValidator
    {
        public static bool ProfessionExists(string? description,
            IRepository<Profession> repositoryProfession)
        {
            return repositoryProfession.GetAll().Any(x => x.Description == description);
        }
    }
}
