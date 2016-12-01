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
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var news = _newsService.All();
            var model = news.Result
                .Select(Mapper.Map<NewsMvcViewModel>);

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var category = _newsService.Get(id).Result;
            var model = Mapper.Map<NewsMvcViewModel>(category);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new NewsMvcViewModel());
        }

        [HttpPost]
        public ActionResult Create(NewsMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var result = _newsService.Save(Mapper.Map<NewsDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении ноовсти:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _newsService.Get(id).Result;
            var model = Mapper.Map<NewsMvcViewModel>(category);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, NewsMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            if (model.Id == 0)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Не указан идентификатор категории");
            }

            var result = _newsService.Save(Mapper.Map<NewsDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении новости:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = _newsService.Get(id).Result;
            var model = Mapper.Map<NewsMvcViewModel>(category);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, NewsMvcViewModel model)
        {
            var result = _newsService.Delete(id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при удалении категории:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult	GetImage(int id)
        {
            return null;
        }
    }
}
