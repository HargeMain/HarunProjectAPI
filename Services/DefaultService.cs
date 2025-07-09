using HarunProjectAPI.Models;

namespace HarunProjectAPI.Services
{
    public class DefaultService : IDefaultService
    {

        private readonly DBContext.DBContext _dbContext;
        public DefaultService(DBContext.DBContext dBContext)
        {
            this._dbContext = dBContext;
        }
        public virtual async Task<IEnumerable<DefaultModel>?> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<DefaultModel>?>(null);
        }

        public virtual async Task<DefaultModel?> GetByIdAsync(int id)
        {
            return await Task.FromResult<DefaultModel?>(null);
        }

        public virtual async Task<DefaultModel> CreateAsync(DefaultModel model)
        {
            return await Task.FromResult(model);
        }

        public virtual async Task<DefaultModel> UpdateAsync(int id, DefaultModel model)
        {
            return await Task.FromResult(model);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult(false);
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            return await Task.FromResult(false);
        }

        public virtual async Task<IEnumerable<DefaultModel>> SearchAsync(string searchTerm)
        {
            return await Task.FromResult(new List<DefaultModel>());
        }

        public virtual async Task<IEnumerable<DefaultModel>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await Task.FromResult(new List<DefaultModel>());
        }
    }
}
