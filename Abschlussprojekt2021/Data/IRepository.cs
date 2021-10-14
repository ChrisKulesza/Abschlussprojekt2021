using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Data
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        Task<List<T>> GetAllAsync();
        IEnumerable<T> GetAllSynfusion();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        void Delete(int id);
    }
}
