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
    public class TicketService : ITicketService
    {
        private readonly IRepository _repository;

        public TicketService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<TicketCategoryDto> SaveCategory(TicketCategoryDto ticketCategory)
        {
            if (ticketCategory == null)
                throw new ArgumentNullException(nameof(ticketCategory));

            var existed = _repository.GetById<TicketCategory>(ticketCategory.Id);
            var result = (existed != null)
                ? UpdateTicketCategory(existed, ticketCategory)
                : CreateTicketCategory(ticketCategory);

            return result;
        }

        public OperationResult<IList<TicketCategoryDto>> AllCategories()
        {
            var categories = _repository.Get<TicketCategory>()
                .ProjectTo<TicketCategoryDto>()
                .ToList();

            return OperationResult.Success<IList<TicketCategoryDto>>(categories);
        }

        public OperationResult<IList<TicketCategoryDto>> GetCategoriesByOrganization(string organizationId)
        {
            var categories = _repository
                .Get<TicketCategory>(c => c.Event.Organization.OwnerId.Equals(organizationId))
                .ProjectTo<TicketCategoryDto>()
                .ToList();

            return OperationResult.Success<IList<TicketCategoryDto>>(categories); 
        }

        public OperationResult<TicketCategoryDto> GetCategory(int categoryId)
        {
            var category = _repository.GetById<TicketCategory>(categoryId);

            return (category == null)
                ? OperationResult.Fail<TicketCategoryDto>("Не удалось найти категорию билетов")
                : OperationResult.Success(Mapper.Map<TicketCategoryDto>(category));
        }

        public OperationResult DeleteCategory(int categoryId)
        {
            var exists = _repository.GetById<TicketCategory>(categoryId);
            if (exists == null)
                return OperationResult.Fail($"Категория билетов с id = {categoryId} не найдена.");

            _repository.Delete<TicketCategory>(categoryId);
            _repository.Save();

            return OperationResult.Success();
        }

        private OperationResult<TicketCategoryDto> CreateTicketCategory(TicketCategoryDto ticketCategory)
        {
            var domain = Mapper.Map<TicketCategory>(ticketCategory);
            var result = _repository.Create(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<TicketCategoryDto>(result));
        }

        private OperationResult<TicketCategoryDto> UpdateTicketCategory(TicketCategory domain, TicketCategoryDto ticketCategory)
        {
            domain = Mapper.Map(ticketCategory, domain);
            var result = _repository.Update(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<TicketCategoryDto>(result));
        }
    }
}
