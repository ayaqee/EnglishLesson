using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnglishLesson.DataLayer;
using EnglishLesson.Models;
using System.Data.Entity;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Database.SetInitializer(new DropCreateDatabaseAlways<LessonContext>());

            var db = new LessonContext();
            VocabularyItem vItem = new VocabularyItem
            {
                Word = "mouse",
                Translation = "mysz",
                TranslateSuggestions = new List<TranslateSuggestion> { 
                    new TranslateSuggestion { Suggestion = "kon"},
                    new TranslateSuggestion { Suggestion = "pies" },
                    new TranslateSuggestion { Suggestion = "mysz"}}
            };
            db.VocabularyItems.Add(vItem);
            db.SaveChanges();
        }
    }
}
