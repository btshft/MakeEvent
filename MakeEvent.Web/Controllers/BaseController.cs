using System.Web.Mvc;
using MakeEvent.Business.Enums;
using MakeEvent.Web.Helpers;

namespace MakeEvent.Web.Controllers
{
    public class BaseController : Controller
    {
        protected CultureLanguage? ThreadLanguage 
            => LanguageHelper.GetThreadLanguage();
    }
}