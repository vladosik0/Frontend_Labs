using System.Linq.Expressions;

namespace BSATask.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<int> FindMaxId(Expression<Func<T, int>> selector);
    }
}
