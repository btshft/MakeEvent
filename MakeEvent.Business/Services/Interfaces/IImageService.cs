using MakeEvent.Business.Models;
using MakeEvent.Common.Models;

namespace MakeEvent.Business.Services.Interfaces
{
    public interface IImageService
    {
        OperationResult<ImageDto> Get(int imageId);
        OperationResult<ImageDto> SaveImage(ImageDto image);
    }
}
