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

        public DbSet<Position> Positions { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Workplace> Workplaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DailyReport;Trusted_Connection=True;");
            }
        }

    }
}
