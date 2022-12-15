using Authentication.DataAccess.Interfaces;
using Authentication.DataAccess.Repositories;
using Authentication.Services.Interfaces;
using Authentication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication
{
    public class StartupHelper
    {
        public static void RegisterTypes(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }

    }
}