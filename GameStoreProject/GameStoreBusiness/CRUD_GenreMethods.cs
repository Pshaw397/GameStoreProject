using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_GenreMethods
    {
        public Genre GenreUpdate { get; set; }

        public bool Create(string name)
        {
            using (var db = new GameMarketContext())
            {
                var newgGenreQuery = db.Genres.Where(u => u.GenreName == name).FirstOrDefault();

                if(newgGenreQuery == null)
                {
                    Genre newGenre = new Genre() { GenreName = name };
                    db.Genres.Add(newGenre);
                    db.SaveChanges();
                    return true;
                }
                return false;
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

        public bool Update(string oldName, string newName)
        {
            using (var db = new GameMarketContext())
            {
                var newgGenreQuery = db.Genres.Where(u => u.GenreName == newName).FirstOrDefault();
                if(newgGenreQuery == null)
                {
                    GenreUpdate = db.Genres.Where(c => c.GenreName == oldName).FirstOrDefault();
                    GenreUpdate.GenreName = newName;
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
                var gameNamesQuery = db.Genres.ToList();
                List<string> gameNameList = new List<string>();
                foreach (var item in gameNamesQuery)
                {
                    gameNameList.Add(item.GenreName);
                }
                return gameNameList;
            }
        }

        public void SetSelectedGame(string selectedItem)
        {
            using (var db = new GameMarketContext())
            {
                GenreUpdate = db.Genres.Where(g => g.GenreName == selectedItem).FirstOrDefault();
            }
        }
    }
}
