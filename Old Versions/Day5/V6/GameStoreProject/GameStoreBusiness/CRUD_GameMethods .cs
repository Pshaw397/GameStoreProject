using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_GameMethods
    {
        public Game gameUpdate { get; set; }
        public List<string> developerList = new List<string>();
        public List<string> genreList = new List<string>();

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

        public List<string> RetrieveAll()
        {
            using (var db = new GameMarketContext())
            {
                var gameNamesQuery = db.Games.ToList();
                List<string> gameNameList = new List<string>();
                foreach (var item in gameNamesQuery)
                {
                    gameNameList.Add(item.Name);
                }
                return gameNameList;
            }
        }

        public List<string> RetrieveAllLibrary()
        {
            using (var db = new GameMarketContext())
            {
                var joinedPurchaseTablesQuery =
                    from p in db.Purchases
                    join g in db.Games on p.GameId equals g.GameId
                    join u in db.Users on p.UserId equals u.UserId
                    where p.UserId == u.UserId
                    select new { gameName = g.Name };

                List<string> gameNameList = new List<string>();
                foreach (var item in joinedPurchaseTablesQuery)
                {
                    gameNameList.Add(item.gameName);
                }
                return gameNameList;
            }
        }

        public void SetSelectedGame(string selectedItem)
        {
            developerList.Clear();
            genreList.Clear();
            using (var db = new GameMarketContext())
            {
                gameUpdate = db.Games.Where(g => g.Name == selectedItem).FirstOrDefault();
                var joinedDeveloperTablesQuery =
                    from g in db.Games
                    join gd in db.GameDevelopers on g.GameId equals gd.GameId
                    join d in db.Developers on gd.DeveloperId equals d.DeveloperId
                    where gd.GameId == gameUpdate.GameId
                    select new { developerName = d.DeveloperName };

                foreach (var item in joinedDeveloperTablesQuery)
                {
                    developerList.Add(item.developerName);
                }

                var joinedGenreTableQuery =
                    from g in db.Games
                    join gg in db.GameGenres on g.GameId equals gg.GameId
                    join ge in db.Genres on gg.GenreId equals ge.GenreId
                    where gg.GameId == gameUpdate.GameId
                    select new { genreName = ge.GenreName };

                foreach (var item in joinedGenreTableQuery)
                {
                    genreList.Add(item.genreName);
                }
            }
        }
    }
}
