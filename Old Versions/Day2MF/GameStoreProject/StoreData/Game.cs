using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreData
{
    public partial class Game
    {
        public Game()
        {
            gameGenres = new HashSet<GameGenre>();
            gameDevelopers = new HashSet<GameDeveloper>();
        }
        // Games = Order Details
        public int GameID { get; set; } // The GameIDs for each game are created here, meaning that each GameID appears only once, otherwise you would have duplicate games which in this table is uneccessary and not wanted
        // This means that Game and Purchases have a 1 to Many relationship as each GameID can appear many times in purchases as each game can be bought many different times
        public string Name { get; set; }
        public string Descrption { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string coverIMG_Path { get; set; }
        public double Price { get; set; }
        public virtual Purchase Purchases { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<GameGenre> gameGenres { get; set; }
        public virtual ICollection<GameDeveloper> gameDevelopers { get; set; }
    }
}