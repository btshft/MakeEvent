using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeEvent.Web.Models.Organization;

namespace MakeEvent.Web.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            var model = new OrganizationMvcViewModel();
            return View(model);
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new OrganizationMvcViewModel());
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
    }
}
