using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryOfProduct
    {
        [Key]
        public Guid CategoryOfProductID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid ProductID { get; set; }
    }
}
