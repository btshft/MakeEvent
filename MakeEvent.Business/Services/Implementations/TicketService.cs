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

        public OperationResult<IList<TicketCategoryDto>> GetCategoriesByEvent(int eventId)
        {
            var categories = _repository
                .Get<TicketCategory>(c => c.EventId == eventId)
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

        public OperationResult<TicketDto> CreateTicket(TicketDto ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            if (ticket.CategoryId < 1)
                return OperationResult.Fail<TicketDto>("Необходимо указать категорию билета");

            var ticketCategory = _repository.GetById<TicketCategory>(ticket.CategoryId);

            if (ticketCategory == null)
                return OperationResult.Fail<TicketDto>($"Не удалось найти категорию билетов с Id = {ticket.Id}");

            if (ticketCategory.MaxCount == ticketCategory.BookedCount)
                return OperationResult.Fail<TicketDto>("Все билеты данного типа уже забронированы.");

            ticket.BookDate = DateTime.Now;
            ticketCategory.BookedCount = ticketCategory.BookedCount + 1;

            var domainTicket = Mapper.Map<Ticket>(ticket);

            domainTicket   = _repository.Create(domainTicket);
            ticketCategory = _repository.Update(ticketCategory);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<TicketDto>(domainTicket));
        }

        public OperationResult<IList<TicketDto>> AllTickets()
        {
            var tickets = _repository.Get<Ticket>()
                .ProjectTo<TicketDto>()
                .ToList();

            return OperationResult.Success<IList<TicketDto>>(tickets);
        }

        public OperationResult<IList<TicketDto>> GetTicketsByOrganization(string organizationId)
        {
            var tickets = _repository.Get<Ticket>(t => t.Category.Event.OrganizationId.Equals(organizationId))
                .ProjectTo<TicketDto>()
                .ToList();

            return OperationResult.Success<IList<TicketDto>>(tickets);
        }

        public OperationResult<TicketDto> GetTicket(int tickedId)
        {
            var ticket = _repository.GetById<Ticket>(tickedId);

            return (ticket == null)
                ? OperationResult.Fail<TicketDto>("Не удалось найти билет")
                : OperationResult.Success(Mapper.Map<TicketDto>(ticket));
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
