﻿using System.Web.Http;
using AutoMapper;
using Kendo.Mvc.UI;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Extensions;

namespace MakeEvent.Web.Controllers.WebApi
{
    [HandleWebApiException]
    public class OrganizationController : BaseApiController
    {
        private readonly IOrganizationService _organizationService;
        private readonly IAuthorizationService _authorizationService;

        public OrganizationController(IOrganizationService organizationService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _organizationService = organizationService;
        }

        [HttpPost]
        [Route("api/organization/register")]
        public DataSourceResult Register(OrganizationDto organization)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var organizationDto = Mapper.Map<OrganizationDto>(organization);
            var result = _organizationService.Create(organizationDto);

            if (result.Succeeded)
            {
                _authorizationService.Login(organization.Email, organization.Password);
            }

            return new DataSourceResult { Errors = result.Errors };
        }

        [HttpPost]
        [Route("api/organization/update")]
        public DataSourceResult Update(OrganizationDto organization)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var organizationDto = Mapper.Map<OrganizationDto>(organization);
            var result = _organizationService.Update(organizationDto);

            return new DataSourceResult { Errors = result.Errors };
        }
    }
}