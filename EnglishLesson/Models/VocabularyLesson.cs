using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishLesson.Models
{
    public class VocabularyLesson
    {
        public List<VocabularyItem> Words;
        public DateTime AttemptedOn;
        public string AttemptedBy;
        public string Description;
    }
}