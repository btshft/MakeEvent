using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class ServiceService : IServiceService
    {
        private readonly IRepository _repository;

        public ServiceService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<ServiceDto> Save(ServiceDto service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            var existed = _repository.GetById<Service>(service.Id);
            var result = (existed != null)
                ? UpdateService(existed, service)
                : CreateService(service);

            return result;
        }

        public OperationResult<ServiceDto> Get(int id)
        {
            var service = _repository.GetById<Service>(id);

            return service == null
                ? OperationResult.Fail<ServiceDto>("Не удалось найти услугу")
                : OperationResult.Success(Mapper.Map<ServiceDto>(service));
        }

        public OperationResult<IEnumerable<ServiceDto>> All()
        {
            var services = _repository.All<Service>().ProjectTo<ServiceDto>();
            return OperationResult.Success(Mapper.Map<IEnumerable<ServiceDto>>(services));
        }

        public OperationResult<IEnumerable<ServiceDto>> GetByOrganizationId(string organizationId)
        {
            var services = _repository.Get<Service>(s => s.OrganizationId == organizationId).ProjectTo<ServiceDto>();
            return OperationResult.Success(Mapper.Map<IEnumerable<ServiceDto>>(services));
        }

        public OperationResult Delete(int id)
        {
            var exists = _repository.GetById<Service>(id);
            if (exists == null)
                return OperationResult.Fail($"Услуга с id = {id} не найдена.");

            _repository.Delete<Service>(id);
            _repository.Save();

            return OperationResult.Success();
        }

        public OperationResult<BookedServiceDto> GetBooked(int id)
        {
            var service = _repository.GetById<BookedService>(id);

            return service == null
                ? OperationResult.Fail<BookedServiceDto>("Не удалось найти услугу")
                : OperationResult.Success(Mapper.Map<BookedServiceDto>(service));
        }

        public OperationResult<IEnumerable<BookedServiceDto>> GetBookedByOrganizationId(string organizationId)
        {
            var services = _repository.Get<BookedService>(s => s.Service.OrganizationId == organizationId && s.BookedDate.HasValue)
                .ProjectTo<BookedServiceDto>();

            return OperationResult.Success(Mapper.Map<IEnumerable<BookedServiceDto>>(services));
        }

        public OperationResult<BookedServiceDto> BookService(BookedServiceDto service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            service.BookedDate = DateTime.Now;

            var domain = _repository.Create(Mapper.Map<BookedService>(service));

            _repository.Save();

            var ndomain = _repository.Get<BookedService>(r => r.Id == domain.Id)
                .Include(r => r.Service)
                .FirstOrDefault();

            return OperationResult.Success(Mapper.Map<BookedServiceDto>(ndomain));
        }

        private OperationResult<ServiceDto> CreateService(ServiceDto service)
        {
            var domain = Mapper.Map<Service>(service);
            var result = _repository.Create(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<ServiceDto>(result));
        }

        private OperationResult<ServiceDto> UpdateService(Service domain, ServiceDto service)
        {
            domain = Mapper.Map(service, domain);
            domain = _repository.Update(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<ServiceDto>(domain));
        }
    }
}
