using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News21.Models
{
    public class NewsCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public virtual ICollection<NewsInfo> CategoryNews { get; set; }
    }
}
