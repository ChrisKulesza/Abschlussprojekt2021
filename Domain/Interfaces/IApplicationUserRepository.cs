using Domain.Models;

namespace Domain.Interfaces
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        ApplicationUser GetApplicationUserById(int id);
        ApplicationUser GetApplicationUserById(string id);
    }
}
