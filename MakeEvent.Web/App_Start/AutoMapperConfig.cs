using System.Net;
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
                cfg.CreateMap<Organization, OrganizationDto>()
                    .AfterMap((source, dest) => dest.Email = source.Owner?.Email)
                    .AfterMap((source, dest) => dest.PhoneNumber = source.Owner?.PhoneNumber)
                    .AfterMap((source, dest) => dest.OwnerId = source.Owner.Id);

                cfg.CreateMap<OrganizationDto, Organization>();

                cfg.CreateMap<OrganizationViewModel, OrganizationDto>();
                cfg.CreateMap<OrganizationDto, OrganizationViewModel>();

                cfg.CreateMap<Event, EventDto>();
                cfg.CreateMap<EventDto, Event>();
                cfg.CreateMap<EventDto, EventViewModel>();
                cfg.CreateMap<EventViewModel, EventDto>();

                cfg.CreateMap<EventCategory, EventCategoryDto>();
                cfg.CreateMap<EventCategoryDto, EventCategory>()
                    .ForMember(d => d.EventCategoryLocalizations, opt => opt.Ignore());

                cfg.CreateMap<EventCategoryDto, EventCategoryViewModel>();
                cfg.CreateMap<EventCategoryViewModel, EventCategoryDto>();

                cfg.CreateMap<EventCategoryLocalization, EventCategoryLocalizationDto>();
                cfg.CreateMap<EventCategoryLocalizationDto, EventCategoryLocalization>();
                cfg.CreateMap<EventCategoryLocalizationDto, EventCategoryLocalizationViewModel>();
                cfg.CreateMap<EventCategoryLocalizationViewModel, EventCategoryLocalizationDto>();

                cfg.CreateMap<News, NewsDto>();
                cfg.CreateMap<NewsDto, News>()
                    .ForMember(d => d.NewsLocalizations, opt => opt.Ignore());

                cfg.CreateMap<NewsDto, NewsViewModel>();
                cfg.CreateMap<NewsViewModel, NewsDto>();

                cfg.CreateMap<NewsLocalization,    NewsLocalizationDto>();
                cfg.CreateMap<NewsLocalizationDto, NewsLocalization>();
                cfg.CreateMap<NewsLocalizationDto, NewsLocalizationViewModel>();
                cfg.CreateMap<NewsLocalizationViewModel, NewsLocalizationDto>();

                cfg.CreateMap<PageLocalization,    PageLocalizationDto>();
                cfg.CreateMap<PageLocalizationDto, PageLocalization>();
                cfg.CreateMap<PageLocalizationDto, PageLocalizationViewModel>()
                    .AfterMap((source, dest) => dest.Html = WebUtility.HtmlDecode(source.Html));

                cfg.CreateMap<PageLocalizationViewModel, PageLocalizationDto>()
                    .AfterMap((source, dest) => dest.Html = WebUtility.HtmlEncode(source.Html));

            });
        }
    }
}