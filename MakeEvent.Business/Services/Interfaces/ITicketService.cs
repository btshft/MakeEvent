using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface ITicketService
    {
        OperationResult<TicketCategoryDto> SaveCategory(TicketCategoryDto ticketCategory);
        OperationResult<IList<TicketCategoryDto>> AllCategories();
        OperationResult<IList<TicketCategoryDto>> GetCategoriesByOrganization(string organizationId);
        OperationResult<TicketCategoryDto> GetCategory(int categoryId);
        OperationResult DeleteCategory(int categoryId);
    }
}
