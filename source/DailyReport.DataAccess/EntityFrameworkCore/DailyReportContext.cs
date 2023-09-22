using DailyReport.DataAccess.Models;
using DailyReport.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.DataAccess.EntityFrameworkCore
{
    public class DailyReportContext : IdentityDbContext<UserIdentity>
    {
        public DailyReportContext()
        {
        }

        public DailyReportContext(DbContextOptions<DailyReportContext> options)
            : base(options)
        {
            ///Database.EnsureCreated();
        }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    }
}
