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

        public string Name { get; set; }

        public string Symbol { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public virtual int? Quantity => Purchases?.Sum(x => x.Quantity);

        public virtual double? InvestedValue => Purchases?.Sum(x => x.Total);
    }
}
