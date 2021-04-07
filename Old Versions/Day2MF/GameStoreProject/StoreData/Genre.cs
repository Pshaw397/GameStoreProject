using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class Genre
    {
        public Genre()
        {
            gameGenres = new HashSet<GameGenre>();
        }
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public ICollection<GameGenre> gameGenres { get; set; }
    }
}
