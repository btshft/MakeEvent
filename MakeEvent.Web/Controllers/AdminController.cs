using System.Web.Mvc;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Models;
using Microsoft.AspNet.Identity;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, HandleError]
    public class AdminController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AdminController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Неправильный логин или пароль");
                return View();
            }

            var result = _authorizationService.Login(model.Email, model.Password, "Admin");

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", string.Join("\n", result.Errors));
                return View();
            }

            var user = result.Result;

            var resultModel = new LoggedUserViewModel
            {
                Id = user.Id,
                FirstName  = user.FirstName,
                LastName   = user.LastName,
                MiddleName = user.MiddleName,
                UserName   = user.UserName,
                Role = "Admin"
            };

            return View("Index", resultModel);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            if (User.Identity.IsAuthenticated)
                _authorizationService.Logout();

            return View("Login");
        }
    }
}