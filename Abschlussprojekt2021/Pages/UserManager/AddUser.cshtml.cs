using Abschlussprojekt2021.Resources;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Abschlussprojekt2021.Pages.UserManager
{
    public class AddUserModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUserModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        new public ApplicationUser User { get; set; }
        
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = Constants.formFirstName)]
            public string FirstName { get; set; }
            
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = Constants.formLastName)]
            public string LastName { get; set; }
            
            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = Constants.formEmail)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = Constants.formRole)]
            public string Role { get; set; }
        }

        public RedirectResult OnPostInsert()
        {
            if (ModelState.IsValid)
            {
                return Redirect("/UserManager/Index");
            } else
                {
                User.FirstName = Input.FirstName;
                User.LastName = Input.LastName;
                User.Email = Input.Email;
                User.Role = Input.Role;
                }

            _unitOfWork.ApplicationUser.Insert(User);
            _unitOfWork.SaveChanges();

            return Redirect("/UserManager/Index");
        }
    }
}
