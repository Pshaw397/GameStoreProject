using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreData
{
    public partial class Purchase
    {
        public Purchase()
        {
            games = new HashSet<Game>();
        }
        // Purchases = Orders
        public int PurchaseID { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; } // 
        public DateTime PurchaseDate { get; set; }
        public virtual ICollection<Game> games { get; set; }
        public virtual User User { get; set; }

    }
}