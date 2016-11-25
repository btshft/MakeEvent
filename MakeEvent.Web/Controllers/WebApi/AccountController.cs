using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.UI;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Extensions;
using MakeEvent.Web.Models;

namespace MakeEvent.Web.Controllers.WebApi
{
    [RequireHttps, HandleWebApiException]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("api/account/registerorganization")]
        public DataSourceResult RegisterOrganization(OrganizationViewModel organization)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var organizationDto = Mapper.Map<OrganizationDto>(organization);
            var result = _accountService.RegisterOrganization(organizationDto);

            return new DataSourceResult { Errors = result.Errors };
        }

        [HttpPost]
        [Route("api/account/login")]
        public DataSourceResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var result = _accountService.Login(model.Email, model.Password);

            return new DataSourceResult { Errors = result.Errors };
        }

        [HttpPost]
        [Route("api/account/logout")]
        public DataSourceResult Logout()
        {
            _accountService.Logout();

            return new DataSourceResult();
        }
    }
}