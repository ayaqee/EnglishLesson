using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EnglishLesson.Models;

namespace EnglishLesson.DataLayer
{
    public class LessonContext : DbContext
    {
        public DbSet<VocabularyItem> VocabularyItems {get; set;}
        public DbSet<TranslateSuggestion> TranslateSuggestions { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<VocabularySet> VocabularySets { get; set; }


    }
}