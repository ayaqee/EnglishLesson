using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishLesson.Models;
using EnglishLesson.DataLayer;

namespace EnglishLesson.Controllers
{ 
    public class ExampleController : Controller
    {
        private LessonContext db = new LessonContext();

        //
        // GET: /Example/

        public ViewResult Index()
        {
            return View(db.Examples.ToList());
        }

        //
        // GET: /Example/Details/5

        public ViewResult Details(int id)
        {
            Example example = db.Examples.Find(id);
            return View(example);
        }

        //
        // GET: /Example/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Example/Create

        [HttpPost]
        public ActionResult Create(Example example)
        {
            if (ModelState.IsValid)
            {
                db.Examples.Add(example);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(example);
        }
        
        //
        // GET: /Example/Edit/5
 
        public ActionResult Edit(int id)
        {
            Example example = db.Examples.Find(id);
            return View(example);
        }

        //
        // POST: /Example/Edit/5

        [HttpPost]
        public ActionResult Edit(Example example)
        {
            if (ModelState.IsValid)
            {
                db.Entry(example).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(example);
        }

        //
        // GET: /Example/Delete/5
 
        public ActionResult Delete(int id)
        {
            Example example = db.Examples.Find(id);
            return View(example);
        }

        //
        // POST: /Example/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Example example = db.Examples.Find(id);
            db.Examples.Remove(example);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}