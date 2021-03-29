using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreData
{
    public partial class Purchase
    {
        public int PurchaseID { get; set; }
        public int AccountID { get; set; }
        public string GameID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual Game Games { get; set; }
        public virtual User Users { get; set; }
    }
}