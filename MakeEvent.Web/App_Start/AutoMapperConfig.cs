using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MakeEvent.Business.Enums;
using MakeEvent.Business.Models;
using MakeEvent.Domain.Models;
using MakeEvent.Web.App_LocalResources;
using MakeEvent.Web.Extensions;
using MakeEvent.Web.Helpers;
using MakeEvent.Web.Models.Admin;
using MakeEvent.Web.Models.Common;
using MakeEvent.Web.Models.Organization;

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

                cfg.CreateMap<OrganizationDto, OrganizationMvcViewModel>();
                cfg.CreateMap<OrganizationMvcViewModel, OrganizationDto>();
                cfg.CreateMap<OrganizationMvcViewModel, OrgWithCommentsMvcViewModel>();
                cfg.CreateMap<OrgWithCommentsMvcViewModel, OrganizationMvcViewModel>();
                
                cfg.CreateMap<Event, EventDto>();
                cfg.CreateMap<EventDto, Event>();

                cfg.CreateMap<EventDto, EventMvcViewModel>();
                cfg.CreateMap<EventMvcViewModel, EventDto>();

                cfg.CreateMap<EventDto, EventWithTicketsMvcViewModel>();

                cfg.CreateMap<EventCategory, EventCategoryDto>();
                cfg.CreateMap<EventCategoryDto, EventCategory>()
                    .ForMember(d => d.EventCategoryLocalizations, opt => opt.Ignore());

                cfg.CreateMap<EventCategoryDto, EventCategoryMvcViewModel>()
                    .AfterMap(TransformToModel)
                    .AfterMap(Localize);

                cfg.CreateMap<EventCategoryMvcViewModel, EventCategoryDto>()
                    .AfterMap(TransformToDto);

                cfg.CreateMap<EventCategoryLocalization, EventCategoryLocalizationDto>();
                cfg.CreateMap<EventCategoryLocalizationDto, EventCategoryLocalization>();

                cfg.CreateMap<News, NewsDto>();
                cfg.CreateMap<NewsDto, News>()
                    .ForMember(d => d.NewsLocalizations, opt => opt.Ignore());

                cfg.CreateMap<NewsDto, NewsMvcViewModel>()
                    .AfterMap(TransformToModel)
                    .AfterMap(Localize);

                cfg.CreateMap<NewsMvcViewModel, NewsDto>()
                    .AfterMap(TransformToDto);
                
                cfg.CreateMap<NewsLocalization,    NewsLocalizationDto>();
                cfg.CreateMap<NewsLocalizationDto, NewsLocalization>();

                cfg.CreateMap<PageLocalization,    PageLocalizationDto>();
                cfg.CreateMap<PageLocalizationDto, PageLocalization>();


                cfg.CreateMap<Page, PageDto>();
                cfg.CreateMap<PageDto, Page>();

                cfg.CreateMap<PageDto, PageMvcViewModel>()
                    .AfterMap(TransformToModel)
                    .AfterMap(Localize);

                cfg.CreateMap<Image, ImageDto>();
                cfg.CreateMap<ImageDto, Image>();

                cfg.CreateMap<HttpPostedFileBase, ImageDto>()
                    .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FileName))
                    .ForMember(d => d.MimeType, opt => opt.MapFrom(s => s.ContentType))
                    .ForMember(d => d.Content, opt => opt.MapFrom(s => s.InputStream.AsBytes()));

                cfg.CreateMap<Comment, CommentDto>();
                cfg.CreateMap<CommentDto, Comment>();
                cfg.CreateMap<CommentDto, CommentMvcViewModel>();
                cfg.CreateMap<CommentMvcViewModel, CommentDto>();

                cfg.CreateMap<TicketCategory, TicketCategoryDto>();
                cfg.CreateMap<TicketCategoryDto, TicketCategory>();
                cfg.CreateMap<TicketCategoryDto, TicketCategoryMvcViewModel>();
                cfg.CreateMap<TicketCategoryMvcViewModel, TicketCategoryDto>();

                cfg.CreateMap<Ticket, TicketDto>()
                    .AfterMap(TransformToDto);

                cfg.CreateMap<TicketDto, Ticket>();
                cfg.CreateMap<TicketDto, SoldTicketMvcViewModel>();
                cfg.CreateMap<SoldTicketMvcViewModel, TicketDto>();

                cfg.CreateMap<Service, ServiceDto>();
                cfg.CreateMap<ServiceDto, Service>();
                cfg.CreateMap<ServiceDto, ServiceMvcViewModel>()
                    .ForMember(d => d.OwnerId, opt => opt.MapFrom(s => s.OrganizationId));

                cfg.CreateMap<ServiceMvcViewModel, ServiceDto>()
                    .ForMember(d => d.OrganizationId, opt => opt.MapFrom(s => s.OwnerId));

                cfg.CreateMap<BookedService, BookedServiceDto>()
                    .AfterMap((s, d) =>
                    {
                        d.ServiceName = s.Service.Name;
                        d.Price = s.Service.Price;
                    });

                cfg.CreateMap<BookedServiceDto, BookedService>();
                cfg.CreateMap<BookedServiceDto, BookedServiceMvcViewModel>()
                    .ForMember(d => d.BookDate, opt => opt.MapFrom(s => s.BookedDate));

                cfg.CreateMap<BookedServiceMvcViewModel, BookedServiceDto>();
            });
        }

        private static void Localize(EventCategoryDto source, EventCategoryMvcViewModel destination)
        {
            var language = LanguageHelper.GetThreadLanguage();
            switch (language)
            {
                case CultureLanguage.EN:
                    destination.LocalizedName = source.EventCategoryLocalizations
                        .FirstOrDefault(c => c.LanguageId == 1)?.Name;
                    break;

                case CultureLanguage.Undefined:
                case CultureLanguage.RU:
                case null:
                default:
                    destination.LocalizedName = source.EventCategoryLocalizations
                        .FirstOrDefault(c => c.LanguageId == 2)?.Name;
                    break;
            }
        }

        private static void Localize(NewsDto source, NewsMvcViewModel destination)
        {
            var language = LanguageHelper.GetThreadLanguage();

            var ruLocalization = source.NewsLocalizations.FirstOrDefault(n => n.LanguageId == 2);
            var enLocalization = source.NewsLocalizations.FirstOrDefault(n => n.LanguageId == 1);

            switch (language)
            {
                case CultureLanguage.EN:
                    destination.LocalizedTitle = enLocalization?.Header;
                    destination.LocalizedShortDescription = enLocalization?.ShortDescription;
                    destination.LocalizedContent = enLocalization?.Content;
                    break;

                case CultureLanguage.Undefined:
                case CultureLanguage.RU:
                case null:
                default:
                    destination.LocalizedTitle = ruLocalization?.Header;
                    destination.LocalizedShortDescription = ruLocalization?.ShortDescription;
                    destination.LocalizedContent = ruLocalization?.Content;
                    break;
            }
        }

        private static void Localize(PageDto source, PageMvcViewModel destination)
        {
            var language = LanguageHelper.GetThreadLanguage();

            var ruLocalization = source.PageLocalizations.FirstOrDefault(n => n.LanguageId == 2);
            var enLocalization = source.PageLocalizations.FirstOrDefault(n => n.LanguageId == 1);

            switch (language)
            {
                case CultureLanguage.EN:
                    destination.LocalizedTitle = enLocalization?.Title;
                    destination.LocalizedContent = enLocalization?.Html;
                    break;

                case CultureLanguage.Undefined:
                case CultureLanguage.RU:
                case null:
                default:
                    destination.LocalizedTitle = ruLocalization?.Title;
                    destination.LocalizedContent = ruLocalization?.Html;
                    break;
            }
        }

        private static void TransformToModel(EventCategoryDto source, EventCategoryMvcViewModel destination)
        {
            var localizations = source.EventCategoryLocalizations;
            if (localizations == null || localizations.Count == 0)
                return;

            var ruLocalization = localizations.FirstOrDefault(c => c.LanguageId == (int)CultureLanguage.RU);
            var enLocalization = localizations.FirstOrDefault(c => c.LanguageId == (int)CultureLanguage.EN);

            destination.NameRu = ruLocalization?.Name;
            destination.NameEn = enLocalization?.Name;
        }

        private static void TransformToModel(NewsDto source, NewsMvcViewModel destination)
        {
            var localizations = source.NewsLocalizations;
            if (localizations == null || localizations.Count == 0)
                return;

            var ruLocalization = localizations.FirstOrDefault(c => c.LanguageId == (int)CultureLanguage.RU);
            var enLocalization = localizations.FirstOrDefault(c => c.LanguageId == (int)CultureLanguage.EN);

            destination.ContentEn = enLocalization?.Content;
            destination.ContentRu = ruLocalization?.Content;

            destination.ShortDescriptionEn = enLocalization?.ShortDescription;
            destination.ShortDescriptionRu = ruLocalization?.ShortDescription;

            destination.TitleEn = enLocalization?.Header;
            destination.TitleRu = ruLocalization?.Header;
        }

        private static void TransformToModel(PageDto source, PageMvcViewModel destination)
        {
            var localizations = source.PageLocalizations;
            if (localizations == null || localizations.Count == 0)
                return;

            var ruLocalization = localizations.FirstOrDefault(c => c.LanguageId == (int)CultureLanguage.RU);
            var enLocalization = localizations.FirstOrDefault(c => c.LanguageId == (int)CultureLanguage.EN);

            destination.ContentEn = enLocalization?.Html;
            destination.ContentRu = ruLocalization?.Html;

            destination.TitleEn = enLocalization?.Title;
            destination.TitleRu = ruLocalization?.Title;
        }

        private static void TransformToDto(EventCategoryMvcViewModel source, EventCategoryDto destination)
        {
            var enLocalization = string.IsNullOrEmpty(source.NameEn)
                ? null
                : new EventCategoryLocalizationDto
                {
                    EventCategoryId = source.Id,
                    LanguageId      = (int) CultureLanguage.EN,
                    Name            = source.NameEn
                };

            var ruLocalization = string.IsNullOrEmpty(source.NameRu)
                ? null
                : new EventCategoryLocalizationDto
                {
                    EventCategoryId = source.Id,
                    LanguageId      = (int) CultureLanguage.RU,
                    Name            = source.NameRu
                };

            var localizations = new List<EventCategoryLocalizationDto>();

            if (enLocalization != null)
                localizations.Add(enLocalization);

            if (ruLocalization != null)
                localizations.Add(ruLocalization);

            destination.EventCategoryLocalizations = (localizations.Count > 0)
                ? localizations
                : null;
        }

        private static void TransformToDto(NewsMvcViewModel source, NewsDto destination)
        {
            var enLocalization = string.IsNullOrEmpty(source.TitleEn)
                ? null
                : new NewsLocalizationDto
                {
                    NewsId = source.Id,
                    LanguageId = (int)CultureLanguage.EN,

                    Content = source.ContentEn,
                    ShortDescription = source.ShortDescriptionEn,
                    Header = source.TitleEn
                };

            var ruLocalization = string.IsNullOrEmpty(source.TitleRu)
                ? null
                : new NewsLocalizationDto
                {
                    NewsId = source.Id,
                    LanguageId = (int)CultureLanguage.RU,

                    Content = source.ContentRu,
                    ShortDescription = source.ShortDescriptionRu,
                    Header = source.TitleRu
                };

            var localizations = new List<NewsLocalizationDto>();

            if (enLocalization != null)
                localizations.Add(enLocalization);

            if (ruLocalization != null)
                localizations.Add(ruLocalization);

            destination.NewsLocalizations = (localizations.Count > 0)
                ? localizations
                : null;
        }

        private static void TransformToDto(Ticket source, TicketDto destination)
        {
            var bookedStatus =
                (LanguageHelper.GetThreadLanguage() == CultureLanguage.EN)
                    ? "Booked"
                    : "Забронирован";

            destination.EventTitle = source.Category.Event.Name;
            destination.Cost       = source.Category.Price;
            destination.Status     = (source.BookDate.HasValue) ? bookedStatus : string.Empty;
        }
    }
}