using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public OperationResult<IList<PageDto>> All()
        {
            var pages = _repository.Get<Page>()
                .ProjectTo<PageDto>()
                .ToList();

            return OperationResult.Success<IList<PageDto>>(pages);
        }

        public OperationResult<PageDto> Get(int pageId)
        {
            var page = _repository.GetById<Page>(pageId);

            return page == null
                ? OperationResult.Fail<PageDto>("Не удалось найти новость")
                : OperationResult.Success(Mapper.Map<PageDto>(page));
        }

        public OperationResult<PageLocalizationDto> SaveLocalizations(string pageName, params PageLocalizationDto[] localizations)
        {
            var domaingPage =
                _repository.First<Page>(
                    p => p.Name.Equals(pageName, StringComparison.InvariantCultureIgnoreCase));

            if (domaingPage == null)
                return OperationResult.Fail<PageLocalizationDto>(
                    $"Страница с Name = {pageName} не найдена.");

            var results = new List<OperationResult<PageLocalizationDto>>();

            foreach (var localization in localizations)
            {
                localization.PageId = domaingPage.Id;

                var existedLocalization = _repository
                    .GetById<PageLocalization>(localization.PageId, localization.LanguageId);

                var result = (existedLocalization != null)
                    ? UpdatePageLocalization(localization, existedLocalization)
                    : CreatePageLocalization(localization);

                results.Add(result);
            }

            return new OperationResult<PageLocalizationDto>
            {
                Succeeded = results.All(r => r.Succeeded),
                Errors    = results.Where(r => r.Errors != null).SelectMany(r => r.Errors)  
            };
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

            _repository.Save();

            return OperationResult.Success(Mapper.Map<PageLocalizationDto>(result));
        }

        private OperationResult<PageLocalizationDto> UpdatePageLocalization(PageLocalizationDto localization, PageLocalization domainLocalization)
        {
            domainLocalization = Mapper.Map(localization, domainLocalization);
            var result = _repository.Update(domainLocalization);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<PageLocalizationDto>(result));
        }
    }
}
