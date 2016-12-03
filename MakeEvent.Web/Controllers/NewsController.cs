using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MakeEvent.Business.Models;
using MakeEvent.Business.Services.Interfaces;
using MakeEvent.Common.Models;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Models.Admin;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, Localized]
    public class NewsController : Controller
    {
        private readonly INewsService  _newsService;
        private readonly IImageService _imageService;

        public NewsController(INewsService newsService, IImageService imageService)
        {
            _newsService  = newsService;
            _imageService = imageService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var news = _newsService.All();

            var model = news.Data
                .Select(Mapper.Map<NewsMvcViewModel>)
                .ToList();

            foreach (var n in model.Where(m => m.ImageId.HasValue))
            {
                var image = _imageService.Get(n.ImageId.Value).Data;
                n.ImageData = image.Content;
                n.ImageMimeType = image.MimeType;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var news = _newsService.Get(id).Data;
            var model = Mapper.Map<NewsMvcViewModel>(news);

            if (news.ImageId.HasValue)
            {
                var image = _imageService.Get(news.ImageId.Value).Data;
                model.ImageData = image.Content;
                model.ImageMimeType = image.MimeType;
            }

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

            OperationResult<ImageDto> imageResult = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var image = Mapper.Map<ImageDto>(file);
                imageResult = _imageService.SaveImage(image);
            }

            if (imageResult!= null && !imageResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении новости:</br>" 
                                            + $"{string.Join("</br>", imageResult.Errors)}");

                return View(model);
            }

            var news = Mapper.Map<NewsDto>(model);
            news.ImageId = imageResult?.Data.Id;

            var newsResult = _newsService.Save(news);

            if (!newsResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении новости:</br>" 
                                            + $"{string.Join("</br>", newsResult.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var news = _newsService.Get(id).Data;
            var model = Mapper.Map<NewsMvcViewModel>(news);

            if (news.ImageId.HasValue)
            {
                var image = _imageService.Get(news.ImageId.Value).Data;
                model.ImageData = image.Content;
                model.ImageMimeType = image.MimeType;
            }

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

            OperationResult<ImageDto> imageResult = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var image = Mapper.Map<ImageDto>(file);
                imageResult = _imageService.SaveImage(image);
            }

            if (imageResult != null && !imageResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении новости:</br>"
                                            + $"{string.Join("</br>", imageResult.Errors)}");

                return View(model);
            }

            var news = Mapper.Map<NewsDto>(model);
            news.ImageId = imageResult?.Data.Id;

            var newsResult = _newsService.Save(news);

            if (!newsResult.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении новости:</br>"
                                            + $"{string.Join("</br>", newsResult.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = _newsService.Get(id).Data;
            var model = Mapper.Map<NewsMvcViewModel>(category);

            var image = _imageService.Get(id).Data;
            model.ImageData = image.Content;
            model.ImageMimeType = image.MimeType;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, NewsMvcViewModel model)
        {
            var result = _newsService.Delete(id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при удалении новости:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult	GetImage(int id)
        {
            var newsResult  = _newsService.Get(id);
            var news = newsResult.Data;
            var imageResult = (newsResult != null && newsResult.Succeeded && news.ImageId.HasValue)
                ? _imageService.Get(news.ImageId.Value)
                : null;

            return (imageResult != null && imageResult.Succeeded)
                ? File(imageResult.Data.Content, imageResult.Data.MimeType)
                : null;
        }
    }
}
