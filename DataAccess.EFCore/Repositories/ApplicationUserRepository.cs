using DataAccess.EFCore.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.EFCore.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationUser GetApplicationUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public ApplicationUser GetApplicationUserById(string id)
        {
            return _context.Users.Find(id);
        }
    }
}
