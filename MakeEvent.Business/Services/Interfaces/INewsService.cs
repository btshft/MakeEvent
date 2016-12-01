using System.Collections;
using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface INewsService
    {
        OperationResult<NewsDto> Save(NewsDto news);
        OperationResult<NewsDto> Get(int newsId);
        OperationResult<IList<NewsDto>> All();
        OperationResult Delete(int newsId);
        OperationResult<NewsLocalizationDto> GetLocalization(int newsId, int languageId);
        OperationResult<NewsLocalizationDto> GetLocalization(int newsId, string languageShortCode);
    }
}
