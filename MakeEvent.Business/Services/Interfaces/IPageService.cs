using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IPageService
    {
        OperationResult<IList<PageDto>> All();
        OperationResult<PageDto> Get(int pageId);
        OperationResult<PageDto> GetByName(string name);
        OperationResult<PageLocalizationDto> SaveLocalizations(string pageName, params PageLocalizationDto[] localizations);
        OperationResult<PageLocalizationDto> GetLocalization(string pageName, int languageId);
    }
}
