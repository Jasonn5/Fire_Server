using Authentication.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Interfaces
{
    public  interface IUserRepository
    {
        Task<bool> RegisterUser(User user);
        Task<User> Login(User user);
        Task<IdentityUser> FindIdentityUserByName(string username);
        Task<IList<string>> GetRoles(IdentityUser user);
        User FindByUsername(string username);
    }
}
