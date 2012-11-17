using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EnglishLesson.Models;

namespace EnglishLesson.DataLayer
{
//    class LessonInitializer : DropCreateDatabaseIfModelChanges<LessonContext>
    class LessonInitializer : DropCreateDatabaseAlways<LessonContext>
    {
        protected override void Seed(LessonContext context)
        {
            var v1 = new VocabularyItem {
                    Word="cat3", 
                    Translation="kot",
                    TranslateSuggestions= new List<TranslateSuggestion>(){
                        new TranslateSuggestion{Suggestion="pies"},
                        new TranslateSuggestion{Suggestion="slon"},
                        new TranslateSuggestion{Suggestion="kot"}
                    }
            };

            var v2 = new VocabularyItem {
                    Word="dog", 
                    Translation="pies",
                    TranslateSuggestions= new List<TranslateSuggestion>(){
                        new TranslateSuggestion{Suggestion="pies"},
                        new TranslateSuggestion{Suggestion="krowa"},
                        new TranslateSuggestion{Suggestion="zaba"}
                    }
                };

            var v3 = new VocabularyItem
            {
                Word = "mouse",
                Translation = "mysz",
                TranslateSuggestions = new List<TranslateSuggestion>(){
                        new TranslateSuggestion{Suggestion="mysz"},
                        new TranslateSuggestion{Suggestion="kon"},
                        new TranslateSuggestion{Suggestion="lew"}
                    }
            };

            new List<VocabularyItem> {
                v1, v2, v3
            }.ForEach(b => context.VocabularyItems.Add(b));

            context.VocabularySets.Add(new VocabularySet
            {
                Name = "Test Set",
                Words = new List<VocabularyItem>() { v1, v2, v3 }
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
