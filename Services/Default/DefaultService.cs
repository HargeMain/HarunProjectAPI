using HarunProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HarunProjectAPI.Services.Default
{
    public class DefaultService<T> : IDefaultService<T> where T : DefaultModel
    {

        private readonly DBContext.DBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public DefaultService(DBContext.DBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> CreateAsync(T model)
        {
            _dbSet.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public virtual async Task<T> UpdateAsync(int id, T model)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Entity not found");

            _dbContext.Entry(existing).CurrentValues.SetValues(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }

        public virtual async Task<IEnumerable<T>> SearchAsync(string searchTerm)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var props = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            Expression? predicate = null;
            foreach (var prop in props)
            {
                var property = Expression.Property(parameter, prop);
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                var search = Expression.Constant(searchTerm, typeof(string));
                var containsCall = Expression.Call(property, containsMethod, search);

                predicate = predicate == null ? containsCall : Expression.OrElse(predicate, containsCall);
            }

            if (predicate == null) return new List<T>();

            var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);
            return await _dbSet.Where(lambda).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var prop = typeof(T).GetProperty("CreatedAt");
            if (prop == null || prop.PropertyType != typeof(DateTime))
                return new List<T>();

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, "CreatedAt");

            var start = Expression.Constant(startDate);
            var end = Expression.Constant(endDate);

            var afterStart = Expression.GreaterThanOrEqual(property, start);
            var beforeEnd = Expression.LessThanOrEqual(property, end);
            var between = Expression.AndAlso(afterStart, beforeEnd);

            var lambda = Expression.Lambda<Func<T, bool>>(between, parameter);
            return await _dbSet.Where(lambda).ToListAsync();
        }
    }
}
