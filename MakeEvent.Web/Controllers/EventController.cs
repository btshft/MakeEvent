using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Models.Admin;
using MakeEvent.Web.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index(int? orgId)
        {
            var models = new List<EventMvcViewModel>();
            models.Add(new EventMvcViewModel
            {
                Id = 0,
                CategoryId = 1,
                City = "Sevastopol",
                Description = "test",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te",
                Name = "Event",
                Office = "12",
                Street = "Lenina",
                ImageData = null,
                ImageMimeType = ""
            });
            models.Add(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
            return View(models);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            var categories = new List<EventCategoryMvcViewModel>();
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 0,
                LocalizedName = "Category 1"
            });
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 0,
                LocalizedName = "Category 1"
            });
            SelectList categ = new SelectList(categories, "Id", "LocalizedName");
            ViewBag.Categories = categ;
            return View(new EventMvcViewModel
            {
                ImageData = null,
                ImageMimeType = ""
            });
        }

        // POST: Event/Create
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

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = new List<EventCategoryMvcViewModel>();
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 0,
                LocalizedName = "Category 1"
            });
            categories.Add(new EventCategoryMvcViewModel
            {
                Id = 0,
                LocalizedName = "Category 1"
            });
            SelectList categ = new SelectList(categories, "Id", "LocalizedName");
            ViewBag.Categories = categ;
            return View(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new EventMvcViewModel
            {
                Id = 2,
                CategoryId = 2,
                City = "Sevastopol2",
                Description = "test2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ShortDescripton = "te2",
                Name = "Event2",
                Office = "122",
                Street = "Lenina2",
                ImageData = null,
                ImageMimeType = ""
            });
        }

        // POST: Event/Delete/5
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
