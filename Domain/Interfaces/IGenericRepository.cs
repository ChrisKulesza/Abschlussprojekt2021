using System.Collections.Generic;

namespace Domain.Interfaces
{
    /// <summary>
    /// This generic interface provides the methods for database access.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Return a <see cref="IEnumerable{T}"/> that contains elements from the input sequence.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Finds an entity with the given primary key values. If an entity with the given
        /// primary key values is being tracked by the context, then it is returned immediately
        /// without making a request to the database. Otherwise, a query is made to the database
        /// for an entity with the given primary key values and this entity, if found, is
        /// attached to the context and returned. If no entity is found, then null is returned.
        /// </summary>
        /// 
        /// <param name="id">The values of the primary key for the entity to be found.</param>
        /// <returns>The entity found, or null.</returns>
        T GetById(int id);

        void Insert(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}
