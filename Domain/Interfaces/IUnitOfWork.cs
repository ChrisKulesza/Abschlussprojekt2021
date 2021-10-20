using System;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IJobAdRepository JobAd { get; }
        IApplicationUserRepository ApplicationUser { get; }
        int SaveChanges();
    }
}
