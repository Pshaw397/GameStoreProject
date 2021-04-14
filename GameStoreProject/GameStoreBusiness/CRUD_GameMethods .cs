using StoreData;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;
using StoreData.Services;

namespace GameStoreBusiness
{
    public class CRUD_GameMethods
    {
        public Game gameUpdate { get; set; }
        public List<string> developerList = new List<string>();
        public List<string> genreList = new List<string>();
        public IGameServices _services;

        public CRUD_GameMethods(IGameServices services)
        {
            _services = services;
        }
        public CRUD_GameMethods()
        {
            _services = new GameServices();
        }

        public void Create(string name, string description, string coverIMG, decimal price, string publisher, int year, int month, int day)
        {
            Game newGame = new Game() { Name = name, Description = description, CoverImgPath = coverIMG, Price = price, Publisher = publisher, ReleaseDate = new DateTime(year, month, day) };
            _services.CreateGame(newGame);
        }

        public void Delete(string name)
        {
            gameUpdate = _services.GetGameByName(name);
            _services.RemoveGame(gameUpdate);
        }

        public void Update(string nameID, string name, string description, string coverIMG, decimal price, string publisher, int year, int month, int day)
        {
            gameUpdate = _services.GetGameByName(name);
            gameUpdate.Name = name;
            gameUpdate.Description = description;
            gameUpdate.CoverImgPath = coverIMG;
            gameUpdate.ReleaseDate = new DateTime(year, month, day);
            gameUpdate.Price = price;
            gameUpdate.Publisher = publisher;
            _services.SaveGameChanges();
        }

        public List<string> RetrieveAll()
        {
            List<Game> gameList = _services.GetGameList();
            List<string> gameNameList = new List<string>();
            foreach (var item in gameList)
            {
                gameNameList.Add(item.Name);
            }
            return gameNameList;
        }

        public List<string> RetrieveAllLibrary()
        {
            LibraryMethods libraryMethods = new LibraryMethods();
            User selectedUser = libraryMethods.selectedUser();
            return _services.GetLibraryGameList(selectedUser);
        }

        public List<string> RetrieveAllStore(decimal userID)
        {
            LibraryMethods libraryMethods = new LibraryMethods();
            User selectedUser = libraryMethods.selectedUser();
            List<string> gameNameList = new List<string>();
            List<string> PurchasedList = _services.GetLibraryGameList(selectedUser);

            List<Game> gameList = _services.GetGameList();
            foreach (var item in gameList)
            {
                gameNameList.Add(item.Name);
            }
            foreach (var item2 in gameList)
            {
                foreach (var item3 in PurchasedList)
                {
                    if(item2.Name == item3)
                    {
                        gameNameList.Remove(item2.Name);
                    }
                }
            }
            return gameNameList;
        }

        public void SetSelectedGame(string selectedItem)
        {
            developerList.Clear();
            genreList.Clear();
            using (var db = new GameMarketContext())
            {
                gameUpdate = _services.GetGameByName(selectedItem);
                var joinedTablesQuery =
                    from g in db.Games
                    join gd in db.GameDevelopers on g.GameId equals gd.GameId
                    join d in db.Developers on gd.DeveloperId equals d.DeveloperId
                    join gg in db.GameGenres on g.GameId equals gg.GameId
                    join ge in db.Genres on gg.GenreId equals ge.GenreId
                    where gd.GameId == gameUpdate.GameId
                    select new { developerName = d.DeveloperName, genreName = ge.GenreName };

                foreach (var item in joinedTablesQuery)
                {
                    if(developerList.Contains(item.developerName) == false)
                    {
                        developerList.Add(item.developerName);
                    }
                    if (genreList.Contains(item.genreName) == false)
                    {
                        genreList.Add(item.genreName);
                    }
                }
            }
        }
    }
}
