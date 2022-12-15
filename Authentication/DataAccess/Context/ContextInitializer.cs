using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Authentication.DataAccess.Context
{
    public static class ContextInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            SeedRoles(roleManager, configuration);
            SeedUsers(userManager, configuration);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var roles = configuration["Roles"]?.Split(',');

            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = role
                    };

                    IdentityResult roleResult = roleManager.CreateAsync(identityRole).Result;
                }
            }
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            var roles = configuration["Roles"].Split(',');

            if (userManager.FindByIdAsync("1").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin",
                };

                IdentityResult result = userManager.CreateAsync(user, "Testing.123!").Result;

                if (result.Succeeded)
                {
                    foreach (var role in roles)
                    {
                        userManager.AddToRoleAsync(user, role).Wait();
                    }
                }
            }
        }
    }
}
