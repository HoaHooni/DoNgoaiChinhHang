using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Gift
    {
        [Key]
        public Guid GiftID { get; set; }
        public Guid ProductID { get; set; }
        public Guid ProductGiftID { get; set; }
        public int Quantity { get; set; }

    }
}
