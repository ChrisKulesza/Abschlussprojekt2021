using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Pages.UserManager
{
    public class EditUserModel : PageModel
    {
        private readonly IRepository<ApplicationUser> _repository;
        public ApplicationUser User { get; set; }
        public InputModel Input { get; set; }

        public EditUserModel(IRepository<ApplicationUser> repository)        {
            _repository = repository;
        }
        public void OnGet(string id)
        {
            User = _repository.GetById(id);
        }

        public async Task<RedirectResult> OnPotsAsync(string id)
        {
            User = await _repository.GetByIdAsync(id);

            if (ModelState.IsValid)
            {
                User.FirstName = Input.FirstName;
                User.LastName = Input.LastName;
                User.Email = Input.Email;
            }
            return Redirect("/UserManager/Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = Constants.formFirstName)]
            public string FirstName { get; set; }
            
            [Required]
            [Display(Name = Constants.formLastName)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = Constants.formEmail)]
            public string Email { get; set; }
        }
    }
}
