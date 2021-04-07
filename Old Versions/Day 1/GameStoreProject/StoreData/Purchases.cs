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
            Games = new HashSet<Game>();
        }
        // Purchases = Orders
        public int PurchaseID { get; set; }
        public int AccountID { get; set; }
        public string GameID { get; set; } // 
        public DateTime PurchaseDate { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual User Users { get; set; }

    }
}