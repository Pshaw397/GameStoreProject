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
                db.Add(new GameDeveloper() { GameId = 1, DeveloperId = 1 });
                db.SaveChanges();
            }
        }
    }
}
