using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreData
{
    public partial class Game
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescrption { get; set; }
        public double GamePrice { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}