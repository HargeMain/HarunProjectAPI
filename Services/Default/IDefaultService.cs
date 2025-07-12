using HarunProjectAPI.Models;

namespace HarunProjectAPI.Services.Default
{
    public interface IDefaultService<T> where T : DefaultModel
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(int id, T model);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<T>> SearchAsync(string searchTerm);
        Task<IEnumerable<T>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
