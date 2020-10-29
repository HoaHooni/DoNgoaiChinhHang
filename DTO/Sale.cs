using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sale
    {
        [Key]
        public Guid SaleID { get; set; }
        public Guid ProductID { get; set; }
        public int Mode { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int Percent { get; set; }
        public int PriceOrigin { get; set; }
        public int PriceSale { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
