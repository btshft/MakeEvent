using System.Collections.Generic;
using System.Web.Http;
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
    public class EventController : BaseApiController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
       
        [HttpPost]
        [Route("api/event/create")]
        public DataSourceResult Create(EventViewModel @event)
        {
            if (ModelState.IsValid == false)
                return ModelState.ToDataSourceResult();

            var eventDto = Mapper.Map<EventDto>(@event);
            var result = _eventService.Save(eventDto);

            return new DataSourceResult { Errors = result.Errors };
        }

        [HttpGet]
        [Route("api/event/all")]
        public DataSourceResult All()
        {
            return new DataSourceResult
            {
                Data = Mapper.Map<IEnumerable<EventViewModel>>(_eventService.All().Data)
            };
        }
    }
}