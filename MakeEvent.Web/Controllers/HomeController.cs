using System;
using System.Web.Mvc;
using MakeEvent.Business.Enums;
using MakeEvent.Web.Models.Organization;
using System.Collections.Generic;
using AutoMapper;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Admin;

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

    }

}