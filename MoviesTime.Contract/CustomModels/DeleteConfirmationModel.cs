﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.CustomModels
{
    public class DeleteConfirmationModel
    {
        public string EntityName { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string EntityDataID { get; set; }
        public int ID { get; set; }

    }
}
