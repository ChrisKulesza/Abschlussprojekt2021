using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
