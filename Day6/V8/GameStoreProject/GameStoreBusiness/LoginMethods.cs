using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData;

namespace GameStoreBusiness
{
    public class LoginMethods
    {
        public User currentUser = new User();
        public decimal emailCheck(string email, string password)
        {
            using (var db = new GameMarketContext())
            {
                var emailQuery = db.Users.Where(u => u.Email == email).FirstOrDefault();
                if (emailQuery != null && emailQuery.Password == password)
                {
                    currentUser = emailQuery;
                    currentUser.Selected = true;
                    db.SaveChanges();
                    return emailQuery.UserId;
                }
                return 0m;
            }
        }
    }
}
