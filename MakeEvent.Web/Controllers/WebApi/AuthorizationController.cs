using System.Net.Http;
using System.Web.Http;
using Kendo.Mvc.UI;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Extensions;
using MakeEvent.Web.Models;

namespace MakeEvent.Web.Controllers.WebApi
{
    [HandleWebApiException, Authorize]
    public class AuthorizationController : BaseApiController
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost, AllowAnonymous]
        [Route("api/authorization/loginorganization")]
        public DataSourceResult LoginOrganization(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return ModelState.ToDataSourceResult();

            var result = _authorizationService.Login(model.Email, model.Password);

            return !(result.Succeeded)
                ? new DataSourceResult { Errors = result.Errors } 
                : new DataSourceResult { };
        }
    }
}