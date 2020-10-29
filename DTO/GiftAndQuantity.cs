using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiftAndQuantity
    {
        public Guid GiftID { get; set; }
        public Product Gift { get; set; }
        public int Quantity { get; set; }
    }
}
