using Abschlussprojekt2021.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Pages.UserManager
{
    public class AddUserModel : PageModel
    {
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }
            
            [Required]
            [DataType(DataType.Text)]
            public string LastName { get; set; }
            
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Role { get; set; }
        }

        public void OnGetAsync()
        {

        }


        public async Task<RedirectResult> OnPostInsertAsync()
        {


            return Redirect("/UserManager/Index");
        }
    }
}
