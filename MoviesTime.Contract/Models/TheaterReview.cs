using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.Models
{
    public class TheaterReview
    {
        [Key]
        public int ReviewID { get; set; }
        public Theaters TheaterID { get; set; }
        public byte Rating { get; set; }
        public string? ReviewMessage { get; set; }
        public DateTime ReviewedAt { get; set; }
        public int? EditedFromReviewID { get; set; }
        public Users RegisteredUserID { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
