using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData
{
    public partial class GameGenre
    {
        public decimal GameId { get; set; }
        public decimal GenreId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
