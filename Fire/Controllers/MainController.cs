using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Fire.Controllers
{
    public class MainController : ControllerBase
    {
        public string Username => GetClaimValue(JwtRegisteredClaimNames.Sub);

        internal string GetClaimValue(string claimName)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity.AuthenticationType != null)
            {
                return identity.FindFirst(claimName).Value;
            }

            return null;
        }
    }
}
