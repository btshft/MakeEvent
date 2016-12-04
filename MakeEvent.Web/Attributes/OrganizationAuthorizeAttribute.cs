using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace MakeEvent.Web.Attributes
{
    public class OrganizationAuthorizeAttribute : AuthorizeAttribute
    {
        public bool ValidateUserId = false;
        public string UserIdQueryParam = "id";

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                return;

            var user = filterContext.HttpContext.User;
            if (user.Identity.IsAuthenticated == false || user.IsInRole("Organization") == false)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Organization", action = "Login" }
                        ));
            }

            if (ValidateUserId)
            {
                var requestUserId = filterContext.RouteData.GetRequiredString(UserIdQueryParam);
                var userId = user.Identity.GetUserId();
                if (userId != requestUserId)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new { controller = "Organization", action = "Login" }
                            ));
                }
            }
        }
    }
}