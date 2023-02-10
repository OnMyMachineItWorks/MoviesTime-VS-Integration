using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.Models
{
    public class Genres
    {
        public int ID { get; set; }
        public string GenreName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
