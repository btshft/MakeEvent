using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IServiceService
    {
        OperationResult<ServiceDto> Save(ServiceDto service);
        OperationResult<ServiceDto> Get(int id);
        OperationResult<IEnumerable<ServiceDto>> All();
        OperationResult<IEnumerable<ServiceDto>> GetByOrganizationId(string organizationId);
        OperationResult Delete(int id);

        OperationResult<BookedServiceDto> GetBooked(int id);
        OperationResult<IEnumerable<BookedServiceDto>> GetBookedByOrganizationId(string organizationId);
        OperationResult<BookedServiceDto> BookService(BookedServiceDto service);
    }
}
