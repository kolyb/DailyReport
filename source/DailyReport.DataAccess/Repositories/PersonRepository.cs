using DailyReport.DataAccess.EntityFrameworkCore;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.DataAccess.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly DailyReportContext _db;

        private IDisposable? _disposableResource = new MemoryStream();
        private IAsyncDisposable? _asyncDisposableResource = new MemoryStream();

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

        public IEnumerable<Person> GetAll()
        {
            return _db.Persons.AsQueryable();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var result = await _db.Persons.FindAsync(id);
            if (result == null)
            {
                //
                throw new Exception();
            }
            return result;
        }

        public async Task UpdateAsync(Person item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            //_db.Database.ExecuteSqlRaw("UpdatePerson @personId ={0},@birthday ={1}," +
            //    "@firstName ={2},@middleName={3}, @lastName={4}, @workLocationId={5}," +
            //    "@workLocation={6}, @positionWorkLocation={7}, @userIdentityId={8}, @phoneNumber={9}",
            //    item.Id, item.Birthday, item.FirstName, item.MiddleName, item.LastName,
            //    item.WorkLocationId, item.WorkLocation, item.PositionWorkLocation, item.UserIdentityId,
            //    item.PhoneNumber);
        }
    }  
    
}
