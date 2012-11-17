using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishLesson.Models
{
    public class VocabularyTest
    {
        public List<VocabularyItem> Words;
        public List<VocabularyItem> Passed;
        public List<VocabularyItem> Failed;
        public DateTime AttemptedOn;
        public string AttemptedBy;
        public string Description;
    }
}