using System.Security.Claims;
using System.Threading.Tasks;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Domain.Models;
using Microsoft.Owin.Security.OAuth;

namespace MakeEvent.Web.Providers
{
    public class SimpleAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var applicationUser = (ApplicationUser) null;
            using (var userService = Dependencies.Container.GetInstance<UserService>())
            {
                applicationUser = await userService.FindAsync(context.UserName, context.Password);
                if (applicationUser == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var roles   = string.Concat(",", applicationUser.Roles);

            identity.AddClaim(new Claim("email", applicationUser.Email));
            identity.AddClaim(new Claim("roles", roles));

            context.Validated(identity);
        }
    }
}