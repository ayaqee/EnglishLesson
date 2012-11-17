using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishLesson.Models
{
    public class VocabularySet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VocabularyItem> Words { get; set; }
        
    }

}