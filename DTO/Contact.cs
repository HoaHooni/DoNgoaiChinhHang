using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Contact
    {
        [Key]
        public Guid ID { get; set; }
        public string ContactName { get; set; }
        public string Hotline { get; set; }
        public string Addressh { get; set; }
        public string WarehouseAddress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
