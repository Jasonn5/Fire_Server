using Authentication.DataAccess.Interfaces;
using Authentication.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IdentityDbContext context;
        public UserRepository(
            IConfiguration configuration,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IdentityDbContext context)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.context = context;
        }

        public User FindByUsername(string username)
        {
            return context.Set<User>().SingleOrDefault(u => u.Username == username);
        }

        public async Task<IdentityUser> FindIdentityUserByName(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<IList<string>> GetRoles(IdentityUser user)
        {
            var roles = userManager.GetRolesAsync(user);

            return await roles;
        }

        public async Task<User> Login(User user)
        {
            var result = await signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
            var identityUser = await FindIdentityUserByName(user.Username);

            if (result.Succeeded)
            {
                var appUser = userManager.Users.SingleOrDefault(r => r.UserName == user.Username);
                var userToClaim = FindByUsername(user.Username);
                user.Token = await GenerateJwtToken(userToClaim, appUser);
                await userManager.ResetAccessFailedCountAsync(identityUser);

                return user;
            }
            else
            {
                if (userManager.IsLockedOutAsync(identityUser).Result)
                {
                    var lockoutEndDateOffset = await userManager.GetLockoutEndDateAsync(identityUser);
                    DateTime lockoutEndDate = Convert.ToDateTime(lockoutEndDateOffset.ToString());
                    DateTime currentDate = DateTime.Now;
                    TimeSpan lockoutEndtime = (lockoutEndDate - currentDate);

                    throw new ApplicationException("Cuenta bloqueada temporalmente, intente nuevamente en " + ((int)lockoutEndtime.TotalMinutes + 1) + " minutos.");
                }
                else
                {
                    await userManager.AccessFailedAsync(identityUser);

                    throw new ApplicationException("Nombre de usuario o contraseña incorrecta.");
                }
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            var newUser = new IdentityUser
            {
                UserName = user.Username
            };

            var result = await userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                context.Set<User>().Add(user);
                context.SaveChanges();
                 
                if (user.Roles != null)
                {
                    foreach (var role in user.Roles)
                    {
                        await userManager.AddToRoleAsync(newUser, role.Name);
                    }
                }
            }

            return result.Succeeded;
        }

        private async Task<string> GenerateJwtToken(User user, IdentityUser identityUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
                new Claim("user_id", user.Id.ToString()),
            };

            var roles = GetRoles(identityUser);

            foreach (var role in roles.Result)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(configuration["JwtExpireMinutes"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
