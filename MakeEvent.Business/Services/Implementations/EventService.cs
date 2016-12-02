using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Filtering.Builder;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Filters;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;

namespace MakeEvent.Business.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IRepository _repository;
        private readonly IFilterBuilder<Event, EventFilter> _filterBuilder;

        public EventService(IRepository repository, IFilterBuilder<Event, EventFilter> filterBuilder)
        {
            _repository = repository;
            _filterBuilder = filterBuilder;
        }

        public OperationResult<EventDto> Save(EventDto @event)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

            var existed = _repository.GetById<Event>(@event.Id);
            var result = (existed != null)
                ? UpdateEvent(existed, @event)
                : CreateEvent(@event);

            return result;
        }

        public OperationResult<EventDto> Get(int id)
        {
            var @event = _repository.GetById<Event>(id);

            return @event == null
                ? OperationResult.Fail<EventDto>("Не удалось найти новость")
                : OperationResult.Success(Mapper.Map<EventDto>(@event));
        }

        public OperationResult<IEnumerable<EventDto>> All()
        {
            var events = _repository.All<Event>().ProjectTo<EventDto>();
            return OperationResult.Success(Mapper.Map<IEnumerable<EventDto>>(events));
        }

        public OperationResult<PaginatedResult<EventDto>> Filter(EventFilter filter)
        {
            var predicate = _filterBuilder.Build(filter);
            var query     = _repository.Get(predicate);
            var total     = query.Count();

            if (filter.IsPaged)
            {
                query = query
                    .OrderBy(c => c.Id)
                    .Skip(filter.Skip)
                    .Take(filter.Take);
            }

            var events = query.ProjectTo<EventDto>().ToList();
            var result = new PaginatedResult<EventDto>(events, total);

            return OperationResult.Success(result);
        }

        public OperationResult Delete(int id)
        {
            var exists = _repository.GetById<Event>(id);
            if (exists == null)
                return OperationResult.Fail($"Событие с id = {id} не найдено.");

            _repository.Delete<Event>(id);
            _repository.Save();

            return OperationResult.Success();
        }

        private OperationResult<EventDto> CreateEvent(EventDto @event)
        {
            var domain = Mapper.Map<Event>(@event);
            var result = _repository.Create(domain);
            
            _repository.Save();

            return OperationResult.Success(Mapper.Map<EventDto>(result));
        }

        private OperationResult<EventDto> UpdateEvent(Event domain, EventDto @event)
        {
            domain = Mapper.Map(@event, domain);
            domain = _repository.Update(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<EventDto>(domain));
        }
    }
}
