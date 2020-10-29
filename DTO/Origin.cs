using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Origin
    {
        [Key]
        public Guid OriginID { get; set; }
        public string OriginName { get; set; }
    }
}
