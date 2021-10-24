using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Unit of work interface
    /// Maintains a list of objects affected by a business transaction and coordinates 
    /// the writing out of changes and the resolution of concurrency problems.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IJobAdRepository JobAd { get; }

        IApplicationUserRepository ApplicationUser { get; }

        /// <summary>
        /// Commits the changes to database.
        /// </summary>
        /// <returns></returns>
        int Complete();

        /// <summary>
        /// Asynchronously commits changes to database.
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();
    }
}
