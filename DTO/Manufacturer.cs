using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Manufacturer
    {
        [Key]
        public Guid ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
    }
}
