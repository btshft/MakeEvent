using MakeEvent.Web.Models.Admin;
using MakeEvent.Web.Models.Organization;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Domain.Filters;
using MakeEvent.Web.Attributes;
using Microsoft.AspNet.Identity;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, Localized]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IEventCategoryService _categoryService;
        private readonly IImageService _imageService;

        public EventController(
            IEventService eventService, 
            IEventCategoryService categoryService,
            IImageService imageService)
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        [HttpGet]
        public ActionResult Index(string orgId)
        {
            var events = (string.IsNullOrEmpty(orgId))
                ? _eventService.All().Data
                : _eventService.Filter(new EventFilter { OrganizationId = orgId }).Data.Items;

            var models = Mapper.Map<IEnumerable<EventMvcViewModel>>(events);

            return View(models);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var @event = _eventService.Get(id).Data;
            var model = Mapper.Map<EventMvcViewModel>(@event);
            
            return View(model);
        }

        [HttpGet, Authorize(Roles = "Organization")]
        public ActionResult Create()
        {
            var organizationId = User.Identity.GetUserId();
            SetupCategoriesDropdown();

            return View(new EventMvcViewModel { OrganizationId = organizationId });
        }

        [HttpPost, Authorize(Roles = "Organization")]
        public ActionResult Create(EventMvcViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                SetupCategoriesDropdown();
                return View(model);
            }

            OperationResult<ImageDto> imageResult = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var image = Mapper.Map<ImageDto>(file);
                imageResult = _imageService.SaveImage(image);
            }

            if (imageResult != null && !imageResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении события:</br>"
                                            + $"{string.Join("</br>", imageResult.Errors)}");
                SetupCategoriesDropdown();
                return View(model);
            }

            var @event = Mapper.Map<EventDto>(model);
            @event.ImageId = imageResult?.Data.Id;

            var eventResult = _eventService.Save(@event);

            if (!eventResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении события:</br>"
                                            + $"{string.Join("</br>", eventResult.Errors)}");
                SetupCategoriesDropdown();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet, Authorize(Roles = "Organization")]
        public ActionResult Edit(int id)
        {
            var categories = _categoryService.All().Data;
            var categoriesModel = Mapper.Map<IEnumerable<EventCategoryMvcViewModel>>(categories);
            var categoriesSelectList = new SelectList(categoriesModel, "Id", "LocalizedName");

            ViewBag.Categories = categoriesSelectList;

            var @event = _eventService.Get(id).Data;
            var model = Mapper.Map<EventMvcViewModel>(@event);

            return View(model);
        }

        [HttpPost, Authorize(Roles = "Organization")]
        public ActionResult Edit(int id, EventMvcViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                SetupCategoriesDropdown();
                return View(model);
            }

            if (model.Id == 0)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError,
                    "Не указан идентификатор события");
            }

            OperationResult<ImageDto> imageResult = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var image = Mapper.Map<ImageDto>(file);
                imageResult = _imageService.SaveImage(image);
            }

            if (imageResult != null && !imageResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении события:</br>"
                                           + $"{string.Join("</br>", imageResult.Errors)}");
                SetupCategoriesDropdown();
                return View(model);
            }

            var @event = Mapper.Map<EventDto>(model);
            @event.ImageId = imageResult?.Data.Id;

            var eventResult = _eventService.Save(@event);

            if (!eventResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении события:</br>"
                                            + $"{string.Join("</br>", eventResult.Errors)}");
                SetupCategoriesDropdown();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet, Authorize(Roles = "Organization")]
        public ActionResult Delete(int id)
        {
            var @event = _eventService.Get(id).Data;
            var model = Mapper.Map<EventMvcViewModel>(@event);

            return View(model);
        }

        [HttpPost, Authorize(Roles = "Organization")]
        public ActionResult Delete(int id, EventMvcViewModel model)
        {
            var result = _eventService.Delete(id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при удалении события:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        private void SetupCategoriesDropdown()
        {
            var categories = _categoryService.All().Data;
            var categoriesModel = Mapper.Map<IEnumerable<EventCategoryMvcViewModel>>(categories);
            var categoriesSelectList = new SelectList(categoriesModel, "Id", "LocalizedName");
            ViewBag.Categories = categoriesSelectList;
        }
    }
}
