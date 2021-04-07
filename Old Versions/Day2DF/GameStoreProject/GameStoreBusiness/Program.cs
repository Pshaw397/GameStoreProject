using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData;

namespace StoreBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new GameMarketContext())
            {
                db.Add(new User() { FullName = "Liv Jeremiah", Region = "UK", Username = "voidfishing", Wallet = 10.99m });
                db.SaveChanges();
            }
        }
    }
}
