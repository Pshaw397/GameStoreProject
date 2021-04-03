using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreData
{
    public partial class GameStoreContext : DbContext
    {
        public static GameStoreContext Instance { get; } = new GameStoreContext();

        // The DbSet is the line that allows us to change and retrive the data within the different tables in the database
        public DbSet<Game> Customers { get; set; }
        public DbSet<User> Orders { get; set; }
        public DbSet<Purchase> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GameStore;");
            }
        }



    }
}
