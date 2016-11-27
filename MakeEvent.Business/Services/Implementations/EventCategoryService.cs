using System.Collections.Generic;
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

        public OperationResult<EventCategoryDto> Get(int id)
        {
            return new OperationResult<EventCategoryDto>
            {
                Result = Mapper.Map<EventCategoryDto>(_repository.GetById<EventCategory>(id))
            };
        }

        public OperationResult<IEnumerable<EventCategoryDto>> All()
        {
            return new OperationResult<IEnumerable<EventCategoryDto>>
            {
                Result = _repository.All<EventCategory>().ProjectTo<EventCategoryDto>()
            };
        }
    }
}
