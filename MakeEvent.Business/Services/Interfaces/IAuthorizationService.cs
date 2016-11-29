using MakeEvent.Business.Models;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using Microsoft.AspNet.Identity.Owin;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IAuthorizationService
    {
        OperationResult<ApplicationUser> Login(string userName, string password, params string[] acceptableRoles);
        OperationResult Logout();
    }
}

