using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using Kendo.Mvc.UI;

namespace MakeEvent.Web.Attributes
{
    public class HandleWebApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var errors = new DataSourceResult
                {
                    Errors = actionExecutedContext.Exception.Message
                };

                var response = new HttpResponseMessage
                {
                    Content = new ObjectContent<DataSourceResult>(errors,
                        new JsonMediaTypeFormatter()),
                    StatusCode = HttpStatusCode.OK
                };

                actionExecutedContext.Response = response;
            }
            else
            {
                base.OnException(actionExecutedContext);
            }
        }
    }
}