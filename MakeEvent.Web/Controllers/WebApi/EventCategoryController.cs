using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Kendo.Mvc.UI;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
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

        [HttpGet]
        [Route("api/eventcategory/all")]
        public DataSourceResult All()
        {
            return new DataSourceResult
            {
                Data = Mapper.Map<IEnumerable<EventCategoryViewModel>>(_eventCategoryService.All().Result)
            };
        }
    }
}