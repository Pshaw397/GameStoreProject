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
            using(var db = new GameStoreContext())
            {
                //db.Add(new Game() { Name = "Shadow of the Tomb Raider", Descrption = "As Lara Croft races to save the world from a Maya apocalypse, she must become the Tomb Raider she is destined to be.", Price = 44.99, ReleaseDate = new DateTime(2018, 09, 14),  })
            }
        }
    }
}
