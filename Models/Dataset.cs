using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index.Models
{
    public class Dataset
    {
        public int DatasetId { get; set; }
        public string Name { get; set; }        
        public virtual List<Sentence> Sentences { get; set; }
    }
}
