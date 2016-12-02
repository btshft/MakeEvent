using MakeEvent.Web.Models.Organization;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MakeEvent.Web.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index(int? orgId)
        {
            var models = new List<TicketMvcViewModel>();
            models.Add(new TicketMvcViewModel
            {
                Id = 0,
                Description = "test",
                MaxCount=12,
                Price=400,
                TypeName="VIP"
            });
            models.Add(new TicketMvcViewModel
            {
                Id = 2,
                Description = "test test",
                MaxCount = 1222,
                Price = 200,
                TypeName = "ne VIP"
            });
            return View(models);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View(new TicketMvcViewModel
            {
                Id = 2,
                Description = "test test",
                MaxCount = 1222,
                Price = 200,
                TypeName = "ne VIP"
            });
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
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

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new TicketMvcViewModel
            {
                Id = 2,
                Description = "test test",
                MaxCount = 1222,
                Price = 200,
                TypeName = "ne VIP"
            });
        }

        // POST: Ticket/Edit/5
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

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new TicketMvcViewModel
            {
                Id = 2,
                Description = "test test",
                MaxCount = 1222,
                Price = 200,
                TypeName = "ne VIP"
            });
        }

        // POST: Ticket/Delete/5
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
