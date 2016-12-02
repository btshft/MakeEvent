using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeEvent.Web.Models.Admin;

namespace MakeEvent.Web.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index(int? orgId)
        {
            var models = new List<CommentMvcViewModel>();
            models.Add(new CommentMvcViewModel{
            Id=0,
            OrgId = "1",
            AuthorName="Foo",
            AuthorEmail="foo@bar.com",
            CreatedDate=DateTime.Now,
            Text="example"});
            models.Add(new CommentMvcViewModel
            {
                Id = 2,
                OrgId = "1",
                AuthorName = "Bar",
                AuthorEmail = "foo@bar.com",
                CreatedDate = DateTime.Now,
                Text = "example12"
            });
            return View(models);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            return View(new CommentMvcViewModel
            {
                Id = 2,
                OrgId = "1",
                AuthorName = "Bar",
                AuthorEmail = "foo@bar.com",
                CreatedDate = DateTime.Now,
                Text = "example12"
            });
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("OrganizationsList", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new CommentMvcViewModel
            {
                Id = 2,
                OrgId = "1",
                AuthorName = "Bar",
                AuthorEmail = "foo@bar.com",
                CreatedDate = DateTime.Now,
                Text = "example12"
            });
        }

        // POST: Comments/Edit/5
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

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new CommentMvcViewModel
            {
                Id = 2,
                OrgId = "1",
                AuthorName = "Bar",
                AuthorEmail = "foo@bar.com",
                CreatedDate = DateTime.Now,
                Text = "example12"
            });
        }

        // POST: Comments/Delete/5
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
