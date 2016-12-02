using System;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Repository.Interfaces;

namespace MakeEvent.Business.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IRepository _repository;

        public ImageService(IRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<ImageDto> Get(int imageId)
        {
            var image = _repository.GetById<Image>(imageId);

            return image == null
                ? OperationResult.Fail<ImageDto>("Не удалось найти новость")
                : OperationResult.Success(Mapper.Map<ImageDto>(image));
        }

        public OperationResult<ImageDto> SaveImage(ImageDto image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            return (image.Id > 0)
                ? UpdateImage(image)
                : CreateImage(image);
        }

        private OperationResult<ImageDto> CreateImage(ImageDto image)
        {
            var domain = Mapper.Map<Image>(image);
            var result = _repository.Create(domain);

            return OperationResult.Success(Mapper.Map<ImageDto>(result));
        }

        private OperationResult<ImageDto> UpdateImage(ImageDto image)
        {
            var domain = _repository.GetById<Image>(image.Id);
            if (domain == null)
            {
                return OperationResult.Fail<ImageDto>
                    ($"Не удалось найти картинку (id = {image.Id})");
            }

            domain = Mapper.Map(image, domain);
            var result = _repository.Update(domain);

            return OperationResult.Success(Mapper.Map<ImageDto>(result));
        }
    }
}
