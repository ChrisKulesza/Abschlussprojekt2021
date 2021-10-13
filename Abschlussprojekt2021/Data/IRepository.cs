using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Data
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
