using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all records of the generic data type from the database.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Retrieves all records of the generic data type from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A set for the given entity type.</returns>
        public IEnumerable<T> GetAllSynfusion()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Retrieves a specific record of the generic data type from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
