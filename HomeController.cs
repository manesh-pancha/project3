using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using manga2.Models;
using System.Data.Entity;


namespace manga2.Controllers
{
    public class HomeController : Controller
    {
        private mangaEntities2 db = new mangaEntities2();
        public ActionResult Index()
        {
            var manga = from m in db.mangaseries select m;
            return View(manga);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(mangaseries manga)
        {
            if (ModelState.IsValid)
            {
                db.mangaseries.Add(manga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manga);
        }

        public ActionResult Edit(int ID)
        {
            mangaseries manga = db.mangaseries.Find(ID);
            return View(manga);
        }
        [HttpPost]
        public ActionResult Edit(mangaseries manga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manga);
        }
        public ActionResult Details(int ID)
        {
            mangaseries manga = db.mangaseries.Find(ID);
            return View(manga);
        }
        //public ActionResult Delete(int ID)
        //{
        //    mangaseries manga = db.mangaseries.Find(ID);
        //        return View(manga);
        //}
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int ID)
        //{
        //    mangaseries manga = db.mangaseries.Find(ID);
        //    db.mangaseries.Remove(manga);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}