using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public string Text { get; set; }
        public string Role { get; set; }
        public string Root { get; set; }

        public int SentenceId { get; set; }
        public virtual Sentence Sentence { get; set; }

        public int? ParentID { get; set; }
        [ForeignKey("ParentID")]
        public List<Word> SubWords { get; set; }
    }
}
