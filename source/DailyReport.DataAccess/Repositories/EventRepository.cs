using DailyReport.DataAccess.EntityFrameworkCore;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.DataAccess.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly DailyReportContext _db;

        public EventRepository(DailyReportContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task CreateAsync(Event item)
        {
            _db.Events.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Event item)
        {
            _db.Events.Remove(item);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Event> GetAll()
        {
            return _db.Events.AsQueryable();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var result = await _db.Events.FindAsync(id);
            if (result == null)
            {
                //
                throw new Exception();
            }
            return result;
        }

        public async Task UpdateAsync(Event item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
