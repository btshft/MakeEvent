using MakeEvent.Web.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var models = new List<CategoryViewModel>();
            models.Add(new CategoryViewModel
            {
                Id = 0,
                NameEn = "English",
                NameRu = "Русский"
            });
            models.Add(new CategoryViewModel
            {
                Id = 1,
                NameEn = "English1",
                NameRu = "Русский1"
            });
            return View(models);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var model = new CategoryViewModel
            {
                Id = 0,
                NameEn = "English",
                NameRu = "Русский"
            };
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new CategoryViewModel
            {
                Id = 0,
                NameEn = "English",
                NameRu = "Русский"
            };
            return View(model);
        }

        // POST: Category/Edit/5
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new CategoryViewModel
            {
                Id = 0,
                NameEn = "English",
                NameRu = "Русский"
            };
            return View(model);
        }

        // POST: Category/Delete/5
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
