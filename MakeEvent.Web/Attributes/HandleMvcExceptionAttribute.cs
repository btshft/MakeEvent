using System;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Attributes
{
    public class HandleMvcExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null)
            {

                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { Errors = filterContext.Exception.Message }
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();

                if (filterContext.Exception.GetType() == typeof(ApplicationException))
                {
                    filterContext.HttpContext.Response.StatusCode = 200;
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = new HttpException(null, filterContext.Exception).GetHttpCode();
                }

                // Certain versions of IIS will sometimes use their own error page when
                // they detect a server error. Setting this property indicates that we
                // want it to try to render ASP.NET MVC's error page instead.
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
}