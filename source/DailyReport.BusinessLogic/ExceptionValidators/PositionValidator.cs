using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.ExceptionValidators
{
    public static class PositionValidator
    {
        public static bool PositionExists(string? description, IRepository<Position> 
            repositoryPosition)
        {
            return repositoryPosition.GetAll().Any(x => x.Description == description);
        }
    }
}
