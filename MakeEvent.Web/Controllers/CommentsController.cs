﻿using System;
using System.Collections.Generic;
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
    [Localized]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult Index(int? orgId)
        {
            var comments = _commentService.All().Data;
            var models = Mapper.Map<IEnumerable<CommentMvcViewModel>>(comments);

            return View(models);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var comment = _commentService.Get(id).Data;
            var model = Mapper.Map<CommentMvcViewModel>(comment);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CommentMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var result = _commentService.Save(Mapper.Map<CommentDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при добавлении комментария:</br>" 
                                            + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

                return RedirectToAction("OrganizationsList", "Home");
            }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var comment = _commentService.Get(id).Data;
            var model = Mapper.Map<CommentMvcViewModel>(comment);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CommentMvcViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            if (model.Id == 0)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, 
                    "Не указан идентификатор комментария");
            }

            var result = _commentService.Save(Mapper.Map<CommentDto>(model));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при обновлении комментария:</br>" 
                                            + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var comment = _commentService.Get(id).Data;
            var model = Mapper.Map<CommentMvcViewModel>(comment);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, CommentMvcViewModel model)
        {
            var result = _commentService.Delete(id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Ошибки при удалении комментария:</br>" + $"{string.Join("</br>", result.Errors)}");
                return View(model);
            }

                return RedirectToAction("Index");
            }
    }
}

