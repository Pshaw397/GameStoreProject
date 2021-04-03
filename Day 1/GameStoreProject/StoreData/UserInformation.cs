using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreData
{
    public partial class User
    {
        public User()
        {
            Purchases = new HashSet<Purchase>();
        }
        // User = Customer
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Region { get; set; }
        public int Wallet { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}