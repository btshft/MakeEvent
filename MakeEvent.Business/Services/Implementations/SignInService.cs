using MakeEvent.Domain.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace MakeEvent.Business.Services.Implementations
{
    public class SignInService : SignInManager<ApplicationUser, string>
    {
        public SignInService(UserService userService, IAuthenticationManager authenticationManager)
            : base(userService, authenticationManager)
        { }

        public static SignInService Create(IdentityFactoryOptions<SignInService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<UserService>(), context.Authentication);
        }
    }
}
