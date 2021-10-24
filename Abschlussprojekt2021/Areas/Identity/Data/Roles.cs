using Domain.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Areas.Identity.Data
{
    /// <summary>
    /// Provides methods for creating roles for Identity.
    /// 
    /// @warning This class must be in the scope of Identity. Otherwise the roles are not persisted in the database.
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// Creates the contained (Admin, Editor) roles and persists them in the database.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            try
            {
                // dont know
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Variable for storing the test result as to whether the role already exists.
                IdentityResult roleResult;
                
                // Check whether the role editor already exists.
                var roleCheck = await RoleManager.RoleExistsAsync(Constants.RoleAdmin);
                // Case distinction whether the role exists in the database.
                if (!roleCheck)
                {
                    // create the role and seed them to the database if not exist
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(Constants.RoleAdmin));
                }

                // Check whether the role editor already exists.
                roleCheck = await RoleManager.RoleExistsAsync(Constants.RoleEditor);
                // Case distinction whether the role exists in the database.
                if (!roleCheck)
                {
                    // Create the role if it doesn't exist.
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
