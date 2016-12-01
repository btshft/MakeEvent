using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace MakeEvent.Web.Attributes
{
    public class LocalizedAttribute : ActionFilterAttribute
    {
        private const string DefaultLocalization = "ru";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod == "POST")
                return;

            var sessionLanguage = (string)filterContext.HttpContext?.Session["localization"];
            var routeLanguage   = (string)filterContext.RouteData.Values["localization"];

            if (string.IsNullOrEmpty(sessionLanguage) == false
                && string.IsNullOrEmpty(routeLanguage))
            {
                RedirectToSessionLanguage(filterContext);
                return;
            }

            var language = (string)filterContext.RouteData.Values["localization"]
                ?? (string)filterContext.HttpContext?.Session["localization"];

            if (language == null)
            {
                RedirectToBrowserLanguageOrDefault(filterContext);
                return;
            }

            try
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture =
                    new CultureInfo(language);
            }
            catch (Exception e)
            {
                throw new NotSupportedException($"Не удалось установить язык: {language}", e);
            }
        }

        private static void RedirectToSessionLanguage(ActionExecutingContext filterContext)
        {
            var sessionLanguage = (string)filterContext.HttpContext?.Session["localization"];

            string resultLanguage;
            switch (sessionLanguage.ToUpper())
            {
                case "EN":
                    resultLanguage = "en";
                    break;

                default:
                    resultLanguage = "ru";
                    break;
            }

            var routeValues = new
            {
                localization = resultLanguage,
                controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                action = filterContext.ActionDescriptor.ActionName,
                id = filterContext.RouteData.Values["id"]
            };

            filterContext.Result = new RedirectToRouteResult(
                "DefaultLocalized", new RouteValueDictionary(routeValues));

        }

        private static void RedirectToBrowserLanguageOrDefault(ActionExecutingContext filterContext)
        {
            var browserLanguages = filterContext.HttpContext.Request.UserLanguages;
            var redirectLanguage = browserLanguages
                ?.FirstOrDefault(l => l.Contains("ru") || l.Contains("en")) ?? DefaultLocalization;

            var routeValues = new
            {
                localization = redirectLanguage.Contains("ru") ? "ru" : "en",
                controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                action = filterContext.ActionDescriptor.ActionName,
                id = filterContext.RouteData.Values["id"]
            };

            filterContext.Result = new RedirectToRouteResult(
                "DefaultLocalized", new RouteValueDictionary(routeValues));
        }
    }
}