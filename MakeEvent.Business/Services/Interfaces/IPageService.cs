using MakeEvent.Business.Models;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Filters;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IPageService
    {
        PageDto Save(PageDto page);
        PaginatedResult<PageDto> Get(PageFilter pageFilter);
        void DeletePage(int id);
    }
}
