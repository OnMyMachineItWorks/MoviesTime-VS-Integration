﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.Contract.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.ViewModels;

public class ManageTheaterScreensViewModel 
{
    public int selectedTheaterID { get; set; }
    public List<TheaterScreen>? theaterScreensList { get; set; }
    public List<SelectListItem>? selectTheaterList { get; set; }
    public TheaterScreen theaterScreen { get; set; }
    public bool isEditMode { get; set; }
}
