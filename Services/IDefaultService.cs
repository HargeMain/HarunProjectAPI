using HarunProjectAPI.Models;

namespace HarunProjectAPI.Services
{
    public interface IDefaultService
    {
        Task<IEnumerable<DefaultModel>?> GetAllAsync();
        Task<DefaultModel?> GetByIdAsync(int id);
        Task<DefaultModel> CreateAsync(DefaultModel model);
        Task<DefaultModel> UpdateAsync(int id, DefaultModel model);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<DefaultModel>> SearchAsync(string searchTerm);
        Task<IEnumerable<DefaultModel>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
