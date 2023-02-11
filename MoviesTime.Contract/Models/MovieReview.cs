using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.Models
{
    public class MovieReview
    {
        [Key]
        public int ReviewID { get; set; }
        public Movies Movies { get; set; }
        public byte MovieRating { get; set; }
        public String? ReviewMessage { get; set; }
        public Users Users { get; set; }
        public DateTime ReviewedAt { get; set; }
        public int? EditedFromReviewID { get; set; }
        public bool IsAnonymous { get; set; }
        
        // business rule - If a User edits their review, It will create a new table entry and mark previous entry to isDeleted = true 
        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}
