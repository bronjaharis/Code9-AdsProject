using Code9_AdsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Code9_AdsProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AdType> AdTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Types of the Ad
            modelBuilder.Entity<AdType>()
            .HasData(
                new AdType { Id = 1, Name = "Basic" },
                new AdType { Id = 2, Name = "Premium" },
                new AdType { Id = 3, Name = "Gold" }
            );

            // Categories
            modelBuilder.Entity<Category>()
            .HasData(
                new Category { Id = 1, Name = "Automobili i delovi" },
                new Category { Id = 2, Name = "Motorcikli i bicikli" },
                new Category { Id = 3, Name = "Kamioni i autobusi" },
                new Category { Id = 4, Name = "Poljoprivreda" },
                new Category { Id = 5, Name = "Mobilni telefoni" },
                new Category { Id = 6, Name = "Nekretnine" },
                new Category { Id = 7, Name = "Kuća i bašta" },
                new Category { Id = 8, Name = "Garderoba" },
                new Category { Id = 9, Name = "Zdravstvo" },
                new Category { Id = 10, Name = "Sport" },
                new Category { Id = 11, Name = "Knjige" },
                new Category { Id = 12, Name = "Kućni ljubimci" },
                new Category { Id = 13, Name = "Posao" },
                new Category { Id = 14, Name = "Razno" },
                new Category { Id = 15, Name = "Umetnička dela" }
            );
        }
    }
}
