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
    }
}
