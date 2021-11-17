using DataAccess.EFCore.Data;
using DataAccess.EFCore.Repositories;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace DataAccess.EFCore.UnitOfWork
{
    ///Review: Schlechter Klassenname. Was ist, wenn du eine zweite Klasse erstellt, welche das IUnitOfWork Interface implementiert?
    ///Nennst du es dann UnitOfWork2? :-P Nach den SOLID Regeln sollte zB jede Klasse genau eine Aufgabe haben.
    ///Diese Aufgabe könnte dann den Namen der Klasse prägen

    /// <summary>
    /// This is implementation of UoW pattern.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <value>Constructor injection private field.</value>
        private readonly ApplicationDbContext _context;

        public IJobAdRepository JobAd { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            JobAd = new JobAdRepository(_context);
            ApplicationUser = new ApplicationUserRepository(_context);
        }

        /// <inheritdoc cref="IUnitOfWork"/>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <inheritdoc cref="IUnitOfWork"/>
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
       
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        ///Review: Mir fehlt hier eine Methode wie "Rollback". Oder passiert da irgendeine Magie im Hintergrund?
        ///Wenn nein, dann ist es zwar nett, dass das UnitOfWork pattern verwendet wurde, aber einen wirklichen Mehrwert hat es nicht.
        ///Schlimmer noch steigert es eher die Komplexibilität. Andererseits ist es positiv im Punkt Erweiterbarkeit
    }
}
