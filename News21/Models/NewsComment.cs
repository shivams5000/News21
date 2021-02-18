using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News21.Models
{
    public class NewsComment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        [StringLength(1000)]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        [Required]
        [StringLength(100)]
        public string ReviewerName { get; set; }

        [Required]
        public int NewsID { get; set; }

        public NewsInfo News { get; set; }
    }
}
