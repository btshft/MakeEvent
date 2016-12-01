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
    public class EventCategoryController : BaseApiController
    {
        private readonly IEventCategoryService _eventCategoryService;

        public EventCategoryController(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        [HttpPost]
        [Route("api/eventcategory/save")]
        public DataSourceResult Save(EventCategoryViewModel model)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var dto = Mapper.Map<EventCategoryDto>(model);
            var result = _eventCategoryService.Save(dto);

            return new DataSourceResult { Errors = result.Errors };
        }

        [HttpGet]
        [Route("api/eventcategory/all")]
        public DataSourceResult All(CultureLanguage? defaultLanguage = null)
        {
            var models = _eventCategoryService.All().Result
                .Select(Mapper.Map<EventCategoryViewModel>).ToList();

            foreach (var category in models)
            {
                var culture = Thread.CurrentThread.CurrentCulture;
                var languageId = (defaultLanguage.HasValue && defaultLanguage.Value != CultureLanguage.Undefined)
                    ? (int)defaultLanguage.Value
                    : (culture.IetfLanguageTag.Equals("EN", StringComparison.InvariantCultureIgnoreCase))
                        ? (int)CultureLanguage.EN
                        : (int)CultureLanguage.RU;

                var localization = _eventCategoryService.GetLocalization(category.Id, languageId).Result;

                if (localization != null)
                {
                    category.DefaultName = localization.Name;
                }
                else if (category.EventCategoryLocalizations.Count > 0)
                {
                    var firstLocalization = category.EventCategoryLocalizations.First();
                    category.DefaultName = firstLocalization.Name;
                }
            }

            return new DataSourceResult { Data = models };
        }

        [HttpGet]
        [Route("api/eventcategory/getlocalization")]
        public HttpResponseMessage GetLocalization(int categoryId, int languageId)
        {
            var result = _eventCategoryService.GetLocalization(categoryId, languageId);
            if (!result.Succeeded)
                return Request.CreateResponse(result.Errors);

            return Request.CreateResponse(HttpStatusCode.OK,
                Mapper.Map<EventCategoryLocalizationViewModel>(result.Result));
        }

        [HttpDelete]
        [Route("api/eventcategory/delete")]
        public DataSourceResult Delete(int categoryId)
        {
            var result = _eventCategoryService.Delete(categoryId);
            return new DataSourceResult { Errors = result.Errors };
        }
    }
}