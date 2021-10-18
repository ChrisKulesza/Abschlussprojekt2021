using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public class InputModel
        {
        }
    }
}
