using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Areas.Identity.Data
{
    // This class must be in the scope of Identity. Otherwise the roles are not persisted in the database.
    public class Roles
    {
        /// <summary>
        /// Creates the roles stored in the method and writes them to the database.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async Task createRoles(IServiceProvider serviceProvider)
        {
            try
            {
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                IdentityResult roleResult;
                // Adding admin role
                var roleCheck = await RoleManager.RoleExistsAsync(Constants.RoleAdmin);
                // checking if role already exists
                if (!roleCheck)
                {
                    // create the role and seed them to the database if not exist
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(Constants.RoleAdmin));
                }

                // Adding editor role
                roleCheck = await RoleManager.RoleExistsAsync(Constants.RoleEditor);
                // checking if role already exists
                if (!roleCheck)
                {
                    // create the role and seed them to the database if not exist
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(Constants.RoleEditor));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
