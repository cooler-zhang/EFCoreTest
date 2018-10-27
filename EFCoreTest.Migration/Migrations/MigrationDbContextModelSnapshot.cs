using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCoreTest.Migration;
using EFCoreTest;

namespace EFCoreTest.Migration.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    partial class MigrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreTest.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("ProductEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProductEntity");
                });

            modelBuilder.Entity("EFCoreTest.HotelEntity", b =>
                {
                    b.HasBaseType("EFCoreTest.ProductEntity");

                    b.Property<int>("Level");

                    b.ToTable("HotelEntity");

                    b.HasDiscriminator().HasValue("HotelEntity");
                });

            modelBuilder.Entity("EFCoreTest.TourEntity", b =>
                {
                    b.HasBaseType("EFCoreTest.ProductEntity");

                    b.Property<DateTime>("BeginDate");

                    b.Property<DateTime>("EndDate");

                    b.ToTable("TourEntity");

                    b.HasDiscriminator().HasValue("TourEntity");
                });
        }
    }
}
