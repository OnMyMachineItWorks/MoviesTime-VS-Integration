using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.Contract.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.ViewModels;

public class ManageMoviesViewModel
{
    public int MyProperty { get; set; }
    public Movies movieDetails { get; set; }
    public List<Movies> moviesList { get; set; }
    public List<Genres> genreList { get; set; }
    public List<SelectCheckList>? selectedGenre { get; set; }
    public List<Languages> languageList { get; set; }
    public List<SelectCheckList>? selectedLanguages { get; set; }
    public bool isMovieEditMode { get; set; }
}

public class SelectCheckList
{
    public int ID { get; set; }
    public String Name { get; set; }
    public bool IsChecked { get; set; }
}
