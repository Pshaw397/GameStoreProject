using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class GameGenre
    {
        public int GameID { get; set; }
        public int GenreID { get; set; }
        public virtual Game Game { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
