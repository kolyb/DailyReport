using DailyReport.DataAccess.EntityFrameworkCore;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.DataAccess.Repositories
{
    public class PlanDayRepository : IRepository<PlanDay>
    {
        private readonly DailyReportContext _db;

        private IDisposable? _disposableResource = new MemoryStream();
        private IAsyncDisposable? _asyncDisposableResource = new MemoryStream();

        public PlanDayRepository(DailyReportContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task CreateAsync(PlanDay item)
        {
            _db.PlanDays.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(PlanDay item)
        {
            _db.PlanDays.Remove(item);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposableResource?.Dispose();
                (_asyncDisposableResource as IDisposable)?.Dispose();
            }

            _disposableResource = null;
            _asyncDisposableResource = null;
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_asyncDisposableResource != null)
            {
                await _asyncDisposableResource.DisposeAsync().ConfigureAwait(false);
            }

            if (_disposableResource is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                _disposableResource?.Dispose();
            }

            _asyncDisposableResource = null;
            _disposableResource = null;
        }

        public IEnumerable<PlanDay> GetAll()
        {
            return _db.PlanDays.AsQueryable();
        }

        public async Task<PlanDay> GetByIdAsync(int? id)
        {
            var result = await _db.PlanDays.FindAsync(id);
            if (result == null)
            {
                //
                throw new Exception();
            }
            return result;
        }

        public async Task UpdateAsync(PlanDay item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
