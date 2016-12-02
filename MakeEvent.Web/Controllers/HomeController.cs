using System;
using System.Web.Mvc;
using MakeEvent.Business.Enums;
using MakeEvent.Web.Models.Organization;
using System.Collections.Generic;
using MakeEvent.Web.Models.Admin;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var models = new List<EventMvcViewModel>();
            models.Add(new EventMvcViewModel
            {
                Id = 0,
                CategoryId = 1,
                City = "Sevastopol",
                Description = "test",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te",
                Name = "Event",
                Office = "12",
                Street = "Lenina",
                ImageData = null,
                ImageMimeType = ""
            });
            models.Add(new EventMvcViewModel
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
        public ActionResult News()
        {
            return View( new List<NewsMvcViewModel>());
        }
        public ActionResult News(int id)
        {
            return View("SingleNews", new NewsMvcViewModel());
        }
    }

}