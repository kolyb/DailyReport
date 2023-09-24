﻿using DailyReport.DataAccess.EntityFrameworkCore;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using DailyReport.DataAccess.Models.Identity;
using DailyReport.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DailyReport.DataAccess.Configuration
{
    public static class DailyReportDataAccessConfiguration
    {
        public static void ConfigureDailyReportDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<DailyReportContext>();
            services.AddIdentityCore<UserIdentity>()
                .AddEntityFrameworkStores<DailyReportContext>();
            services.AddIdentityCore<IdentityRole>()
                .AddEntityFrameworkStores<DailyReportContext>();
            services.AddScoped<IRepository<Event>, EventRepository>();
            services.AddScoped<IRepository<Person>, PersonRepository>();
            services.AddScoped<IRepository<WorkLocation>, WorkLocationRepository>();
        }
    }
}