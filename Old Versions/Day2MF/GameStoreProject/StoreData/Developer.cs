using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData
{
    public class Developer
    {
        public Developer()
        {
            GameDevelopers = new HashSet<GameDeveloper>();
        }
        public int DeveloperID { get; set; }
        public string DeveloperName { get; set; }
        public virtual ICollection<GameDeveloper> GameDevelopers { get; set; }
    }
}
