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

        public void Create(string fullName, string username, string region, decimal wallet, string email, string password)
        {
            User newUser = new User() { FullName = fullName, Username = username, Region = region, Wallet = wallet, Email = email };
            using (var db = new GameMarketContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
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
                userUpdate.Region = region;
                userUpdate.Wallet = wallet;
                userUpdate.Email = email;
                userUpdate.Password = password;
                db.SaveChanges();
            }
        }
    }
}
