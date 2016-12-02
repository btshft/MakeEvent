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

            var existed = _repository.GetById<Image>(image.Id);
            var result = (existed != null)
                ? UpdateImage(existed, image)
                : CreateImage(image);

            return result;
        }

        private OperationResult<ImageDto> CreateImage(ImageDto image)
        {
            var domain = Mapper.Map<Image>(image);
            var result = _repository.Create(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<ImageDto>(result));
        }

        private OperationResult<ImageDto> UpdateImage(Image domain, ImageDto image)
        {
            domain = Mapper.Map(image, domain);
            var result = _repository.Update(domain);

            _repository.Save();

            return OperationResult.Success(Mapper.Map<ImageDto>(result));
        }
    }
}
