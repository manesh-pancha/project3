using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using manga2.Models;
using System.Data.Entity;

namespace manga2.Controllers
{
    public class characterController : Controller
    {
        // GET: character
        private mangaEntities2 db = new mangaEntities2();
        public ActionResult Index()
        {
            var mangaC = from m in db.mangacharacters select m;
            return View(mangaC);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(mangacharacters mangaC)
        {
            if (ModelState.IsValid)
            {
                db.mangacharacters.Add(mangaC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mangaC);
        }
        public ActionResult Edit(int ID)
        {
            mangacharacters manga = db.mangacharacters.Find(ID);
            return View(manga);
        }
        [HttpPost]
        public ActionResult Edit(mangacharacters manga)
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
            mangacharacters manga = db.mangacharacters.Find(ID);
            return View(manga);
        }
        public ActionResult Delete(int ID)
        {
            mangacharacters manga = db.mangacharacters.Find(ID);
            return View(manga);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            mangacharacters manga = db.mangacharacters.Find(ID);
            db.mangacharacters.Remove(manga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}