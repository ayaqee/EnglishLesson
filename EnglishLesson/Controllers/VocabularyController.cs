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
    public class VocabularyController : Controller
    {
        private LessonContext db = new LessonContext();

        //
        // GET: /Vocabulary/

        public ViewResult Index()
        {
            return View(db.VocabularyItems.ToList());
        }

        //
        // GET: /Vocabulary/Details/5

        public ViewResult Details(int id)
        {
            var query = (from c in db.VocabularyItems where c.Id == id select c).Include("TranslateSuggestions");
            VocabularyItem vocabularyitem = query.FirstOrDefault();
            return View(vocabularyitem);
        }

        //
        // GET: /Vocabulary/Create

        public ActionResult Create()
        {
            VocabularyItem model = new VocabularyItem();
            model.TranslateSuggestions = new List<TranslateSuggestion>();
            model.TranslateSuggestions.Add(new TranslateSuggestion());
            model.TranslateSuggestions.Add(new TranslateSuggestion());
            model.TranslateSuggestions.Add(new TranslateSuggestion());
            return View(model);
        } 

        //
        // POST: /Vocabulary/Create

        [HttpPost]
        public ActionResult Create(VocabularyItem vocabularyitem)
        {
            if (ModelState.IsValid)
            {
                db.VocabularyItems.Add(vocabularyitem);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(vocabularyitem);
        }
        
        //
        // GET: /Vocabulary/Edit/5
 
        public ActionResult Edit(int id)
        {
            VocabularyItem vocabularyitem = 
                db.VocabularyItems.Include(m => m.TranslateSuggestions).FirstOrDefault(x => x.Id == id);
            return View(vocabularyitem);
        }

        //
        // POST: /Vocabulary/Edit/5

        [HttpPost]
        public ActionResult Edit(VocabularyItem vocabularyitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vocabularyitem).State = EntityState.Modified;
                //db.Entry(vocabularyitem.TranslateSuggestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vocabularyitem);
        }

        //
        // GET: /Vocabulary/Delete/5
 
        public ActionResult Delete(int id)
        {
            VocabularyItem vocabularyitem = db.VocabularyItems.Find(id);
            return View(vocabularyitem);
        }

        //
        // POST: /Vocabulary/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            VocabularyItem vocabularyitem = db.VocabularyItems.Find(id);
            db.VocabularyItems.Remove(vocabularyitem);
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