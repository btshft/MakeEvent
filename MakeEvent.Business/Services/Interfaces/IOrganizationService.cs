using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IOrganizationService
    {
        OperationResult Create(OrganizationDto organization);
        OperationResult Update(OrganizationDto organization);
    }
}
