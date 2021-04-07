using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_GenreMethods
    {
        public Genre GenreUpdate { get; set; }

        public void Create(string name)
        {
            Genre newGenre = new Genre() { GenreName = name};
            using (var db = new GameMarketContext())
            {
                db.Genres.Add(newGenre);
                db.SaveChanges();
            }
        }

        public void Delete(string genreName)
        {
            using (var db = new GameMarketContext())
            {
                GenreUpdate = db.Genres.Where(g => g.GenreName == genreName).FirstOrDefault();
                db.Genres.Remove(GenreUpdate);
                db.SaveChanges();
            }
        }

        public void Update(string oldName, string newName)
        {
            using (var db = new GameMarketContext())
            {
                GenreUpdate = db.Genres.Where(c => c.GenreName == oldName).FirstOrDefault();
                GenreUpdate.GenreName = newName;
                db.SaveChanges();
            }
        }
    }
}
