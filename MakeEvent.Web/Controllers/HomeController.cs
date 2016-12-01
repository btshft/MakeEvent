using System;
using System.Web.Mvc;
using MakeEvent.Business.Enums;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
    }
}