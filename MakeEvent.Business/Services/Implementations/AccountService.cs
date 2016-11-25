using System;
using System.Collections.Generic;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace MakeEvent.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;
        private readonly UserService _userService;
        private readonly SignInService _signInService;
        private readonly IAuthenticationManager _authenticationManager;

        public AccountService(
            IRepository repository, 
            UserService userService,
            SignInService signInService,
            IAuthenticationManager authenticationManager)
        {
            _repository    = repository;
            _userService   = userService;
            _signInService = signInService;
            _authenticationManager = authenticationManager;
        }

        public OperationResult RegisterOrganization(OrganizationDto organization)
        {
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

        public OperationResult<SignInStatus> Login(string userName, string password)
        {
            var result = _signInService
                .PasswordSignIn(userName, password, isPersistent: false, shouldLockout: false);

            return new OperationResult<SignInStatus>
            {
                Result = result,
                Succeeded = result == SignInStatus.Success,
                Errors = (result == SignInStatus.Success)
                    ? null : new List<string> { $"Ошибка при входе. Причина: {result}"} 
            };
        }

        public OperationResult Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return OperationResult.Success();
        }
    }
}
