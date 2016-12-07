using MakeEvent.Web.Models.Organization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Common;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, Localized]
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
        public ActionResult SoldDetails(int id)
        {
            var ticket = _ticketService.GetTicket(id).Data;
            var model = Mapper.Map<SoldTicketMvcViewModel>(ticket);

            return View("SoldTicket", model);
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
        public ActionResult Sold(string orgId)
        {
            if (string.IsNullOrEmpty(orgId))
                return RedirectToAction("Index");

            var tickets = _ticketService.GetTicketsByOrganization(orgId).Data;
            var models  = Mapper.Map<IEnumerable<SoldTicketMvcViewModel>>(tickets);

            return View("SoldList", models);
        }

        [HttpGet]
        public ActionResult SoldTicket(int id)
        {
            var ticket = _ticketService.GetTicket(id);
            var model  = Mapper.Map<SoldTicketMvcViewModel>(ticket);

            return View(model);
        }

        [HttpGet]
        public JsonResult GetTicketPrice(int ticketCategoryId)
        {
            var ticketCategory = _ticketService.GetCategory(ticketCategoryId);
            return ticketCategory.Succeeded 
                ? Json(new {data = ticketCategory.Data.Price}, JsonRequestBehavior.AllowGet) 
                : Json(new {errors = $"No category for id {ticketCategoryId}"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Buy(int eventId, EventWithTicketsMvcViewModel model)
        {
            var ticket = Mapper.Map<TicketDto>(model.Ticket);
            var result = _ticketService.CreateTicket(ticket);

            if (result.Succeeded)
                return RedirectToAction("Events", "Home");

            return RedirectToAction("Event", "Home", new { id = eventId });
        }
    }
}
