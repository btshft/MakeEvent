using System.Web.Http;
using System.Web.Http.Results;
using MakeEvent.Business;

namespace MakeEvent.Web.Controllers.WebApi
{
    public class SampleController : ApiController
    {
        private readonly SignInService _signInService;
        private readonly UserService _userService;

        public SampleController(SignInService signInService, UserService userService)
        {
            _signInService = signInService;
            _userService = userService;
        }

        [HttpGet]
        public JsonResult<string> Test()
        {
            return Json("It's fine");
        }
    }
}