using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData
{
    public partial class Genre
    {
        public Genre()
        {
            GameGenres = new HashSet<GameGenre>();
        }

        public decimal GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; }
    }
}
