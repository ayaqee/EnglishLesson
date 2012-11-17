using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishLesson.Models
{
    public class VocabularyItem
    {
        public int Id {get; set;}
        public string Word { get; set; }
        public string Translation { get; set; }
        public List<TranslateSuggestion> TranslateSuggestions {get; set;}
    }
}