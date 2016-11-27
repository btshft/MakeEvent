using System;
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

        public OperationResult Create(OrganizationDto organization)
        {
            if (organization == null)
                throw new ArgumentNullException(nameof(organization));

            if (organization.Id > 0)
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

                _repository.Create(domainOrg);
                _repository.Save();
            }

            return new OperationResult { Errors = result.Errors, Succeeded = result.Succeeded };
        }

        public OperationResult Update(OrganizationDto organization)
        {
            if (organization == null)
                throw new ArgumentNullException(nameof(organization));

            if (organization.Id < 1 || string.IsNullOrEmpty(organization.OwnerId))
                throw new ApplicationException("Произошла ошибка при обновлении организации");

            var owner = _repository.GetById<ApplicationUser>(organization.OwnerId);

            owner.Email = organization.Email;
            owner.PhoneNumber = organization.PhoneNumber;

            _repository.Update(owner);

            var domainOrg = _repository.GetById<Organization>(organization.Id);

            domainOrg.Owner = owner;
            domainOrg.Logo = organization.Logo;
            domainOrg.Website = organization.Website;

            _repository.Update(domainOrg);
            _repository.Save();

            return OperationResult.Success();
        }
    }
}
