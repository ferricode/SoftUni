using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace BusStation.Data
{
    public class BusStationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BusStation;User Id=sa;Password=SoftUniJojoba;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                         .HasIndex(u => u.Username)
                         .IsUnique();

            modelBuilder.Entity<User>()
                     .HasIndex(u => u.Email)
                     .IsUnique();
        }
       public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
