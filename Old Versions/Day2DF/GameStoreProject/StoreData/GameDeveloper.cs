using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData
{
    public partial class GameDeveloper
    {
        public decimal? GameId { get; set; }
        public decimal? DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Game Game { get; set; }
    }
}
