using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Filters;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IEventService
    {
        OperationResult<EventDto> Save(EventDto @event);
        OperationResult<EventDto> Get(int id);
        OperationResult<IEnumerable<EventDto>> All();
        OperationResult<PaginatedResult<EventDto>> Filter(EventFilter filter);
        OperationResult Delete(int id);
    }
}
