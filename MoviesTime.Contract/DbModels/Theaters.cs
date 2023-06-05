using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.DbModels
{
    public class Theaters
    {
        [Key]
        public int TheaterID { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public String TheaterName { get; set; }

        [ForeignKey("ManagerID")]
        public Users Users { get; set; }
        public int ManagerID { get; set; }
        
        public string? TheaterContact { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
