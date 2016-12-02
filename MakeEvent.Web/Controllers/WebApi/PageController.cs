using System.Net;
using System.Net.Http;
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
    [HandleWebApiException]
    public class PageController : BaseApiController
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpPost]
        [Route("api/page/savelocalization")]
        public DataSourceResult SaveLocalization(PageLocalizationViewModel model)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var dto = Mapper.Map<PageLocalizationDto>(model);
            var result = _pageService.SaveLocalizations(model.PageName, dto);

            return new DataSourceResult { Errors = result.Errors };
        }

        [HttpGet]
        [Route("api/page/getlocalization")]
        public HttpResponseMessage GetLocalization(string pageName, int languageId)
        {
            var result = _pageService.GetLocalization(pageName, languageId);
            if (!result.Succeeded)
                return Request.CreateResponse(result.Errors);

            return Request.CreateResponse(HttpStatusCode.OK, 
                Mapper.Map<PageLocalizationViewModel>(result.Data));
        }
    }
}