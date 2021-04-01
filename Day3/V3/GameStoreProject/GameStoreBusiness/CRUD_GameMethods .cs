using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_GameMethods
    {
        public Game gameUpdate { get; set; }

        public void Create(string name, string description, string coverIMG, decimal price, string publisher, int year, int month, int day)
        {
            Game newGame = new Game() { Name = name, Description = description, CoverImgPath = coverIMG, Price = price, Publisher = publisher, ReleaseDate = new DateTime(year, month, day) };
            using (var db = new GameMarketContext())
            {
                db.Games.Add(newGame);
                db.SaveChanges();
            }
        }

        public void Delete(string name)
        {
            using (var db = new GameMarketContext())
            {
                gameUpdate = db.Games.Where(c => c.Name == name).FirstOrDefault();
                db.Games.Remove(gameUpdate);
                db.SaveChanges();
            }
        }

        public void Update(string nameID, string name, string description, string coverIMG, decimal price, string publisher, int year, int month, int day)
        {
            using (var db = new GameMarketContext())
            {
                gameUpdate = db.Games.Where(c => c.Name == nameID).FirstOrDefault();
                gameUpdate.Name = name;
                gameUpdate.Description = description;
                gameUpdate.CoverImgPath = coverIMG;
                gameUpdate.ReleaseDate = new DateTime(year, month, day);
                gameUpdate.Price = price;
                gameUpdate.Publisher = publisher;
                db.SaveChanges();
            }
        }
    }
}
