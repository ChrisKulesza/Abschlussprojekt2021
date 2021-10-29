using DataAccess.EFCore.Data;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EFCore.Repositories
{
    /// <summary>
    /// Generic repository class for database access.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <value>Constructor injection database context private field.</value>
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// 
        /// <inheritdoc cref="Domain.Interfaces.IGenericRepository{T}.GetAll"/>
        /// <returns>A <see cref="IEnumerable{T}" /> that contains elements from the input sequence.</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Filters a sequence of values based on a id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Updates changes of the existing entity. The caller must later call SaveChanges() 
        /// on the repository explicitly to save the entity to database.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
