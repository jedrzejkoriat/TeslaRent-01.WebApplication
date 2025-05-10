namespace TeslaRent_01.WebApplication.Server.Contracts
{
    internal interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> ExistsAsync(int id);
        Task UpdateAsync(T entity);
    }
}
