using asp_b_heroesCrud.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace asp_b_heroesCrud.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> o) : base(o) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>().HasData(
                new Comic { Id = 1, Name = "Marvel" },
                new Comic { Id = 2, Name = "DC" }
            );

            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    HeroName = "Spiderman",
                    ComicId = 1,
                },
                new SuperHero
                {
                    Id = 2,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    HeroName = "Batman",
                    ComicId = 2
                }
            );
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Comic> Comics { get; set; }
    }
}
