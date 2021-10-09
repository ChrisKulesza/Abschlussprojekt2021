using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abschlussprojekt2021.Pages.UserManager
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _context = context;

            List<ApplicationUser> _Users;
            List<IdentityRole> _Roles;

            _Users = userManager.Users.ToList();
            _Roles = roleManager.Roles.ToList();
            
            _userManager = userManager;
        }

        public void OnGet()
        {

        }
    }
}
