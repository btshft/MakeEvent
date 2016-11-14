using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Filtering.Builder;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Filters;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;

namespace MakeEvent.Business.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IRepository _repository;
        private readonly IFilterBuilder<Page, PageFilter> _filterBuilder;

        public PageService(IRepository repository, IFilterBuilder<Page, PageFilter> filterBuilder)
        {
            _repository = repository;
            _filterBuilder = filterBuilder;
        }

        public PageDto Save(PageDto page)
        {
            if (page == null)
                throw new ArgumentNullException(nameof(page));

            PageDto result;

            if (page.Id > 0)
            {
                var existingPage = _repository.Single<Page>(p => p.Id == page.Id);
                if (existingPage == null)
                    throw new ApplicationException("Страница не найдена.");

                existingPage = Mapper.Map(page, existingPage);
                result = Mapper.Map<PageDto>(_repository.Update(existingPage));
            }
            else
            {
                var domainPage = Mapper.Map<Page>(page);
                result = Mapper.Map<PageDto>(_repository.Create(domainPage));
            }

            _repository.Save();

            return result;
        }

        public PaginatedResult<PageDto> Get(PageFilter filter)
        {
            var predicate = _filterBuilder.Build(filter);
            var query = _repository.Get<Page>(predicate);
            var totalRow = query.Count();

            if (filter.IsPaged)
            {
                query = query
                    .OrderBy(c => c.Name)
                    .Skip(filter.Skip)
                    .Take(filter.Take);
            }

            return new PaginatedResult<PageDto>(query.ProjectTo<PageDto>().ToList(), totalRow);
        }

        public void DeletePage(int id)
        {
            var existingPage = _repository.GetById<Page>(id);
            if (existingPage == null)
                return;

            _repository.Delete(existingPage);
            _repository.Save();
        }
    }
}
