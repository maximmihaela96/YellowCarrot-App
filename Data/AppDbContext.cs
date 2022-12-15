using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot_App.Models;

namespace YellowCarrot_App.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingrediens> Ingredience { get; set; }
        public DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YellowCarrotDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingrediences)
                .WithOne(i => i.Recipe);

            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId = 1,
                UserNamn = "user",
                Password = "password"
            });
            modelBuilder.Entity<Tags>().HasData(new Tags()
            {
                TagName = "Desert"
            });
            modelBuilder.Entity<Tags>().HasData(new Tags()
            {
                TagName = "Pasta"
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe()
            {
                RecipeId = 1,
                RecipeName = "Muffins",
                TagName = "Desert"
            });

            modelBuilder.Entity<Ingrediens>().HasData(new Ingrediens()
            {
                IngrediensId = 1,
                IngrediensNamn = "Mjol",
                Unit = "gram",
                Quantity = 500,
                RecipeId = 1
            }, new Ingrediens()
            {
                IngrediensId = 2,
                IngrediensNamn = "Kakao",
                Unit = "gram",
                Quantity = 100,
                RecipeId = 1
            });
        }
    }
}
