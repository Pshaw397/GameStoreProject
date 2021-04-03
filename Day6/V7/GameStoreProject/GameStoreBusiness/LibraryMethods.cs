using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData;

namespace GameStoreBusiness
{
    public class LibraryMethods
    {
        public User selectedUser()
        {
            User selected = new User();
            using(var db = new GameMarketContext())
            selected = db.Users.Where(u => u.Selected == true).FirstOrDefault();
            return selected;
        }
    }
}
