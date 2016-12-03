using MakeEvent.Web.Models.Organization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;

namespace MakeEvent.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult Index(string orgId)
        {
            var ticketCategories = (string.IsNullOrEmpty(orgId))
                ? _ticketService.AllCategories().Data
                : _ticketService.GetCategoriesByOrganization(orgId).Data;

            var models = Mapper.Map<IEnumerable<TicketCategoryMvcViewModel>>(ticketCategories);

            return View(models);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ticketCategory = _ticketService.GetCategory(id).Data;
            var model = Mapper.Map<TicketCategoryMvcViewModel>(ticketCategory);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            return View(new TicketCategoryMvcViewModel { EventId = id });
        }

        [HttpPost]
        public ActionResult Create(TicketCategoryMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var result = _ticketService.SaveCategory(Mapper.Map<TicketCategoryDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении категории билетов:</br>"
                                            + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ticketCategory = _ticketService.GetCategory(id).Data;
            var model = Mapper.Map<TicketCategoryMvcViewModel>(ticketCategory);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, TicketCategoryMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            if (model.Id == 0)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError,
                    "Не указан идентификатор категории билетов");
            }

            var result = _ticketService.SaveCategory(Mapper.Map<TicketCategoryDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении категории билетов:</br>"
                                            + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ticketCategory = _ticketService.GetCategory(id).Data;
            var model = Mapper.Map<TicketCategoryMvcViewModel>(ticketCategory);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, TicketCategoryMvcViewModel model)
        {
            var result = _ticketService.DeleteCategory(id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при удалении категории билетов:</br>"
                                           + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SoldList(int? orgId)
        {
            var models = new List<SoldTicketMvcViewModel>();
            models.Add(new SoldTicketMvcViewModel
            {
                Id = 0,
                Cost = 300,
                Date=DateTime.Now,
                EventTitle="Test",
                Owner="Ivanov Ivan",
                Status="Бронь"
            });
            models.Add(new SoldTicketMvcViewModel
            {
                Id = 1,
                Cost = 200,
                Date = DateTime.Now,
                EventTitle = "Te3t",
                Owner = "Ivanov 3van",
                Status = "Брон3ь"
            });
            return View(models);
        }

        // GET: Ticket/Details/5
        public ActionResult SoldTicket(int id)
        {
            return View(new SoldTicketMvcViewModel
            {
                Id = 1,
                Cost = 200,
                Date = DateTime.Now,
                EventTitle = "Te3t",
                Owner = "Ivanov 3van",
                Status = "Брон3ь"
            });
        }

        [HttpPost]
        public ActionResult Buy(FormCollection collection)
        {
            return RedirectToAction("Events", "Home");

        }
    }
}
