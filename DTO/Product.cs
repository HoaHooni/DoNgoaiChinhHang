using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int NumPurchased { get; set; }
        public int Ship { get; set; }
        public Guid ManufacturerID { get; set; }
        public Guid OriginID { get; set; }
        public string Content { get; set; }
        public bool IsSale { get; set; }
        public int AmountSale { get; set; }
        public int QuantitySale { get; set; }

    }
}
