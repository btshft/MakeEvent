using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MakeEvent.Web.Controllers.WebApi
{
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage HtmlResponse(string content)
        {
            var response = new HttpResponseMessage
            {
                Content = new StringContent(content)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}