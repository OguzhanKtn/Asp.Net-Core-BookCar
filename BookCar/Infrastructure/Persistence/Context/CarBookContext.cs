﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer("Server = .; initial Catalog=CarBook; integrated security = true;trustservercertificate=true");
        }

        public DbSet<About> abouts { get; set; }
        public DbSet<Banner> banners { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<CarDescription> carDescriptions { get; set; }
        public DbSet<CarFeature> carFeatures { get; set; }
        public DbSet<CarPricing> carPricings { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Feature> features { get; set; }
        public DbSet<FooterAdress> footerAdresses { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Pricing> pricings { get; set; }
        public DbSet<Service> servces { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
    }
}