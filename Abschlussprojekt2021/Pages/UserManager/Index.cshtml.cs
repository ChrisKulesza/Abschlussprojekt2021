using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Linq;

namespace Abschlussprojekt2021.Pages.UserManager
{
    [Authorize(Roles = Constants.RoleAdmin)]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<ApplicationUser> _repositoryApplicationUser;
        //private readonly IRepository<AspNetUserRole> _repositoryUserRole;

        public List<ApplicationUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IRepository<ApplicationUser> repositoryApplicationUser)
            //IRepository<AspNetUserRole> repositoryUserRole)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _repositoryApplicationUser = repositoryApplicationUser;
            //_repositoryUserRole = repositoryUserRole;
            Users = _repositoryApplicationUser.GetAll();
            Roles = _context.Roles.ToList();

            // Info text later
            foreach (var user in Users)
            {
                if (_context.UserRoles.Where(u => u.UserId == user.Id).FirstOrDefault() == null)
                //if (_repositoryUserRole.GetByID(user.Id) == null)
                {
                    user.Role = "No role";
                }
                else
                {
                    string userRoleId = _context.UserRoles.Where(userRole => userRole.UserId == user.Id).FirstOrDefault().RoleId;

                    foreach (var role in Roles)
                    {
                        if (role.Id == userRoleId)
                        {
                            user.Role = role.Name;
                        }
                    }
                }
            }
        }

        // OnPost handler - Syncfusion UrlAdaptor | GetDbData
        public JsonResult OnPostDataSource([FromBody] DataManagerRequest dm)
        {
            var data = _repositoryApplicationUser.GetAll();

            int count = data.Cast<ApplicationUser>().Count();
            return dm.RequiresCounts ? new JsonResult(new { result = data.Skip(dm.Skip).Take(dm.Take), count = count }) : new JsonResult(data);
        }
    }
}
