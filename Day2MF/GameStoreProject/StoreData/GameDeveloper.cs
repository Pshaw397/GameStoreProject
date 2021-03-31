using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class GameDeveloper
    {
        public int GameID { get; set; }
        public int DeveloperID { get; set; }
        public virtual Developer developer { get; set; }
        public virtual Game game { get; set; }
    }
}
