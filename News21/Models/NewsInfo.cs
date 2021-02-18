using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News21.Models
{
    public class NewsInfo
    {
        [Key]
        public int NewsID { get; set; }

        [Required]
        [StringLength(200)]
        public string NewsTitle { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }


        [Required]
        public int CountryID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CountryID")]
        [InverseProperty("CountryNews")]
        public virtual Country Country { get; set; }

        [ForeignKey("CategoryID")]
        [InverseProperty("CategoryNews")]
        public virtual NewsCategory NewsCategory { get; set; }

        public virtual ICollection<NewsComment> NewsComments { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }
    }

    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
