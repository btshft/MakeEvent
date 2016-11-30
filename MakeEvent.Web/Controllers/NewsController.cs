using MakeEvent.Web.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var models = new List<NewsViewModel>();
            models.Add(new NewsViewModel{
                Id = 0,
                TitleEn = "Title",
                TitleRu = "Заголовок",
                ContentEn = "Content",
                ContentRu = "Контент",
                ShortDescriptionEn = "Description",
                ShortDescriptionRu = "Описание"
            });
            models.Add(new NewsViewModel
            {
                Id = 1,
                TitleEn = "Title1",
                TitleRu = "Заголовок1",
                ContentEn = "Content1",
                ContentRu = "Контент1",
                ShortDescriptionEn = "Description1",
                ShortDescriptionRu = "Описание1"
            });
            return View(models);
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            var model = new NewsViewModel
            {
                Id = 0,
                TitleEn = "Title",
                TitleRu = "Заголовок",
                ContentEn = "Content",
                ContentRu = "Контент",
                ShortDescriptionEn = "Description",
                ShortDescriptionRu = "Описание"
            };
            return View(model);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
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

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {

            var model = new NewsViewModel
            {
                Id = 0,
                TitleEn = "Title",
                TitleRu = "Заголовок",
                ContentEn = "Content",
                ContentRu = "Контент",
                ShortDescriptionEn = "Description",
                ShortDescriptionRu = "Описание"
            };
            return View(model);
        }

        // POST: News/Edit/5
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

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new NewsViewModel
            {
                Id = 0,
                TitleEn = "Title",
                TitleRu = "Заголовок",
                ContentEn = "Content",
                ContentRu = "Контент",
                ShortDescriptionEn = "Description",
                ShortDescriptionRu = "Описание"
            };
            return View(model);
        }

        // POST: News/Delete/5
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
