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
    public class SetController : Controller
    {
        private LessonContext db = new LessonContext();

        //
        // GET: /Set/

        public ViewResult Index()
        {
            return View(db.VocabularySets.ToList());
        }

        //
        // GET: /Set/Details/5

        public ViewResult Details(int id)
        {
            VocabularySet vocabularyset =
                db.VocabularySets.Include(m => m.Words).FirstOrDefault(m => m.Id == id);
            return View(vocabularyset);
        }

        //
        // GET: /Set/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Set/Create

        [HttpPost]
        public ActionResult Create(VocabularySet vocabularyset)
        {
            if (ModelState.IsValid)
            {
                db.VocabularySets.Add(vocabularyset);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(vocabularyset);
        }
        
        //
        // GET: /Set/Edit/5
 
        public ActionResult Edit(int id)
        {
            VocabularySet vocabularyset = 
                db.VocabularySets.Include("VocabularyItem").FirstOrDefault(m => m.Id == id);
            return View(vocabularyset);
        }

        //
        // POST: /Set/Edit/5

        [HttpPost]
        public ActionResult Edit(VocabularySet vocabularyset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vocabularyset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vocabularyset);
        }

        //
        // GET: /Set/Delete/5
 
        public ActionResult Delete(int id)
        {
            VocabularySet vocabularyset = db.VocabularySets.Find(id);
            return View(vocabularyset);
        }

        //
        // POST: /Set/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            VocabularySet vocabularyset = db.VocabularySets.Find(id);
            db.VocabularySets.Remove(vocabularyset);
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