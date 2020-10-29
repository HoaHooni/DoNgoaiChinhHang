using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsParent { get; set; }
        public Nullable<Guid> CategoryParentID { get; set; }
        public string CategoryCode { get; set; }
    }
}
