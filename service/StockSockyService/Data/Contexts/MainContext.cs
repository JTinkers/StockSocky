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
            => options.UseLazyLoadingProxies(true)
                .UseSqlite("Data Source=Database.db");

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
