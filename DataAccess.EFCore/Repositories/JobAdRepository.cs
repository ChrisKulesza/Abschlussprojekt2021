using DataAccess.EFCore.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.EFCore.Repositories
{
    public class JobAdRepository : GenericRepository<JobAd>, IJobAdRepository
    {
        public JobAdRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
