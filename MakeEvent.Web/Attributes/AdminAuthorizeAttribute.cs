using System.Web.Mvc;
using System.Web.Routing;

namespace MakeEvent.Web.Attributes
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                return;

            var user = filterContext.HttpContext.User;
            if (user.Identity.IsAuthenticated || user.IsInRole("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Admin", action = "Login"}
                        ));
            }
        }
    }
}