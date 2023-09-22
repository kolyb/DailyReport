using DailyReport.DataAccess.EntityFrameworkCore;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DailyReport.DataAccess.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly DailyReportContext _db;

        public PersonRepository(DailyReportContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task CreateAsync(Person item)
        {
            _db.Persons.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person item)
        {
            _db.Persons.Remove(item);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.Persons.AsQueryable();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.Persons.FindAsync(id);
        }

        public async Task UpdateAsync(Person item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
