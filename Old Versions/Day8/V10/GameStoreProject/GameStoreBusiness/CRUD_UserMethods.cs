using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData;

namespace GameStoreBusiness
{
    public class CRUD_UserMethods
    {
        public User userUpdate { get; set; }

        public bool Create(string fullName, string username, string email, string password)
        {
            using(var db = new GameMarketContext())
            {
                var newUsernameQuery = db.Users.Where(u => u.Username == username).FirstOrDefault();
                var newEmailQuery = db.Users.Where(u => u.Email == email).FirstOrDefault();

                if(newUsernameQuery == null && newEmailQuery == null)
                {
                    User newUser = new User() { FullName = fullName, Username = username, Email = email, Password = password };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void Delete(string username)
        {
            using (var db = new GameMarketContext())
            {
                userUpdate = db.Users.Where(c => c.Username == username).FirstOrDefault();
                db.Users.Remove(userUpdate);
                db.SaveChanges();
            }
        }

        public void Update(string usernameOld, string usernameNew, string region, decimal wallet, string email, string password)
        {
            using (var db = new GameMarketContext())
            {
                userUpdate = db.Users.Where(c => c.Username == usernameOld).FirstOrDefault();
                userUpdate.Username = usernameNew;
                userUpdate.Wallet = wallet;
                userUpdate.Email = email;
                userUpdate.Password = password;
                db.SaveChanges();
            }
        }

        public void selectedReset()
        {
            using(var db = new GameMarketContext())
            {
                var selectedUsers = db.Users.Where(u => u.Selected == true);
                foreach (var item in selectedUsers)
                {
                    item.Selected = false;
                }
                db.SaveChanges();
            }
        }
    }
}
