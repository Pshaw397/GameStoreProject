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
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GameStore;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDeveloper>(entity =>
            {
                entity.HasKey(gd => new { gd.GameID, gd.DeveloperID });
                modelBuilder.Entity<GameDeveloper>()
                    .HasOne<Developer>(gd => gd.developer)
                    .WithMany(d => d.GameDevelopers)
                    .HasForeignKey(gd => gd.GameID);
                modelBuilder.Entity<GameDeveloper>()
                    .HasOne<Game>(gd => gd.game)
                    .WithMany(g => g.gameDevelopers)
                    .HasForeignKey(d => d.DeveloperID);
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(gg => new { gg.GameID, gg.GenreID });
                modelBuilder.Entity<GameGenre>()
                    .HasOne<Genre>(ge => ge.Genre)
                    .WithMany(gg => gg.gameGenres)
                    .HasForeignKey(gg => gg.GameID);
                modelBuilder.Entity<GameGenre>()
                    .HasOne<Game>(gg => gg.Game)
                    .WithMany(ga => ga.gameGenres)
                    .HasForeignKey(ga => ga.GenreID);
            });
        }
    }
}
