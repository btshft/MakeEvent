using MakeEvent.Web.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            var models = new List<PageViewModel>();
            models.Add(new PageViewModel
            {
                Id = 0,
                Name = "Help",
                ContentEn = "Content",
                ContentRu = "Контент",
                TitleEn = "Help",
                TitleRu = "Помощь"
            });
            models.Add(new PageViewModel
            {
                Id = 1,
                Name = "About",
                ContentEn = "Content",
                ContentRu = "Контент",
                TitleEn = "About",
                TitleRu = "О нас"
            });
            return View(models);
        }

        // GET: Page/Details/5
        public ActionResult Details(int id)
        {
            var model = new PageViewModel
            {
                Id=0,
                Name="Help",
                ContentEn="Content",
                ContentRu="Контент",
                TitleEn="Help",
                TitleRu="Помощь"
            };
            return View(model);
        }

        // GET: Page/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Page/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Page/Edit/5
        public ActionResult Edit(int id)
        {

            var model = new PageViewModel
            {
                Id = 0,
                Name = "Help",
                ContentEn = "Content",
                ContentRu = "Контент",
                TitleEn = "Help",
                TitleRu = "Помощь"
            };
            return View(model);
        }

        // POST: Page/Edit/5
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

        // GET: Page/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new PageViewModel
            {
                Id = 0,
                Name = "Help",
                ContentEn = "Content",
                ContentRu = "Контент",
                TitleEn = "Help",
                TitleRu = "Помощь"
            };
            return View(model);
        }

        // POST: Page/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
