using System.ComponentModel.DataAnnotations;

namespace Abschlussprojekt2021.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
