using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Web.Models;

namespace MakeEvent.Web
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        { 
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Page, PageDto>();
                cfg.CreateMap<PageDto, Page>();
                cfg.CreateMap<PageDto, PageViewModel>();
                cfg.CreateMap<PageViewModel, PageDto>();
            });
        }
    }
}