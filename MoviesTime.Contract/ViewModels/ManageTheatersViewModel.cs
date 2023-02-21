using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.ViewModels
{
    public class ManageTheatersViewModel
    {
        public List<Theaters>? lstTheaters { get; set; }
        public IEnumerable<SelectListItem>? UsersList { get; set; }

    }
}
