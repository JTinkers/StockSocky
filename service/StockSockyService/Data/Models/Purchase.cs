using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockSockyService.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public int StockId { get; set; }

        public int Quantity { get; set; }

        public double Value { get; set; }

        public virtual double Total => Value * Quantity;
    }
}
