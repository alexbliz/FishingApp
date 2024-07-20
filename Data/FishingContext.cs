using Microsoft.EntityFrameworkCore;
using FishingApp.Models;

namespace FishingApp.Data
{
    public class FishingContext : DbContext
    {
        public FishingContext(DbContextOptions<FishingContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Catch> Catches { get; set; }
        public DbSet<FishingMethod> FishingMethods { get; set; }
        public DbSet<FishType> FishTypes { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Catch>().ToTable("Catches");
            modelBuilder.Entity<FishingMethod>().ToTable("FishingMethods");
            modelBuilder.Entity<FishType>().ToTable("FishTypes");
            modelBuilder.Entity<Location>().ToTable("Locations");

            modelBuilder.Entity<Catch>()
                .HasKey(c => c.CatchID);

            modelBuilder.Entity<Catch>()
                .HasOne(c => c.User)
                .WithMany(u => u.Catches)
                .HasForeignKey(c => c.UserID);

            modelBuilder.Entity<Catch>()
                .HasOne(c => c.FishingMethod)
                .WithMany(fm => fm.Catches)
                .HasForeignKey(c => c.FishingMethodID);

            modelBuilder.Entity<Catch>()
                .HasOne(c => c.FishType)
                .WithMany(ft => ft.Catches)
                .HasForeignKey(c => c.FishTypeID);
        }
    }
}
