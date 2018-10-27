using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest
{
    public class MyDbContext : DbContext
    {
        public ConnectionStringSettings ConnectionStringSetting { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<TourEntity> Tours { get; set; }

        public DbSet<HotelEntity> Hotels { get; set; }

        public MyDbContext() :
            base()
        {
            ConnectionStringSetting = ConfigurationManager.ConnectionStrings["MyDbContext"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .ToTable("ProductEntity");

            modelBuilder.Entity<TourEntity>()
                .ToTable("TourEntity");

            modelBuilder.Entity<HotelEntity>()
                .ToTable("HotelEntity");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringSetting.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
