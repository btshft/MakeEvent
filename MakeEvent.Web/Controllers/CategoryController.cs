using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Admin;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, Localized]
    public class CategoryController : BaseController
    {
        private readonly IEventCategoryService _eventCategoryService;

        public CategoryController(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = _eventCategoryService.All();
            var model = categories.Data
                .Select(Mapper.Map<EventCategoryMvcViewModel>);

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var category = _eventCategoryService.Get(id).Data;
            var model = Mapper.Map<EventCategoryMvcViewModel>(category);

            return View(model);
        }

        [HttpGet, AdminAuthorize]
        public ActionResult Create()
        {
            return View(new EventCategoryMvcViewModel());
        }

        [HttpPost, AdminAuthorize]
        public ActionResult Create(EventCategoryMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var result = _eventCategoryService.Save(Mapper.Map<EventCategoryDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении категории:</br>" 
                                           + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet, AdminAuthorize]
        public ActionResult Edit(int id)
        {
            var category = _eventCategoryService.Get(id).Data;
            var model = Mapper.Map<EventCategoryMvcViewModel>(category);

            return View(model);
        }

        [HttpPost, AdminAuthorize]
        public ActionResult Edit(EventCategoryMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            if (model.Id == 0)
            {
                throw new HttpException((int) HttpStatusCode.InternalServerError, "Не указан идентификатор категории");
            }

            var result = _eventCategoryService.Save(Mapper.Map<EventCategoryDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении категории:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet, AdminAuthorize]
        public ActionResult Delete(int id)
        {
            var category = _eventCategoryService.Get(id).Data;
            var model = Mapper.Map<EventCategoryMvcViewModel>(category);

            return View(model);
        }

        [HttpPost, AdminAuthorize]
        public ActionResult Delete(int id, EventCategoryMvcViewModel model)
        {
            var result = _eventCategoryService.Delete(id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при удалении категории:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
