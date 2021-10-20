using Abschlussprojekt2021.Resources;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Abschlussprojekt2021.Pages.UserManager
{
    public class EditUserModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationUser user = new();

        [BindProperty]
        public InputModel Input { get; set; }

        public EditUserModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(string id)
        {
            user = _unitOfWork.ApplicationUser.GetApplicationUserById(id);
        }

        public RedirectResult OnPost(string id)
        {
            user = _unitOfWork.ApplicationUser.GetApplicationUserById(id);

            if (ModelState.IsValid)
            {
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.Email = Input.Email;
                user.Role = Input.Role;
            }

            _unitOfWork.ApplicationUser.Update(user);
            _unitOfWork.SaveChanges();

            return Redirect("/UserManager/index");
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

            [Required]
            [Display(Name = Constants.formRole)]
            public string Role { get; set; }
        }
    }
}
