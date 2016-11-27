using System;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;

namespace MakeEvent.Business.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IRepository _repository;

        public PageService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<PageLocalizationDto> SaveLocalization(string pageName, PageLocalizationDto localization)
        {
            var domaingPage =
                _repository.First<Page>(
                    p => p.Name.Equals(pageName, StringComparison.InvariantCultureIgnoreCase));

            if (domaingPage == null)
                return OperationResult.Fail<PageLocalizationDto>(
                    $"Страница с Name = {pageName} не найдена.");

            localization.PageId = domaingPage.Id;

            var existedLocalization = _repository
                .GetById<PageLocalization>(localization.PageId, localization.LanguageId);

            var result = (existedLocalization != null)
                ? UpdatePageLocalization(localization, existedLocalization)
                : CreatePageLocalization(localization);

            _repository.Save();

            return result;
        }

        public OperationResult<PageLocalizationDto> GetLocalization(string pageName, int languageId)
        {
            var domaingPage =
                _repository.First<Page>(
                    p => p.Name.Equals(pageName, StringComparison.InvariantCultureIgnoreCase));

            if (domaingPage == null)
                return OperationResult.Fail<PageLocalizationDto>(
                    $"Страница с Name = {pageName} не найдена.");

            var domain = _repository.GetById<PageLocalization>(domaingPage.Id, languageId);
            var result = Mapper.Map<PageLocalizationDto>(domain);

            return OperationResult.Success(result);
        }

        private OperationResult<PageLocalizationDto> CreatePageLocalization(PageLocalizationDto localization)
        {
            var domainLocalization = Mapper.Map<PageLocalization>(localization);
            var result = _repository.Create(domainLocalization);
            return OperationResult.Success(Mapper.Map<PageLocalizationDto>(result));
        }

        private OperationResult<PageLocalizationDto> UpdatePageLocalization(PageLocalizationDto localization, PageLocalization domainLocalization)
        {
            domainLocalization = Mapper.Map(localization, domainLocalization);
            var result = _repository.Update(domainLocalization);

            return OperationResult.Success(Mapper.Map<PageLocalizationDto>(result));
        }
    }
}
