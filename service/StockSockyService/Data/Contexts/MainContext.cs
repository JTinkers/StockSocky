using Microsoft.EntityFrameworkCore;
using StockSockyService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace StockSockyService.Data.Contexts
{
    public class MainContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Database.db");

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasData(new Stock
                {
                    Id = 1,
                    Symbol = "HTZ"
                });

            modelBuilder.Entity<Stock>()
                .HasData(new Stock
                {
                    Id = 2,
                    Symbol = "AAA"
                });

            modelBuilder.Entity<Stock>()
                .HasData(new Stock
                {
                    Id = 3,
                    Symbol = "OAS"
                });

            modelBuilder.Entity<Purchase>()
                .HasData(new Purchase
                {
                    Id = 1,
                    Quantity = 15,
                    Value = 1.45,
                    StockId = 1
                });            
            
            modelBuilder.Entity<Purchase>()
                .HasData(new Purchase
                {
                    Id = 2,
                    Quantity = 5,
                    Value = 1.9,
                    StockId = 1
                });            
            
            modelBuilder.Entity<Purchase>()
                .HasData(new Purchase
                {
                    Id = 3,
                    Quantity = 26,
                    Value = 2,
                    StockId = 2
                });
        }
    }
}
