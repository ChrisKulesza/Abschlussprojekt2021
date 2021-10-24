using System;

namespace Domain.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IJobAdRepository JobAd { get; }

        /// <summary>
        /// 
        /// </summary>
        IApplicationUserRepository ApplicationUser { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
