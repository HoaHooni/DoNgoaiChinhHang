using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string Note { get; set; }
        public bool IsHidden { get; set; }
        public int PayMethod { get; set; }
        public DateTime CreatedDate { get; set; }
        public int State { get; set; }
        public DateTime CompletedDate { get; set; }
        public string OrderCode { get; set; }
    }
}
