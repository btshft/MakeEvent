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
    public class NewsService : INewsService
    {
        private readonly IRepository _repository;

        public NewsService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<NewsDto> Save(NewsDto news)
        {
            if (news == null)
                throw new ArgumentNullException(nameof(news));

            var localizationResults 
                = new List<OperationResult<NewsLocalizationDto>>();

            var newsResult = (news.Id > 0)
                ? UpdateNews(news) 
                : CreateNews(news);

            if (!newsResult.Succeeded)
                return newsResult;

            foreach (var localization in news.NewsLocalizations)
            {
                localization.NewsId = newsResult.Result.Id;

                var existed = _repository.GetById<NewsLocalization>(localization.NewsId, 
                    localization.LanguageId);

                var localizationResult = (existed != null)
                    ? UpdateLocalization(existed, localization)
                    : CreateLocalization(localization);

                localizationResults.Add(localizationResult);
            }

            var errors = localizationResults
                .Where(c => c.Errors != null)
                .SelectMany(c => c.Errors)
                .ToArray();

            if (errors.Length > 0)
                return OperationResult.Fail<NewsDto>(errors);

            var result = newsResult.Result;

            result.NewsLocalizations = localizationResults
                .Where(c => c.Result != null)
                .Select(c => c.Result)
                .ToList();

            return OperationResult.Success(result);
        }

        public OperationResult<NewsDto> Get(int newsId)
        {
            var news = _repository.GetById<News>(newsId);

            return news == null
                ? OperationResult.Fail<NewsDto>("Не удалось найти новость")
                : OperationResult.Success(Mapper.Map<NewsDto>(news));
        }

        public OperationResult<IList<NewsDto>> All()
        {
            var news = _repository.Get<News>()
                .ProjectTo<NewsDto>()
                .ToList();

            return OperationResult.Success<IList<NewsDto>>(news);
        }

        public OperationResult Delete(int newsId)
        {
            var exists = _repository.GetById<News>(newsId);
            if (exists == null)
                return OperationResult.Fail($"Новость с id = {newsId} не найдена.");

            _repository.Delete<News>(newsId);
            _repository.Save();

            return OperationResult.Success();
        }

        public OperationResult<NewsLocalizationDto> GetLocalization(int newsId, int languageId)
        {
            var domain = _repository.GetById<NewsLocalization>(newsId, languageId);
            var result = Mapper.Map<NewsLocalizationDto>(domain);

            return OperationResult.Success(result);
        }

        public OperationResult<NewsLocalizationDto> GetLocalization(int newsId, string languageShortCode)
        {
            var lng =
                _repository.First<Language>(
                    l => l.ShortName.Equals(languageShortCode, StringComparison.InvariantCultureIgnoreCase));

            var domain = _repository.Single<NewsLocalization>(l => l.NewsId == newsId && l.LanguageId == lng.Id);
            var result = Mapper.Map<NewsLocalizationDto>(domain);

            return OperationResult.Success(result);
        }

        private OperationResult<NewsDto> CreateNews(NewsDto news)
        {
            var domain = Mapper.Map<News>(news);
            var result = _repository.Create<News>(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<NewsDto>(result));
        }

        private OperationResult<NewsDto> UpdateNews(NewsDto news)
        {
            var domain = _repository.GetById<News>(news.Id);
            if (domain == null)
            {
                return OperationResult.Fail<NewsDto>
                    ($"Не удалось найти новость (id = {news.Id})");
            }

            domain = Mapper.Map(news, domain);
            var result = _repository.Update(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<NewsDto>(result));
        }

        private OperationResult<NewsLocalizationDto> CreateLocalization(NewsLocalizationDto localization)
        {
            var domain = Mapper.Map<NewsLocalization>(localization);
            var result = _repository.Create<NewsLocalization>(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<NewsLocalizationDto>(result));
        }

        private OperationResult<NewsLocalizationDto> UpdateLocalization(NewsLocalization domain, NewsLocalizationDto localization)
        {
            domain = Mapper.Map(localization, domain);
            var result = _repository.Update(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<NewsLocalizationDto>(result));
        }
    }
}
