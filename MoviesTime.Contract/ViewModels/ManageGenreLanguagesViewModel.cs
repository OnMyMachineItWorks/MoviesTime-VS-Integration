using MoviesTime.Contract.Models;

namespace MoviesTime.Contract.ViewModels;

public class ManageGenreLanguagesViewModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool IsGenreEditMode { get; set; }
    public bool IsLanguageEditMode { get; set;}
    public Genres genre { get; set; }
    public Languages language { get; set; }
    public List<Genres> lstGenres { get; set; }
    public List<Languages> lstLanguages { get; set; }
}
