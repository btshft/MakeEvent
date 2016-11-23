using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;

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
    }
}