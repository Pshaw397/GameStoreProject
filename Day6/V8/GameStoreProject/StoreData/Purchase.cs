using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData
{
    public partial class Purchase
    {
        public decimal PurchaseId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? GameId { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
