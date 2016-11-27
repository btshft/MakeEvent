using System.Collections;
using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IEventService
    {
        OperationResult Create(EventDto @event);
        OperationResult<EventDto> Get(int id);
        OperationResult<IEnumerable<EventDto>> All();
    }
}
