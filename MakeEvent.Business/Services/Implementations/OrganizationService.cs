using System;
using System.Linq;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;
using Microsoft.AspNet.Identity;

namespace MakeEvent.Business.Services.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository _repository;
        private readonly UserService _userService;

        public OrganizationService(IRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public OperationResult<OrganizationDto> Save(OrganizationDto organization)
        {
            if (organization == null)
                throw new ArgumentNullException(nameof(organization));

            var result = (string.IsNullOrEmpty(organization.OwnerId))
                ? CreateOrganization(organization)
                : UpdateOrganization(organization);

            return result;
        }

        public OperationResult<OrganizationDto> Get(string ownerId)
        {
            if (string.IsNullOrEmpty(ownerId))
                return OperationResult.Fail<OrganizationDto>("Необходимо указать идентификатор организации");

            var domainOrg = _repository.GetById<Organization>(ownerId);
            return OperationResult.Success(Mapper.Map<OrganizationDto>(domainOrg));
        }

        private OperationResult<OrganizationDto> CreateOrganization(OrganizationDto organization)
        {
            if (!string.IsNullOrEmpty(organization.OwnerId))
                throw new ApplicationException("Произошла ошибка при регистрации организации");

            var user = new ApplicationUser
            {
                UserName = organization.Email,
                Email = organization.Email,
                PhoneNumber = organization.PhoneNumber,
            };

            var result = _userService.Create(user, organization.Password);

            if (result.Succeeded)
            {
                _userService.AddToRole(user.Id, "Organization");

                var domainOrg = Mapper.Map<Organization>(organization);
                domainOrg.Owner = user;

                domainOrg = _repository.Create(domainOrg);

                _repository.Save();

                var resultOrg = Mapper.Map<OrganizationDto>(domainOrg);

                return OperationResult.Success(resultOrg);
            }
            else
            {
                return OperationResult.Fail<OrganizationDto>(result.Errors.ToArray());
            }
        }

        private OperationResult<OrganizationDto> UpdateOrganization(OrganizationDto organization)
        {
            var owner = _repository.GetById<ApplicationUser>(organization.OwnerId);

            owner.Email = string.IsNullOrEmpty(organization.Email) 
                ? owner.Email : organization.Email;

            owner.PhoneNumber = string.IsNullOrEmpty(organization.PhoneNumber) 
                ? owner.PhoneNumber : organization.PhoneNumber;

            _repository.Update(owner);

            var domainOrg = _repository.GetById<Organization>(organization.OwnerId);

            domainOrg = Mapper.Map(organization, domainOrg);

            domainOrg = _repository.Update(domainOrg);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<OrganizationDto>(domainOrg));
        }
    }
}
