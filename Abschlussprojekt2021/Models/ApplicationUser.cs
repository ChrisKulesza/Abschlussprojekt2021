using Microsoft.AspNetCore.Identity;

namespace Abschlussprojekt2021.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string Role;
    }
}
