using System.Linq;
using System.Security.Claims;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace MakeEvent.Business.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserService   _userService;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IRepository _repository;

        public AuthorizationService(
            UserService userService,
            IAuthenticationManager authenticationManager,
            IRepository repository)
        {
            _userService  = userService;
            _authenticationManager = authenticationManager;
            _repository = repository;
        }

        public OperationResult<ApplicationUser> Login(string userName, string password, params string[] acceptableRoles)
        {
            var user = _userService.Find(userName, password);
            if (user == null)
            {
                return OperationResult.Fail<ApplicationUser>(
                    "Пользователь с указанными логином и паролем не найден");
            }

            if (acceptableRoles != null && acceptableRoles.Length > 0)
            {
                var userToUserRoles = _repository
                    .Get<IdentityUserRole>(ur => ur.UserId == user.Id)
                    .AsEnumerable();

                var userRoles = _repository
                    .Get<IdentityRole>(r => userToUserRoles.Any(ur => ur.RoleId == r.Id))
                    .AsEnumerable();

                var isAcceptableRole = userRoles.Any(r => acceptableRoles.Contains(r.Name));

                if (!isAcceptableRole)
                {
                    return OperationResult.Fail<ApplicationUser>(
                        $"Пользователь не содержит ни одну из ролей: {string.Join(", ", acceptableRoles)}");
                }
            }

            var identity = _userService.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            identity.AddClaim(new Claim(ClaimTypes.Role, string.Join(",", user.Roles)));

            var signInProperties = new AuthenticationProperties { IsPersistent = true };

            _authenticationManager.SignIn(signInProperties, identity);

            return new OperationResult<ApplicationUser>
            {
                Succeeded = true,
                Result = user
            };
        }

        public OperationResult Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return OperationResult.Success();
        }
    }
}
