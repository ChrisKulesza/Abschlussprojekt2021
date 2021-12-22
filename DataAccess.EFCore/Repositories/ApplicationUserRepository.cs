using DataAccess.EFCore.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.EFCore.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        /// Review: Wird diese Klasse überhaupt benötigt, wenn es ein GenericRepository gibt?
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationUser GetApplicationUserById(int id)
        {
            return _context.Users.Find(id);
        }

        ///Review: Du befindest dich sehr nah an der Datenbank. An dieser Stelle würde ich keine zwei Datentypen für das gleiche Property unterstützen.
        ///Stell dir vor dein Application User hat irgendwann 100 Properties. Und das alter kann ein Int, ein String, Ein Float ... sein. 
        ///Die ID ist in der Datenbank vermutlich eine natürliche Zahl. In diesem Fall müsste diese Methode den Parameter validieren bevor ein .Find gemacht wird.
        ///Lange Rede, kurzer Sinn. Eine Methode löschen und dann muss der Caller sich um das parsen von int to string oder von string to int kümmern.
        public ApplicationUser GetApplicationUserById(string id)
        {
            return _context.Users.Find(id);
        }
    }
}
