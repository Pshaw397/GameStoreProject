using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_GameGenreMethods
    {
        public GameGenre gameGenreUpdate { get; set; }

        public void Create(int gameID, int genreID)
        {
            GameGenre newGameGenre = new GameGenre() { GameId = gameID, GenreId = genreID};
            using (var db = new GameMarketContext())
            {
                db.GameGenres.Add(newGameGenre);
                db.SaveChanges();
            }
        }

        public void Delete(int gameId)
        {
            using (var db = new GameMarketContext())
            {
                gameGenreUpdate = db.GameGenres.Where(c => c.GameId == gameId).FirstOrDefault();
                db.GameGenres.Remove(gameGenreUpdate);
                db.SaveChanges();
            }
        }

        public void Update(int gameID, int genreID, int newGenreID)//, string genreName, string gameName)
        {
            using (var db = new GameMarketContext())
            {
                //var genreUpdateQuery =
                //    from ge in db.Genres
                //    join gg in db.GameGenres on ge.GenreId equals gg.GenreId
                //    join g in db.Games on gg.GameId equals g.GameId
                //    where g.Name == gameName && ge.GenreName == genreName
                //    select new { gameID = gg.GameId, genreID = gg.GenreId };

                var selectedGDRef = db.GameGenres.Where(g => g.GenreId == genreID && g.GameId == gameID).FirstOrDefault();
                db.GameGenres.Remove(selectedGDRef);
                GameGenre updatedGameGenre = new GameGenre()
                {
                    GameId = gameID,
                    GenreId = newGenreID
                };
                db.GameGenres.Add(updatedGameGenre);
                // write changes to database
                db.SaveChanges();
            }
        }
    }
}
