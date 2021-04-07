using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public int PublisherName { get; set; }
        public virtual ICollection<Game> Games { get; set; } // Each publisher can have multiple games
    }
}
