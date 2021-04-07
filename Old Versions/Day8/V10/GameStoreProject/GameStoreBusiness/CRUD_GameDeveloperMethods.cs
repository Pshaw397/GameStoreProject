using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameStoreBusiness
{
    public class CRUD_GameDeveloperMethods
    {
        public GameDeveloper gameDevUpdate { get; set; }

        public void Create(int gameID, int devID)
        {
            GameDeveloper newGameDev = new GameDeveloper() { GameId = gameID, DeveloperId = devID};
            using (var db = new GameMarketContext())
            {
                db.GameDevelopers.Add(newGameDev);
                db.SaveChanges();
            }
        }

        public void Delete(int gameId)
        {
            using (var db = new GameMarketContext())
            {
                gameDevUpdate = db.GameDevelopers.Where(c => c.GameId == gameId).FirstOrDefault();
                db.GameDevelopers.Remove(gameDevUpdate);
                db.SaveChanges();
            }
        }

        public void Update(decimal gameID, decimal devID, decimal newdevID)
        {
            using (var db = new GameMarketContext())
            {
                var selectedGDRef = db.GameDevelopers.Where(g => g.DeveloperId == devID && g.GameId == gameID).FirstOrDefault();
                db.GameDevelopers.Remove(selectedGDRef);
                GameDeveloper updatedGameDev = new GameDeveloper()
                {
                    GameId = gameID,
                    DeveloperId = newdevID
                };
                db.GameDevelopers.Add(updatedGameDev);
                // write changes to database
                db.SaveChanges();
            }
        }
    }
}
