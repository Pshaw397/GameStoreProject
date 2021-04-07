using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_DeveloperMethods
    {
        public Developer developerUpdate { get; set; }

        public void Create(string name)
        {
            Developer newDev = new Developer() { DeveloperName = name};
            using (var db = new GameMarketContext())
            {
                db.Developers.Add(newDev);
                db.SaveChanges();
            }
        }

        public void Delete(string devName)
        {
            using (var db = new GameMarketContext())
            {
                developerUpdate = db.Developers.Where(c => c.DeveloperName == devName).FirstOrDefault();
                db.Developers.Remove(developerUpdate);
                db.SaveChanges();
            }
        }

        public void Update(string oldName, string newName)
        {
            using (var db = new GameMarketContext())
            {
                developerUpdate = db.Developers.Where(c => c.DeveloperName == oldName).FirstOrDefault();
                developerUpdate.DeveloperName = newName;
 
                db.SaveChanges();
            }
        }
    }
}
