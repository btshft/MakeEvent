using System.Web.Mvc;
using MakeEvent.Business.Enums;
using MakeEvent.Web.Models.Organization;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Domain.Filters;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Admin;
using MakeEvent.Web.Models.Common;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, Localized]
    public class HomeController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly INewsService  _newsService;
        private readonly IOrganizationService _organizationService;
        private readonly ICommentService _commentService;
        private readonly IEventCategoryService _categoryService;
        private readonly ITicketService _ticketService;
        private readonly IImageService _imageService;

        public HomeController(
            IEventService eventService, 
            INewsService newsService,
            IOrganizationService organizationService,
            ICommentService commentService,
            IEventCategoryService categoryService,
            ITicketService ticketService, 
            IImageService imageService)
        {
            _eventService = eventService;
            _newsService  = newsService;
            _organizationService = organizationService;
            _commentService = commentService;
            _categoryService = categoryService;
            _ticketService = ticketService;
            _imageService = imageService;
        }

        [HttpPost]
        public ActionResult SetLanguage(CultureLanguage language, string returnUrl)
        {
            switch (language)
            {
                case CultureLanguage.EN:
                    Session["localization"] = "EN";
                    break;

                default:
                    Session["localization"] = "RU";
                    break;
            }

            return RedirectToLocal(returnUrl);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var events = _eventService.All().Data;
            var models = Mapper.Map<IEnumerable<EventMvcViewModel>>(events);

            foreach (var model in models.Where(o => o.ImageId > 0))
            {
                var image = _imageService.Get(model.ImageId.Value).Data;
                model.ImageData = image.Content;
                model.ImageMimeType = image.MimeType;
            }

            return View(models);
        }

        [HttpGet]
        public ActionResult News(int? id)
        {
            if (id.HasValue)
            {
                var singleNews = _newsService.Get(id.Value).Data;
                var singleNewsModel = Mapper.Map<NewsMvcViewModel>(singleNews);
                if (singleNewsModel != null && singleNewsModel.ImageId > 0)
                {
                    var image = _imageService.Get(singleNewsModel.ImageId.Value).Data;
                    singleNewsModel.ImageData = image.Content;
                    singleNewsModel.ImageMimeType = image.MimeType;
                }

                return View("SingleNews", singleNewsModel);
            }

            var news = _newsService.All().Data;
            var models = Mapper.Map<IEnumerable<NewsMvcViewModel>>(news);

            foreach (var model in models.Where(o => o.ImageId > 0))
            {
                var image = _imageService.Get(model.ImageId.Value).Data;
                model.ImageData = image.Content;
                model.ImageMimeType = image.MimeType;
            }

            return View(models);
        }

        [HttpGet]
        public ActionResult Organizations()
        {
            var organizations = _organizationService.All().Data;
            var models = Mapper.Map<IEnumerable<OrganizationMvcViewModel>>(organizations);

            foreach (var model in models.Where(o => o.ImageId > 0))
            {
                var image = _imageService.Get(model.ImageId.Value).Data;
                model.ImageData = image.Content;
                model.ImageMimeType = image.MimeType;
            }

            return View(models);
        }

        [HttpGet]
        public ActionResult Organization(string id)
        {
            var organization = _organizationService.Get(id).Data;
            var organizationModel = Mapper.Map<OrganizationMvcViewModel>(organization);
            var comments = Mapper.Map<IEnumerable<CommentMvcViewModel>>(
                _commentService.GetByOrganization(id).Data);

            if (organizationModel != null && organizationModel.ImageId > 0)
            {
                var image = _imageService.Get(organizationModel.ImageId.Value).Data;
                organizationModel.ImageData = image.Content;
                organizationModel.ImageMimeType = image.MimeType;
            }

            var orgWithCommendModel = Mapper.Map<OrgWithCommentsMvcViewModel>(organizationModel);
            orgWithCommendModel.Comment = new CommentMvcViewModel
            {
                OrganizationId = id,
            };
            orgWithCommendModel.Comments = comments.ToList();

            return View("SingleOrg", orgWithCommendModel);
        }

        [HttpGet]
        public ActionResult Events(int? id)
        {
            var categories = _categoryService.All().Data;
            var categoriesModel = Mapper.Map<IEnumerable<EventCategoryMvcViewModel>>(categories);

            var filter = (id.HasValue) ? new EventFilter { CategoryId = id } : null;
            var events = (filter == null) 
                 ? _eventService.All().Data
                 : _eventService.Filter(filter).Data.Items;

            var eventsModel = Mapper.Map<IEnumerable<EventMvcViewModel>>(events).ToList();

            foreach (var model in eventsModel.Where(o => o.ImageId > 0))
            {
                var image = _imageService.Get(model.ImageId.Value).Data;
                model.ImageData = image.Content;
                model.ImageMimeType = image.MimeType;
            }

            var composedModel = new EventAndCatMvcViewModel
            {
                Events = eventsModel.ToList(),
                Categories = categoriesModel.ToList()
            };

            return View(composedModel);
        }

        [HttpGet]
        public ActionResult Event(int id)
        {
            var categories = _ticketService.GetCategoriesByEvent(id).Data;
            var categoriesModel = Mapper.Map<IEnumerable<TicketCategoryMvcViewModel>>(categories).ToList();
            var categoriesList = (categoriesModel.Count > 0)
                ? new SelectList(categoriesModel, "Id", "Type")
                : null;

            ViewBag.EventId = id;
            ViewBag.TicketTypes = categoriesList;

            var @event = _eventService.Get(id).Data;
            var ticketModel = new SoldTicketMvcViewModel();

            if (categoriesModel.Count > 0)
                ticketModel.Cost = categoriesModel.First().Price;

            var composedModel = Mapper.Map<EventWithTicketsMvcViewModel>(@event);

            if (composedModel != null && composedModel.ImageId > 0)
            {
                var image = _imageService.Get(composedModel.ImageId.Value).Data;
                composedModel.ImageData = image.Content;
                composedModel.ImageMimeType = image.MimeType;
            }
            else if (composedModel != null)
            {
                composedModel.Ticket = ticketModel;
                composedModel.Tickets = categoriesModel;
            }

            return View("SingleEvent", composedModel);
        }
        [HttpGet]
        public ActionResult Services()
        {
            var models = new List<ServiceMvcViewModel>();
            models.Add(new ServiceMvcViewModel
            {
                Id = 0,
                OwnerId = "hfdhhfdhf",
                Name = "First Service",
                Description = "tratatatata",
                Price = 10000
            });
            models.Add(new ServiceMvcViewModel
            {
                Id = 1,
                OwnerId = "hfdhhfdhf",
                Name = "Second Service",
                Description = "second tratatatata",
                Price = 10
            });
            return View("Services", models);
        }
        [HttpGet]
        public ActionResult Service(int id)
        {
            return View("SingleService", new BookedServiceMvcViewModel
            {
                Id = 0,
                ServiceId = 0,
                ServiceName = "Test service",
                Price = 1000
            });
        }
    }

}