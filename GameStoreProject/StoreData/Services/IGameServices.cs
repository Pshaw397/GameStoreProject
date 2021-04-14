using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Services
{
    public interface IGameServices
    {
        public void CreateGame(Game g);
        public Game GetGameByName(string gameName);
        public List<Game> GetGameList();
        public List<string> GetLibraryGameList(User u);
        public void SaveGameChanges();
        public void RemoveGame(Game g);
    }
}
