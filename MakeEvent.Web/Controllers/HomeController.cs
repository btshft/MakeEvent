using System;
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
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        private readonly INewsService  _newsService;
        private readonly IOrganizationService _organizationService;
        private readonly ICommentService _commentService;
        private readonly IEventCategoryService _categoryService;

        public HomeController(
            IEventService eventService, 
            INewsService newsService,
            IOrganizationService organizationService,
            ICommentService commentService,
            IEventCategoryService categoryService)
        {
            _eventService = eventService;
            _newsService  = newsService;
            _organizationService = organizationService;
            _commentService = commentService;
            _categoryService = categoryService;
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

            if (Uri.IsWellFormedUriString(returnUrl, UriKind.RelativeOrAbsolute))
                return Redirect(returnUrl);

            return View("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var events = _eventService.All().Data;
            var models = Mapper.Map<IEnumerable<EventMvcViewModel>>(events);

            return View(models);
        }

        [HttpGet]
        public ActionResult News(int? id)
        {
            if (id.HasValue)
            {
                var singleNews = _newsService.Get(id.Value);
                var singleNewsModel = Mapper.Map<NewsMvcViewModel>(singleNews);

                return View("SingleNews", singleNewsModel);
            }

            var news = _newsService.All().Data;
            var models = Mapper.Map<IEnumerable<NewsMvcViewModel>>(news);

            return View(models);
        }

        [HttpGet]
        public ActionResult Organizations()
        {
            var organizations = _organizationService.All().Data;
            var models = Mapper.Map<IEnumerable<OrganizationMvcViewModel>>(organizations);
            
            return View(models);
        }

        [HttpGet]
        public ActionResult Organization(string id)
        {
            var organization = _organizationService.Get(id).Data;
            var organizationModel = Mapper.Map<OrganizationMvcViewModel>(organization);
            var comments = Mapper.Map<IEnumerable<CommentMvcViewModel>>(
                _commentService.GetByOrganization(id).Data);


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

            var eventsModel = Mapper.Map<IEnumerable<EventMvcViewModel>>(events);

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
            var tickets = new List<TicketCategoryMvcViewModel>();
            tickets.Add(new TicketCategoryMvcViewModel
            {
                Id=0,
                MaxCount=12,
                Description="Vip",
                Price=200,
                Type="Vip"
            }); tickets.Add(new TicketCategoryMvcViewModel
            {
                Id = 0,
                MaxCount = 12,
                Description = "Vip",
                Price = 200,
                Type = "Vip"
            });
            var ticket = new SoldTicketMvcViewModel
            {
                TicketTypeId = 12
            };
            var model = new EventWithTicketsMvcViewModel
            {
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                Tickets = tickets,
                Ticket=ticket
            };
            
            SelectList tick = new SelectList(tickets, "Id", "TypeName");
            ViewBag.TicketTypes = tick;
            return View("SingleEvent", model);
        }
    }

}