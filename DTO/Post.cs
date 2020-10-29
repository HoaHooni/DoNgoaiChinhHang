using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Post
    {
        [Key]
        public Guid PostID { get; set; }
        public string PostName { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public string RelatedPosts { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
    }
}
