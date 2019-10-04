using Index.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index
{
    public class IndexDbContext : DbContext
    {
        public IndexDbContext() : base("IndexDbConnectionString")
        {

        }
        public DbSet<Dataset> Datsets { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}
