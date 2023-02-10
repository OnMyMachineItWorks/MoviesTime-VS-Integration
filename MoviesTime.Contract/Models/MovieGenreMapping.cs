using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.Models
{
    public class MovieGenreMapping
    {
        public int ID { get; set; }
        public Movies MovieID { get; set; }
        public Genres Genre { get; set; }
        public bool IsActive { get; set; }
    }
}
