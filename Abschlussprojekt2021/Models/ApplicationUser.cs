using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Abschlussprojekt2021.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
    }
}
