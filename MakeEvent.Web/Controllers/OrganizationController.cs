using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeEvent.Web.Models.Organization;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Business.Services.Implementations.Identity;

namespace MakeEvent.Web.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserService _userService;

        public OrganizationController(IAuthorizationService authorizationService, UserService userService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }

        // GET: Organization
        public ActionResult Index(string orgId)
        {
            var model = new OrganizationMvcViewModel
            {
                Id = 0,
                Name = "Test",
                BillNumber = "123455322",
                City = "Sevastopol",
                Street = "Lenina",
                Office = "124",
                Website = "foo@bar.com",
                Description = "event event event",
                ImageData = null,
                ImageMimeType = ""
            };
            return View(model);
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {

            var model = new OrganizationMvcViewModel
            {
                Id = 0,
                Name = "Test",
                BillNumber = "123455322",
                City = "Sevastopol",
                Street = "Lenina",
                Office = "124",
                Website = "foo@bar.com",
                Description = "event event event",
                ImageData = null,
                ImageMimeType = ""
            };
            return View(model);
        }

        // POST: Organization/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public FileContentResult GetImage(int orgId)
        {
            //TODO: Подогнать под нашу модель
            //Game game = repository.Games
            //    .FirstOrDefault(g => g.GameId == gameId);

            //if (game != null)
            //{
            //    return File(game.ImageData, game.ImageMimeType);
            //}
            //else
            //{
            //    return null;
            //}
            return null;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public ActionResult Logoff()
        {
            _authorizationService.Logout();

            return RedirectToAction("Index","Home");
        }
    }
}
