namespace DailyReport.DataAccess.Interfaces
{
    public interface IRepository<T> : IDisposable, IAsyncDisposable
         where T : class
    {
        Task CreateAsync(T item);

        Task DeleteAsync(T item);

        Task UpdateAsync(T item);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();
    }
}
