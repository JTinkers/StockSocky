using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StockSockyService.Data.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public string Symbol { get; set; }

        public virtual List<Purchase> Purchases { get; set; }

        [NotMapped]
        public virtual int Quantity => Purchases.Sum(x => x.Quantity);

        [NotMapped]
        public virtual double InvestedValue => Purchases.Sum(x => x.Total);

        [NotMapped]
        public virtual double MarketValue { get; set; }

        [NotMapped]
        public virtual double EstimatedProfit => MarketValue - InvestedValue;
    }
}
