using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData
{
    public partial class Game
    {
        public Game()
        {
            GameDevelopers = new HashSet<GameDeveloper>();
            GameGenres = new HashSet<GameGenre>();
            Purchases = new HashSet<Purchase>();
        }

        public decimal GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImgPath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public string Publisher { get; set; }

        public virtual ICollection<GameDeveloper> GameDevelopers { get; set; }
        public virtual ICollection<GameGenre> GameGenres { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
