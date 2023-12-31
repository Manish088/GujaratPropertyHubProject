
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyEntity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Country> country { get; set; }
        public DbSet<State> state { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<AreaOfCity> areaOfCity { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<SubCategory> subCategory { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<House> house { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>()
            .HasOne(c => c.Country)
            .WithMany()
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<House>()
                .HasOne(h => h.State)
                .WithMany()
                .HasForeignKey(h => h.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<House>()
                .HasOne(h => h.City)
                .WithMany()
                .HasForeignKey(h => h.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<House>()
                .HasOne(h => h.AreaOfCity)
                .WithMany()
                .HasForeignKey(h => h.AreaOfCityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<House>()
                .HasOne(h => h.Category)
                .WithMany()
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<House>()
                .HasOne(h => h.SubCategory)
                .WithMany()
                .HasForeignKey(h => h.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<House>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
            

    }
}
