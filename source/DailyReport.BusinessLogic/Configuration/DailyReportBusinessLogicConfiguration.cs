using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Interfaces.IdentityInterface;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.BusinessLogic.Servicies.IdentityService;
using DailyReport.DataAccess.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyReport.BusinessLogic.Configuration
{
    public static class DailyReportBusinessLogicConfiguration
    {
        public static void ConfigureDailyReportBusinessLogic(this IServiceCollection services)
        {
            services.ConfigureDailyReportDataAccess();
            services.AddScoped<IUserIdentity, UserIdentityService>();
            services.AddScoped<IService<PersonDTO>, PersonService>();
            services.AddScoped<IService<WorkplaceDTO>, WorkplaceService>();
            services.AddScoped<IService<EventDTO>, EventService>();
            services.AddScoped<IService<PositionDTO>, PositionService>();
            services.AddScoped<IService<ProfessionDTO>, ProfessionService>();

        }
    }
}
