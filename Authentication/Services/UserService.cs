using Authentication.DataAccess.Interfaces;
using Authentication.Entities;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(
            IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<IdentityUser> FindIdentityUserByName(string username)
        {
            return userRepository.FindIdentityUserByName(username);
        }

        public Task<User> Login(User user)
        {
            var registeredUser = userRepository.FindByUsername(user.Username);

            if (registeredUser != null)
            {
                return userRepository.Login(user);
            }
            else
            {
                throw new ApplicationException("Nombre de usuario o contraseña incorrecta.");
            }
        }

        public Task<bool> RegisterCompleteUser(User user)
        {
            user.Username = user.Username;
            user.Password = user.Password;

            if (FindIdentityUserByName(user.Username).Result != null)
            {
                throw new ApplicationException("No se puede registrar al usuario, el correo electronico ya está en uso");
            }
            else
            {
                var userCreated = userRepository.RegisterUser(user);

                return userCreated;
            }
        }
    }
}
