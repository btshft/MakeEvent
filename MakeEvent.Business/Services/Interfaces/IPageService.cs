using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IPageService
    {
        OperationResult<PageLocalizationDto> SaveLocalization(string pageName, PageLocalizationDto localization);
        OperationResult<PageLocalizationDto> GetLocalization(string pageName, int languageId);
    }
}
