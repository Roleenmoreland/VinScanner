using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace VinScanner.Data
{
    public static class Seed
    {
        /// <summary>
        /// Responsible for creating all the available roles 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //Adding customs roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Dealer", "User" };
            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                //Creating the roles and seeding them to the database
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

        }
    }
}
