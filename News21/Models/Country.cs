using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News21.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        public virtual ICollection<NewsInfo> CountryNews { get; set; }
    }
}
