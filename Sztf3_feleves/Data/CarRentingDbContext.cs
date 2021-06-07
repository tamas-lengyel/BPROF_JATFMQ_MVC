using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class CarRentingDbContext : IdentityDbContext<IdentityUser>
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
                    UseSqlServer(@"Server=tcp:carrenting.database.windows.net,1433;Initial Catalog=CarRentingDB;Persist Security Info=False;User ID=dbadmin;Password=Passw0rd;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", x => x.MigrationsAssembly("ApiEndpoint"));
                    //UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\CarRentingDB.mdf;integrated security=True;MultipleActiveResultSets=True");
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
                .HasForeignKey(Cars => Cars.SalonId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            /*** Authentication ***/
            modelbuilder.Entity<IdentityRole>().HasData(
                 new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" }
             );

            var appUser = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                SecurityStamp = string.Empty
            };

            appUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin123");

            modelbuilder.Entity<IdentityUser>().HasData(appUser);

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
            });
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Renters> Renters { get; set; }
        public DbSet<Salons> Salons { get; set; }
    }
}
