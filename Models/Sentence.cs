using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index.Models
{
    public class Sentence
    {
        public int SentenceId { get; set; }
        public string Dataset_version { get; set; }
        public string Generator { get; set; }
        public string News_uniqe_id { get; set; }
        public int Sentence_order { get; set; }
        public string Sentence_id { get; set; }
        public string Date_time { get; set; }
        public string Text { get; set; }

        public int DatasetId { get; set; }
        public virtual Dataset Dataset { get; set; }

        public virtual List<Word> Words { get; set; }
    }
}
