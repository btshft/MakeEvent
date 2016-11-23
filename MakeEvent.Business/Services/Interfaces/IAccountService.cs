using MakeEvent.Business.Models;
using MakeEvent.Common.Models;
using Microsoft.AspNet.Identity.Owin;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IAccountService
    {
        OperationResult RegisterOrganization(OrganizationDto organization);
        OperationResult<SignInStatus> Login(string userName, string password);
        OperationResult Logout();
    }
}
