using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.Models
{
    public class MovieLanguageMapping
    {
        public int ID { get; set; }
        public Languages LanguageID { get; set; }
        public Movies MovieID { get; set; }
        public bool IsActive { get; set; }
    }
}
