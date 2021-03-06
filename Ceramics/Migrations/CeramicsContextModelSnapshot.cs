﻿// <auto-generated />
using System;
using Ceramics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ceramics.Migrations
{
    [DbContext(typeof(CeramicsContext))]
    partial class CeramicsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ceramics.Models.Chem", b =>
                {
                    b.Property<int>("ChemID");

                    b.Property<string>("ChemAbbrev")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ChemComp")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ColorID");

                    b.Property<int>("WarehouseLocationID");

                    b.Property<int?>("WarehouseLocationID1");

                    b.HasKey("ChemID");

                    b.HasIndex("WarehouseLocationID1");

                    b.ToTable("Chemistry");
                });

            modelBuilder.Entity("Ceramics.Models.Color", b =>
                {
                    b.Property<int>("ColorID");

                    b.Property<int>("ColorFamID");

                    b.Property<string>("ColorFamName");

                    b.Property<string>("ColorName")
                        .HasMaxLength(50);

                    b.Property<double>("Price");

                    b.HasKey("ColorID");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Ceramics.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Ceramics.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorID");

                    b.Property<int>("CustomerID");

                    b.Property<int?>("MembershipStat");

                    b.HasKey("OrderID");

                    b.HasIndex("ColorID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Ceramics.Pages.Models.WarehouseLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChemID");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.Property<int>("WarehouseLocationID");

                    b.HasKey("ID");

                    b.ToTable("WarehouseLocation");
                });

            modelBuilder.Entity("Ceramics.Models.Chem", b =>
                {
                    b.HasOne("Ceramics.Pages.Models.WarehouseLocation", "WarehouseLocation")
                        .WithMany()
                        .HasForeignKey("WarehouseLocationID1");
                });

            modelBuilder.Entity("Ceramics.Models.Order", b =>
                {
                    b.HasOne("Ceramics.Models.Color", "Color")
                        .WithMany("Orders")
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ceramics.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
