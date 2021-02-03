using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;


namespace Ceramics.Models
{
    public class CeramicsContext : DbContext
    {
        public CeramicsContext (DbContextOptions<CeramicsContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Color> Color { get; set; }

        public DbSet<ColorFamily> ColorFamily { get; set; }

        public DbSet<Chemistry> Chemistry { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Color>().ToTable("Color");
            modelBuilder.Entity<ColorFamily>().ToTable("ColorFamily");
            modelBuilder.Entity<Chemistry>().ToTable("Chemistry");
            

        }

    }
}
