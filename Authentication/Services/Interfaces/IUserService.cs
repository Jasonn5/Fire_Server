using Authentication.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Authentication.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterCompleteUser(User user);
        Task<User> Login(User user);
        Task<IdentityUser> FindIdentityUserByName(string username);
    }
}
