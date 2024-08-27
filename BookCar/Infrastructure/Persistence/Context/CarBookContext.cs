using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CarBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server = .; initial Catalog=CarBook; integrated security = true;trustservercertificate=true")
                .EnableSensitiveDataLogging()
                   .LogTo(Console.WriteLine, LogLevel.Information);
        }
        public DbSet<AppUser> users { get; set; }
        public DbSet<AppRole> roles { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Banner> banners { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<CarDescription> carDescriptions { get; set; }
        public DbSet<CarFeature> carFeatures { get; set; }
        public DbSet<CarPricing> carPricings { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Feature> features { get; set; }
        public DbSet<FooterAdress> footerAdresses { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Pricing> pricings { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
        public DbSet<RentACar> rentACars { get; set; }
        public DbSet<RentACarProcess> rentACarProcesses { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Reservation> reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(y => y.PickUpReservation)
                .HasForeignKey(z => z.PickUpLocationID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(y => y.DropOffReservation)
                .HasForeignKey(z => z.DropOffLocationID)
                .OnDelete(DeleteBehavior.ClientSetNull);          
        }

    }
}
