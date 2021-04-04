using System;
using System.Collections.Generic;

#nullable disable

namespace StoreData
{
    public partial class Developer
    {
        public Developer()
        {
            GameDevelopers = new HashSet<GameDeveloper>();
        }

        public decimal DeveloperId { get; set; }
        public string DeveloperName { get; set; }

        public virtual ICollection<GameDeveloper> GameDevelopers { get; set; }
    }
}
