using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreData
{
    public partial class GameMarketContext : DbContext
    {
        public GameMarketContext()
        {
        }

        public GameMarketContext(DbContextOptions<GameMarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameDeveloper> GameDevelopers { get; set; }
        public virtual DbSet<GameGenre> GameGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameMarket;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.ToTable("Developer");

                entity.Property(e => e.DeveloperId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("developerID");

                entity.Property(e => e.DeveloperName)
                    .IsUnicode(false)
                    .HasColumnName("developerName");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.GameId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("gameID");

                entity.Property(e => e.CoverImgPath)
                    .IsUnicode(false)
                    .HasColumnName("coverIMG_Path");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("publisher");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("releaseDate");
            });

            modelBuilder.Entity<GameDeveloper>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.DeveloperId });

                entity.ToTable("GameDeveloper");

                entity.Property(e => e.GameId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("gameID");

                entity.Property(e => e.DeveloperId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("developerID");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.GameDevelopers)
                    .HasForeignKey(d => d.DeveloperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameDevel__devel__35BCFE0A");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameDevelopers)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameDevel__gameI__36B12243");
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.GenreId })
                    .IsClustered(false);

                entity.ToTable("GameGenre");

                entity.Property(e => e.GameId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("gameID");

                entity.Property(e => e.GenreId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("genreID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameGenres)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameGenre__gameI__3C69FB99");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GameGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameGenre__genre__3D5E1FD2");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("genreID");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("genreName");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");

                entity.Property(e => e.PurchaseId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("purchaseID");

                entity.Property(e => e.GameId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("gameID");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("purchaseDate");

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Purchase__gameID__2A4B4B5E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Purchase__userID__29572725");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("fullName");

                entity.Property(e => e.Region)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("region");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Wallet)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("wallet");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
