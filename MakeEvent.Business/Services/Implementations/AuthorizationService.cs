using System.Security.Claims;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace MakeEvent.Business.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserService   _userService;
        private readonly IAuthenticationManager _authenticationManager;

        public AuthorizationService(
            UserService userService,
            IAuthenticationManager authenticationManager)
        {
            _userService   = userService;
            _authenticationManager = authenticationManager;
        }

        public OperationResult<SignInStatus> Login(string userName, string password)
        {
            var user = _userService.Find(userName, password);
            if (user == null)
            {
                return OperationResult.Fail<SignInStatus>(
                    "Пользователь с указанными логином и паролем не найден");
            }

            var identity = _userService.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

            var signInProperties = new AuthenticationProperties { IsPersistent = true };

            _authenticationManager.SignIn(signInProperties, identity);

            return new OperationResult<SignInStatus>
            {
                Succeeded = true,
            };
        }

        public OperationResult Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return OperationResult.Success();
        }
    }
}
