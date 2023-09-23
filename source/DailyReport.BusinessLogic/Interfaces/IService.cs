namespace DailyReport.BusinessLogic.Interfaces
{
    public interface IService<T> where T : class
    {
        Task CreateAsync(T item);

        Task DeleteAsync(T item);

        Task UpdateAsync(T item);

        Task<T> GetByIdAsync(int id);

        IList<T> GetAll();
    }
}
