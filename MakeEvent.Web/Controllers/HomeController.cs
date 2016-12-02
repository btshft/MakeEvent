using System;
using System.Web.Mvc;
using MakeEvent.Business.Enums;
using MakeEvent.Web.Models.Organization;
using System.Collections.Generic;
using AutoMapper;
using MakeEvent.Business.Services.Interfaces;
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

        public HomeController(IEventService eventService, INewsService newsService)
        {
            _eventService = eventService;
            _newsService  = newsService;
        }

        public ActionResult Index()
        {
            var events = _eventService.All().Data;
            var models = Mapper.Map<IEnumerable<EventMvcViewModel>>(events);

            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult News()
        {
            var news = _newsService.All().Data;
            var models = Mapper.Map<IEnumerable<NewsMvcViewModel>>(news);

            return View(models);
        }

        [HttpGet]
        public ActionResult News(int id)
        {
            var news = _newsService.Get(id);
            var model = Mapper.Map<NewsMvcViewModel>(news);

            return View("SingleNews", model);
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
        public ActionResult NewsList()
        {
            var models = new List<NewsMvcViewModel>();
            models.Add(new NewsMvcViewModel
            {
                Id = 0,
                LocalizedShortDescription = "Test",
                ImageData = null,
                LocalizedTitle = "Title"
            });
            models.Add(new NewsMvcViewModel
            {
                Id = 2,
                LocalizedShortDescription = "Test33",
                ImageData = null,
                LocalizedTitle = "Title333"
            });
            return View("News",models);
        }
        public ActionResult SingleNews(int id)
        {
            return View("SingleNews", new NewsMvcViewModel
            {
                Id = 2,
                LocalizedShortDescription="blabla bla",
                ImageData = null,
                LocalizedTitle = "Title333"
            });
        }
        public ActionResult OrganizationsList()
        {
            var models = new List<OrganizationMvcViewModel>();
            models.Add(new OrganizationMvcViewModel
            {
                Id = 2,
                Description = "test test",
                ImageData = null,
                City = "Sevastopol",
                Email = "foo@bar.com",
                Website = "http://test.com",
                Name = "test",
                Office = "23",
                Street = "Simonok",
                PhoneNumber = "+786738494"
            });
            models.Add(new
               OrganizationMvcViewModel
            {

                Id = 2,
                Description = "test test",
                ImageData = null,
                City = "Sevastopol",
                Email = "foo@bar.com",
                Website = "http://test.com",
                Name = "test",
                Office = "23",
                Street = "Simonok",
                PhoneNumber = "+786738494"
            });
            return View("Organizations",models);
        }
        public ActionResult Organization(int id)
        {
            var comments = new List<CommentMvcViewModel>();
            comments.Add(new CommentMvcViewModel
            {
                Id = 0,
                OrganizationId = "0",
                AuthorEmail = "foo@bar.com",
                CreatedDate = DateTime.Now,
                AuthorName = "Perov I.Y",
                Text = "Hello"
            });
            var comment = new CommentMvcViewModel
            {
                OrganizationId = "2",
            };
            var model = new Models.Common.OrgWithCommentsMvcViewModel
            {
                Id = "2",
                Description = "test test",
                ImageData = null,
                City = "Sevastopol",
                Email = "foo@bar.com",
                Website = "http://test.com",
                Name = "test",
                Office = "23",
                Street = "Simonok",
                PhoneNumber = "+786738494",
                Comments = comments,
                Comment=comment
            };
            return View("SingleOrg", model);
        }
        [HttpGet]
        public ActionResult EventsList()
        {
            var model = new EventAndCatMvcViewModel();
            var categories = new List<EventCategoryMvcViewModel>();
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 0,
                LocalizedName = "test"
            });
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 2,
                LocalizedName = "test2"
            });
            var events = new List<EventMvcViewModel>();
            events.Add(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
            events.Add(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
            model.Events = events;
            model.Categories = categories;
            return View("Events",model);
        }
        //Get by category
        [HttpPost]
        public ActionResult EventsList(int id)
        {
            var model = new EventAndCatMvcViewModel();
            var categories = new List<EventCategoryMvcViewModel>();
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 0,
                LocalizedName = "test"
            });
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 2,
                LocalizedName = "test2"
            });
            var events = new List<EventMvcViewModel>();
            events.Add(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
            events.Add(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
            model.Events = events;
            model.Categories = categories;
            return View("Events", model);
        }
        public ActionResult SingleEvent(int id)
        {
            var tickets = new List<TicketMvcViewModel>();
            tickets.Add(new TicketMvcViewModel
            {
                Id=0,
                MaxCount=12,
                Description="Vip",
                Price=200,
                TypeName="Vip"
            }); tickets.Add(new TicketMvcViewModel
            {
                Id = 0,
                MaxCount = 12,
                Description = "Vip",
                Price = 200,
                TypeName = "Vip"
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