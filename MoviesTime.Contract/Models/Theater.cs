﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.Models
{
    public class Theater
    {
        public int TheaterID { get; set; }
        public int TheaterName { get; set; }
        public Users ManagerID { get; set; }
        public string? TheaterContact { get; set; }
        public bool IsActive { get; set; }
    }
}
