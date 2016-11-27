using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using AutoMapper;
using Kendo.Mvc.UI;
using MakeEvent.Business.Enums;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Extensions;
using MakeEvent.Web.Models;

namespace MakeEvent.Web.Controllers.WebApi
{
    [HandleWebApiException]
    public class NewsController : BaseApiController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        [Route("api/news/save")]
        public DataSourceResult Save(NewsViewModel model)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var dto = Mapper.Map<NewsDto>(model);
            var result = _newsService.Save(dto);

            return new DataSourceResult { Errors = result.Errors };
        }

        [HttpGet]
        [Route("api/news/all")]
        public DataSourceResult All(Language? defaultLanguage = null)
        {
            var models = _newsService.All().Result.Select(Mapper.Map<NewsViewModel>).ToList();
            foreach (var news in models)
            {
                var culture = Thread.CurrentThread.CurrentCulture;
                var languageId = (defaultLanguage.HasValue && defaultLanguage.Value != Language.Undefined)
                    ? (int) defaultLanguage.Value
                    : (culture.IetfLanguageTag.Equals("EN", StringComparison.InvariantCultureIgnoreCase))
                        ? (int) Language.EN
                        : (int) Language.RU;

                var localization = _newsService.GetLocalization(news.Id, languageId).Result;

                if (localization != null)
                {
                    news.DefaultDescription = localization.Description;
                    news.DefaultShortDescription = localization.ShortDescription;
                    news.DefaultHeader = localization.Header;
                } else if (news.NewsLocalizations.Count > 0)
                {
                    var firstLocalization = news.NewsLocalizations.First();
                    news.DefaultDescription = firstLocalization.Description;
                    news.DefaultShortDescription = firstLocalization.ShortDescription;
                    news.DefaultHeader = firstLocalization.Header;
                }
            }

            return new DataSourceResult { Data = models };
        }

        [HttpGet]
        [Route("api/news/getlocalization")]
        public HttpResponseMessage GetLocalization(int newsId, int languageId)
        {
            var result = _newsService.GetLocalization(newsId, languageId);
            if (!result.Succeeded)
                return Request.CreateResponse(result.Errors);

            return Request.CreateResponse(HttpStatusCode.OK, 
                Mapper.Map<NewsLocalizationViewModel>(result.Result));
        }

        [HttpDelete]
        [Route("api/news/delete")]
        public DataSourceResult Delete(int newsId)
        {
            var result = _newsService.Delete(newsId);
            return new DataSourceResult { Errors = result.Errors };
        }
    }
}