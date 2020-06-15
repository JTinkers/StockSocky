﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockSockyService.Data.Contexts;

namespace StockSockyService.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20200615180547_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("StockSockyService.Data.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StockId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Quantity = 15,
                            StockId = 1,
                            Value = 1.45
                        },
                        new
                        {
                            Id = 2,
                            Quantity = 5,
                            StockId = 1,
                            Value = 1.8999999999999999
                        },
                        new
                        {
                            Id = 3,
                            Quantity = 26,
                            StockId = 2,
                            Value = 2.0
                        });
                });

            modelBuilder.Entity("StockSockyService.Data.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Symbol = "HTZ"
                        },
                        new
                        {
                            Id = 2,
                            Symbol = "AAA"
                        },
                        new
                        {
                            Id = 3,
                            Symbol = "OAS"
                        });
                });

            modelBuilder.Entity("StockSockyService.Data.Models.Purchase", b =>
                {
                    b.HasOne("StockSockyService.Data.Models.Stock", "Stock")
                        .WithMany("Purchases")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
