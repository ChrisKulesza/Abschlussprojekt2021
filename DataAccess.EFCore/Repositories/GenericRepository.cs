using DataAccess.EFCore.Data;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EFCore.Repositories
{
    /*
        Also note that, for the ADD and Remove Functions, we just do the operation on the dbContext object.
        But we are not yet commiting/updating/saving the changes to the database whatsover. This is not 
        something to be done in a Repository Class. We would need Unit of Work Pattern for these cases 
        where you commit data to the database. We will discuss about Unit of Work in a later section.
     */

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
