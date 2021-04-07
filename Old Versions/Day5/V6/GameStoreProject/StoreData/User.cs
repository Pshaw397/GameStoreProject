using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData
{
    public partial class User
    {
        public User()
        {
            Purchases = new HashSet<Purchase>();
        }

        public decimal UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Region { get; set; }
        public decimal? Wallet { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
