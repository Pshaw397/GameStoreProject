using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_DeveloperMethods
    {
        public Developer developerUpdate { get; set; }

        public bool Create(string name)
        {
            Developer newDev = new Developer() { DeveloperName = name};
            using (var db = new GameMarketContext())
            {
                var newgDevQuery = db.Developers.Where(u => u.DeveloperName == name).FirstOrDefault();
                if (newgDevQuery == null)
                {
                    db.Developers.Add(newDev);
                    db.SaveChanges();
                    return true;
                }
                return false;
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

        public bool Update(string oldName, string newName)
        {
            using (var db = new GameMarketContext())
            {
                var newgDevQuery = db.Developers.Where(u => u.DeveloperName == newName).FirstOrDefault();
                if (newgDevQuery == null)
                {
                    developerUpdate = db.Developers.Where(c => c.DeveloperName == oldName).FirstOrDefault();
                    developerUpdate.DeveloperName = newName;
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
        }
        public List<string> RetrieveAll()
        {
            using (var db = new GameMarketContext())
            {
                var devNamesQuery = db.Developers.ToList();
                List<string> devNameList = new List<string>();
                foreach (var item in devNamesQuery)
                {
                    devNameList.Add(item.DeveloperName);
                }
                return devNameList;
            }
        }

        public void SetSelectedGame(string selectedItem)
        {
            using (var db = new GameMarketContext())
            {
                developerUpdate = db.Developers.Where(g => g.DeveloperName == selectedItem).FirstOrDefault();
            }
        }
    }
}
