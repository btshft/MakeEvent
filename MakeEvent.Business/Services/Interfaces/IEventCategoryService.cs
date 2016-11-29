using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IEventCategoryService
    {
        OperationResult<EventCategoryDto> Save(EventCategoryDto eventCategory);
        OperationResult<IList<EventCategoryDto>> All();
        OperationResult Delete(int eventCategoryId);
        OperationResult<EventCategoryLocalizationDto> GetLocalization(int eventId, int languageId);
    }
}
