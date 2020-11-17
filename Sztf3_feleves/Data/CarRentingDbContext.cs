using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class CarRentingDbContext : DbContext
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> opt) : base(opt)
        {

        }

        public CarRentingDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\CarRentingDB.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Renters>(entity =>
            {
                entity
                .HasOne(Renters => Renters.Car)
                .WithOne(Cars => Cars.Renter)
                .HasForeignKey<Cars>(Cars => Cars.RenterId);
            });

            modelbuilder.Entity<Cars>(entity =>
            {
                entity
                .HasOne(Cars => Cars.Salon)
                .WithMany(Salons => Salons.Car)
                .HasForeignKey(Cars => Cars.SalonId);
            });
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Renters> Renters { get; set; }
        public DbSet<Salons> Salons { get; set; }
    }
}
