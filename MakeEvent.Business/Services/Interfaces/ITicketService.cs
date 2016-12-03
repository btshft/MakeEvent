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
        OperationResult<IList<TicketCategoryDto>> GetCategoriesByEvent(int eventId);
        OperationResult<TicketCategoryDto> GetCategory(int categoryId);
        OperationResult DeleteCategory(int categoryId);

        OperationResult<TicketDto> CreateTicket(TicketDto ticket);
        OperationResult<IList<TicketDto>> AllTickets();
        OperationResult<IList<TicketDto>> GetTicketsByOrganization(string organizationId);
        OperationResult<TicketDto> GetTicket(int tickedId);
    }
}
