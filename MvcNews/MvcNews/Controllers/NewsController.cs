﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcNews.Models;
using MvcNews.ViewModel;
using System.Data.Entity.Infrastructure;

namespace MvcNews.Controllers
{
    public class NewsController : Controller
    {
        private NewsDbContext db = new NewsDbContext();

       
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Category);
            return View(news.ToList());
        }
      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
       
        public ActionResult Create()
        {
            CategoryList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tittle,Description,Body,Published,PostedDate,Modified,CategoryID")] News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CategoryList(news.CategoryID);
            return View(news);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            CategoryList(news.CategoryID);
            return View(news);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tittle,Description,Body,Published,PostedDate,Modified,CategoryID")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CategoryList(news.CategoryID);
            return View(news);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }






# region helpers
        private void CategoryList(object selectedCategory = null)
        {
            var category = from d in db.Categories
                           orderby d.CategoryName
                           select d;
            ViewBag.CategoryID = new SelectList(category, "CategoryId", "CategoryName", selectedCategory);
        }




# endregion
    }
}
