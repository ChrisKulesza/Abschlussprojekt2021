using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Services
{
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
                var roleCheck = await RoleManager.RoleExistsAsync(Constants.Admin);
                // checking if role already exists
                if (!roleCheck)
                {
                    // create the role and seed them to the database if not exist
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(Constants.Admin));
                }

                // Adding editor role
                roleCheck = await RoleManager.RoleExistsAsync(Constants.Editor);
                // checking if role already exists
                if (!roleCheck)
                {
                    // create the role and seed them to the database if not exist
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(Constants.Editor));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
