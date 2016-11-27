using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;

namespace MakeEvent.Business.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IRepository _repository;

        public EventService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(EventDto @event)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

            var domainEvent = Mapper.Map<Event>(@event);

            _repository.Create(domainEvent);

            return OperationResult.Success();
        }

        public OperationResult<EventDto> Get(int id)
        {
            return new OperationResult<EventDto>
            {
                Result = Mapper.Map<EventDto>(_repository.GetById<Event>(id))
            };
        }

        public OperationResult<IEnumerable<EventDto>> All()
        {
            return new OperationResult<IEnumerable<EventDto>>
            {
                Result = _repository.All<Event>().ProjectTo<EventDto>()
            };
        }
    }
}
