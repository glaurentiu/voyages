using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Voyage> Voyages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Port>()
                .HasOne(p => p.Country)
                .WithMany(c => c.Ports)
                .HasForeignKey(p => p.CountryId);

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.Ship)
                .WithMany(s => s.Voyages)
                .HasForeignKey(v => v.ShipId);

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.DeparturePort)
                .WithMany(p => p.DepartingVoyages)
                .HasForeignKey(v => v.DeparturePortId);

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.ArrivalPort)
                .WithMany(p => p.ArrivingVoyages)
                .HasForeignKey(v => v.ArrivalPortId);
        }
    }
}
