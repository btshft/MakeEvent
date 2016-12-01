using System.Threading;
using System.Web.Mvc;
using MakeEvent.Business.Enums;

namespace MakeEvent.Web.Controllers
{
    public class BaseController : Controller
    {
        protected CultureLanguage? ThreadLanguage 
            => GetThreadLanguage();

        private static CultureLanguage? GetThreadLanguage()
        {
            var language = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;
            switch (language.ToUpper())
            {
                case "RU": return CultureLanguage.RU;
                case "EN": return CultureLanguage.EN;
                default: return null;
            }
        }
    }
}