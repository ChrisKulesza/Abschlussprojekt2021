using DataAccess.EFCore.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.EFCore.Repositories
{
    public class JobAdRepository : GenericRepository<JobAd>, IJobAdRepository
    {
        /// Review: Wird diese Klasse überhaupt benötigt, wenn es ein GenericRepository gibt?
        public JobAdRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
