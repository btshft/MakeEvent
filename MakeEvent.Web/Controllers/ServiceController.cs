using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        [RequireHttps, Localized]
        public ActionResult Index(string orgId)
        {
            var models = new List<ServiceMvcViewModel>();
            models.Add(new ServiceMvcViewModel
            {
                Id=0,
                OwnerId="hfdhhfdhf",
                Name="First Service",
                Description="tratatatata",
                Price=10000
            });
            models.Add(new ServiceMvcViewModel
            {
                Id = 1,
                OwnerId = "hfdhhfdhf",
                Name = "Second Service",
                Description = "second tratatatata",
                Price = 10
            });
            return View(models);
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View(new ServiceMvcViewModel
            {
                Id = 1,
                OwnerId = "hfdhhfdhf",
                Name = "Second Service",
                Description = "second tratatatata",
                Price = 10
            });
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View(new ServiceMvcViewModel());
        }

        // POST: Service/Create
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

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new ServiceMvcViewModel
            {
                Id = 1,
                OwnerId = "hfdhhfdhf",
                Name = "Second Service",
                Description = "second tratatatata",
                Price = 10
            });
        }

        // POST: Service/Edit/5
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

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new ServiceMvcViewModel
            {
                Id = 1,
                OwnerId = "hfdhhfdhf",
                Name = "Second Service",
                Description = "second tratatatata",
                Price = 10
            });
        }

        // POST: Service/Delete/5
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
        [HttpGet]
        public ActionResult BookedList(string orgId)
        {
            var models = new List<BookedServiceMvcViewModel>();
            models.Add(new BookedServiceMvcViewModel
            {
                Id = 0,
                ServiceId = 0,
                CustomerFio="Petroev Ivan Ivan",
                ServiceName="Test service",
                Date= DateTime.Now,
                Price=1000
            });
            models.Add(new BookedServiceMvcViewModel
            {
                Id = 0,
                ServiceId = 0,
                CustomerFio = "Petroev Ivan Ivan",
                ServiceName = "Test service",
                Date = DateTime.Now,
                Price = 1000
            });
            return View("BookedList",models);
        }

        [HttpGet]
        public ActionResult BookedDetails(int id)
        {
            return View("BookedService",new BookedServiceMvcViewModel
            {
                Id = 0,
                ServiceId = 0,
                CustomerFio = "Petroev Ivan Ivan",
                ServiceName = "Test service",
                Date = DateTime.Now,
                Price = 1000
            });
        }
    }
}
