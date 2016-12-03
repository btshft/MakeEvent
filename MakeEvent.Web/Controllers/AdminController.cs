using System.Web.Mvc;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, HandleError, AdminAuthorize]
    public class AdminController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AdminController(IAuthorizationService authorizationService, UserService userService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public ActionResult Index(LoggedUserViewModel vm)
        {
            return RedirectToAction("Index", "Category");
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
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

            var user = result.Data;

            var resultModel = new LoggedUserViewModel
            {
                Id         = user.Id,
                FirstName  = user.FirstName,
                LastName   = user.LastName,
                MiddleName = user.MiddleName,
                UserName   = user.UserName,
                Role       = "Admin"
            };

            return RedirectToAction("Index", "Admin", resultModel);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            _authorizationService.Logout();

            return RedirectToAction("Login");
        }
    }
}