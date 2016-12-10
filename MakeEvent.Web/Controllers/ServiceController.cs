using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, Localized]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public ActionResult Index(string orgId)
        {
            if (string.IsNullOrEmpty(orgId))
                return RedirectToAction("Index", "Home");

            var services = _serviceService.GetByOrganizationId(orgId).Data;
            var models = Mapper.Map<IEnumerable<ServiceMvcViewModel>>(services);
            
            return View(models);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var service = _serviceService.Get(id).Data;
            var model = Mapper.Map<ServiceMvcViewModel>(service);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ServiceMvcViewModel { OwnerId = User.Identity.GetUserId() });
        }

        [HttpPost]
        public ActionResult Create(ServiceMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var result = _serviceService.Save(Mapper.Map<ServiceDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении услуги:</br>"
                                            + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index", new {orgId = model.OwnerId});
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = _serviceService.Get(id).Data;
            var model = Mapper.Map<ServiceMvcViewModel>(service);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, ServiceMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            if (model.Id == 0)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError,
                    "Не указан идентификатор услуги");
            }

            var result = _serviceService.Save(Mapper.Map<ServiceDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении услуги:</br>"
                                            + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index", new { orgId = model.OwnerId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var service = _serviceService.Get(id).Data;
            var model = Mapper.Map<ServiceMvcViewModel>(service);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, ServiceMvcViewModel model)
        {
            var result = _serviceService.Delete(id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при удалении услуги:</br>"
                                           + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index", new { orgId = model.OwnerId });
        }

        [HttpGet]
        public ActionResult BookedList(string orgId)
        {
            if (string.IsNullOrEmpty(orgId))
                return RedirectToAction("Index", "Home");

            var services = _serviceService.GetBookedByOrganizationId(orgId).Data;
            var models = Mapper.Map<IEnumerable<BookedServiceMvcViewModel>>(services);
           
            return View("BookedList", models);
        }

        [HttpGet]
        public ActionResult BookedDetails(int id)
        {
            var service = _serviceService.GetBooked(id).Data;
            var model = Mapper.Map<BookedServiceMvcViewModel>(service);

            return View("BookedService", model);
        }

        [HttpPost]
        public ActionResult BookService(BookedServiceMvcViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return RedirectToAction("Service", "Home", new {id = model.ServiceId, error = string.Join(", ", errors)});
            }

            var service = Mapper.Map<BookedServiceDto>(model);
            var result = _serviceService.BookService(service);

            if (!result.Succeeded)
            {
                return RedirectToAction("Service", "Home", new { id = model.ServiceId, error = "Не удалось заказать услугу." });
            }

            return RedirectToAction("Services", "Home");
        }
    }
}
