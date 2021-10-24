using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    /// <summary>
    /// Provides the entity of the program user. Which inherits from the IdentityUser class.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <value>First name of the user.</value>
        public string FirstName { get; set; }

        /// <value>Last name of the user.</value>
        public string LastName { get; set; }

        /// <value>Role of the user for Role based access control.</value>
        public string Role { get; set; }
    }
}
