using System.Collections.Generic;
using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IOrganizationService
    {
        OperationResult<OrganizationDto> Save(OrganizationDto organization);
        OperationResult<OrganizationDto> Get(string ownerId);
        OperationResult<IList<OrganizationDto>> All();
    }
}