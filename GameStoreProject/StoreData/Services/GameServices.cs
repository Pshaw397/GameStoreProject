using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Services
{
    public class GameServices : IGameServices
    {
        private readonly GameMarketContext _context;

        public GameServices(GameMarketContext context)
        {
            _context = context;
        }
        public GameServices()
        {
            _context = new GameMarketContext();
        }

        public void CreateGame(Game c)
        {
            _context.Games.Add(c);
            _context.SaveChanges();
        }

        public Game GetGameByName(string gameName)
        {
           return _context.Games.Where(g => g.Name == gameName).FirstOrDefault();
        }

        public List<Game> GetGameList()
        {
            return _context.Games.ToList();
        }

        public List<string> GetLibraryGameList(User u)
        {
            var joinedPurchaseTablesQuery =
                from p in _context.Purchases
                join g in _context.Games on p.GameId equals g.GameId
                where p.UserId == u.UserId
                select new { gameName = g.Name };

            List<string> gameNameList = new List<string>();
            foreach (var item in joinedPurchaseTablesQuery)
            {
                gameNameList.Add(item.gameName);
            }
            return gameNameList;
        }

        public void RemoveGame(Game c)
        {
            _context.Games.Remove(c);
            _context.SaveChanges();
        }

        public void SaveGameChanges()
        {
            _context.SaveChanges();
        }

        public void SelectedGame(List<string> devList, List<string> genreList, Game Selected)
        {
            var joinedTablesQuery =
                from g in _context.Games
                join gd in _context.GameDevelopers on g.GameId equals gd.GameId
                join d in _context.Developers on gd.DeveloperId equals d.DeveloperId
                join gg in _context.GameGenres on g.GameId equals gg.GameId
                join ge in _context.Genres on gg.GenreId equals ge.GenreId
                where gd.GameId == Selected.GameId
                select new { developerName = d.DeveloperName, genreName = ge.GenreName };

            foreach (var item in joinedTablesQuery)
            {
                if (devList.Contains(item.developerName) == false)
                {
                    devList.Add(item.developerName);
                }
                if (genreList.Contains(item.genreName) == false)
                {
                    genreList.Add(item.genreName);
                }
            }
        }
    }
}
