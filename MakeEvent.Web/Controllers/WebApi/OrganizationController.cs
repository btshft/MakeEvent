using System.Web.Http;
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

        public OrganizationController(IOrganizationService organizationService)
        {
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