using System.Web.Mvc;
using MakeEvent.Business.Enums;
using MakeEvent.Web.Helpers;

namespace MakeEvent.Web.Controllers
{
    public class BaseController : Controller
    {
        protected CultureLanguage? ThreadLanguage 
            => LanguageHelper.GetThreadLanguage();

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}