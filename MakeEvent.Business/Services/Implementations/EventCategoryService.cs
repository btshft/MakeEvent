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
    public class EventCategoryService : IEventCategoryService
    {
        private readonly IRepository _repository;

        public EventCategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<EventCategoryDto> Save(EventCategoryDto eventCategory)
        {
            if (eventCategory == null)
                throw new ArgumentNullException(nameof(eventCategory));

            var localizationResults
                = new List<OperationResult<EventCategoryLocalizationDto>>();

            var categoriesResult = (eventCategory.Id > 0)
                ? UpdateCategory(eventCategory)
                : CreateCategory(eventCategory);

            if (!categoriesResult.Succeeded)
                return categoriesResult;

            foreach (var localization in eventCategory.EventCategoryLocalizations)
            {
                localization.EventCategoryId = categoriesResult.Result.Id;

                var localizationResult = (localization.EventCategoryId > 0 && localization.LanguageId > 0)
                    ? UpdateLocalization(localization)
                    : CreateLocalization(localization);

                localizationResults.Add(localizationResult);
            }

            var errors = localizationResults
                .Where(c => c.Errors != null)
                .SelectMany(c => c.Errors)
                .ToArray();

            if (errors.Length > 0)
                return OperationResult.Fail<EventCategoryDto>(errors);

            _repository.Save();

            var result = categoriesResult.Result;

            result.EventCategoryLocalizations = localizationResults
                .Where(c => c.Result != null)
                .Select(c => c.Result)
                .ToList();

            return OperationResult.Success(result);
        }

        public OperationResult<IList<EventCategoryDto>> All()
        {
            var eventCategories = _repository.Get<EventCategory>()
                .ProjectTo<EventCategoryDto>()
                .ToList();

            return OperationResult.Success<IList<EventCategoryDto>>(eventCategories);
        }

        public OperationResult Delete(int eventCategoryId)
        {
            var exists = _repository.GetById<EventCategory>(eventCategoryId);
            if (exists == null)
                return OperationResult.Fail($"Категория с id = {eventCategoryId} не найдена.");

            var defaultCategory = _repository.Get<EventCategory>(c => c.IsDefault)
                .Single();

            if (defaultCategory.Id == eventCategoryId)
                return OperationResult.Fail($"Данная категория не может быть удалена.");

            var events = _repository.Get<Event>(e => e.CategoryId == eventCategoryId);
            foreach (var @event in events)
            {
                @event.CategoryId = defaultCategory.Id;
            }

            _repository.Delete<EventCategory>(eventCategoryId);
            _repository.Save();

            return OperationResult.Success();
        }

        public OperationResult<EventCategoryLocalizationDto> GetLocalization(int eventId, int languageId)
        {
            var domain = _repository.GetById<EventCategoryLocalization>(eventId, languageId);
            var result = Mapper.Map<EventCategoryLocalizationDto>(domain);

            return OperationResult.Success(result);
        }

        private OperationResult<EventCategoryDto> CreateCategory(EventCategoryDto category)
        {
            var domain = Mapper.Map<EventCategory>(category);
            var result = _repository.Create<EventCategory>(domain);

            return OperationResult.Success(Mapper.Map<EventCategoryDto>(result));
        }

        private OperationResult<EventCategoryDto> UpdateCategory(EventCategoryDto category)
        {
            var domain = _repository.GetById<EventCategory>(category.Id);
            if (domain == null)
            {
                return OperationResult.Fail<EventCategoryDto>
                    ($"Не удалось найти категорию (id = {category.Id})");
            }

            domain = Mapper.Map(category, domain);
            var result = _repository.Update(domain);

            return OperationResult.Success(Mapper.Map<EventCategoryDto>(result));
        }

        private OperationResult<EventCategoryLocalizationDto> CreateLocalization(EventCategoryLocalizationDto localization)
        {
            var domain = Mapper.Map<EventCategoryLocalization>(localization);
            var result = _repository.Create<EventCategoryLocalization>(domain);

            return OperationResult.Success(Mapper.Map<EventCategoryLocalizationDto>(result));
        }

        private OperationResult<EventCategoryLocalizationDto> UpdateLocalization(EventCategoryLocalizationDto localization)
        {
            var domain = _repository.GetById<EventCategoryLocalization>
                (localization.EventCategoryId, localization.LanguageId);

            if (domain == null)
            {
                return OperationResult.Fail<EventCategoryLocalizationDto>
                    ($"Не удалось найти локализацию (lang_id = {localization.LanguageId}, " +
                     $"event_category_id = { localization.EventCategoryId })");
            }

            domain = Mapper.Map(localization, domain);
            var result = _repository.Update(domain);

            return OperationResult.Success(Mapper.Map<EventCategoryLocalizationDto>(result));
        }
    }
}
