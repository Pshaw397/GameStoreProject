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
                //db.Add(new GameGenre()
                //{
                //    GameId = 1,
                //    GenreId = 6
                //});
                db.SaveChanges();
            }
        }
    }
}
