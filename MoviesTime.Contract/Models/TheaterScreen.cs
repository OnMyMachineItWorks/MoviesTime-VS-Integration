using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.Models
{
    public class TheaterScreen
    {
        [Key]
        public int ScreenID { get; set; }
        public String ScreenName { get; set; }
        public Theaters TheaterID { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}
