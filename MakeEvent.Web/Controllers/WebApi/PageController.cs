using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Kendo.Mvc.UI;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Domain.Filters;
using MakeEvent.Web.Attributes;
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

        [HttpGet]
        [Route("api/pages/{name}")]
        public HttpResponseMessage GetPageByName(string name)
        {
            var pageDto = _pageService.Get(new PageFilter { PageName = name })
                .Single();

            var pageVm = Mapper.Map<PageViewModel>(pageDto);
            return HtmlResponse(pageVm.Html);
        }

        [HttpPost]
        [Route("api/updatepage")]
        public DataSourceResult UpdatePage(PageViewModel page)
        {
            if (ModelState.IsValid == false)
            {
                var errors = new DataSourceResult
                {
                    Errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                };
                return errors;
            }

            var dtoPage = Mapper.Map<PageDto>(page);
            var dtoResult = _pageService.Save(dtoPage);

            return new DataSourceResult
            {
                Data = new [] { Mapper.Map<PageViewModel>(dtoResult) },
                Total = 1
            };
        }
    }
}