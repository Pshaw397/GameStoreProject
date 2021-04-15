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
            gameUpdate = _services.GetGameByName(selectedItem);
            _services.SelectedGame(developerList, genreList, gameUpdate);
        }
    }
}
