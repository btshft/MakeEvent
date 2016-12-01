using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MakeEvent.Business.Enums;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Admin;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, Localized]
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        // GET: Page
        public ActionResult Index()
        {
            var pages = _pageService.All();
            var model = pages.Result.Select(Mapper.Map<PageMvcViewModel>);

            return View(model);
        }

        // GET: Page/Details/5
        public ActionResult Details(int id)
        {
            var page = _pageService.Get(id).Result;
            var model = Mapper.Map<PageMvcViewModel>(page);

            return View(model);
        }

        // GET: Page/Edit/5
        public ActionResult Edit(int id)
        {
            var page = _pageService.Get(id).Result;
            var model = Mapper.Map<PageMvcViewModel>(page);

            return View(model);
        }

        // POST: Page/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PageMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            if (model.Id == 0)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Не указан идентификатор категории");
            }

            var enLocalization = new PageLocalizationDto
            {
                Html       = model.ContentEn,
                LanguageId = (int) CultureLanguage.EN,
                PageId     = model.Id,
                Title      = model.TitleEn
            };

            var ruLocalization = new PageLocalizationDto
            {
                Html       = model.ContentRu,
                LanguageId = (int) CultureLanguage.RU,
                PageId     = model.Id,
                Title      = model.TitleRu
            };

            var result = _pageService.SaveLocalizations(model.Name, ruLocalization, enLocalization);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении новости:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
