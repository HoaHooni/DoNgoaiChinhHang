using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Rate
    {
        [Key]
        public Guid RateID { get; set; }
        public Nullable<Guid> ProductID { get; set; }
        public Nullable<Guid> PostID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public int Rank { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
