using System.Web.Mvc;
using MakeEvent.Business.Services.Implementations.Identity;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Models;
using Microsoft.AspNet.Identity;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, HandleError]
    public class AdminController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserService _userService;

        public AdminController(IAuthorizationService authorizationService, UserService userService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }

        // GET: Admin
        public ActionResult Index(LoggedUserViewModel vm)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
                return RedirectToAction("Login");

            if (vm == null)
            {
                var user = _userService.FindById(User.Identity.GetUserId());
                var model = new LoggedUserViewModel
                {
                    Id         = user.Id,
                    FirstName  = user.FirstName,
                    LastName   = user.LastName,
                    MiddleName = user.MiddleName,
                    UserName   = user.UserName,
                    Role       = "Admin"
                };

                return View(model);
            }

            return View(vm);
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