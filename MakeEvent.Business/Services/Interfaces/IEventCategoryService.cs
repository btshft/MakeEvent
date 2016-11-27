using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IEventCategoryService
    {
        OperationResult<EventCategoryDto> Get(int id);
        OperationResult<IEnumerable<EventCategoryDto>> All();
    }
}
