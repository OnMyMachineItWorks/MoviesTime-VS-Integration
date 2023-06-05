using Microsoft.AspNetCore.Mvc;
using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.DbModels;
using MoviesTime.Contract.ViewModels;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers;

[Area("TheaterManager")]
public class ManageMoviesController : Controller
{
    private readonly ISharedService _sharedService;
    private readonly ITheaterManager _theaterManager;

    public ManageMoviesController(ISharedService sharedService, ITheaterManager theaterManager)
    {
        _sharedService = sharedService;
        _theaterManager = theaterManager;
    }

    /// <summary>
    /// ActionResult Region
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    // Default method on page load
    public IActionResult ManageMovies(ManageMoviesViewModel viewModel)
    {
        viewModel = GetViewModelFromDB();
        return View(viewModel);
    }

    // Submit button for ManageMovies page
    [HttpPost]
    public IActionResult CreateMovie(ManageMoviesViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("|| model state invalid ||");
            viewModel = GetViewModelFromDB();
            return View("ManageMovies", viewModel);
        }
        // Edit Movie Submit click
        if (viewModel.isMovieEditMode)
        {
            _theaterManager.UpdateMovie(viewModel.movieDetails, viewModel.SelectedGenres, viewModel.SelectedLanguages);
            return RedirectToAction("ManageMovies");
        }
       // _theaterManager.CreateMovie(viewModel.movieDetails, viewModel.SelectedGenres, viewModel.SelectedLanguages);
        return RedirectToAction("ManageMovies");
    }

    //Movies Table - Edit Link click
    public IActionResult EditMovies(int id)
    {
        ManageMoviesViewModel viewModel = GetViewModelFromDB();
        viewModel.movieDetails = _sharedService.GetMoviesWithMappings(id);
        if (viewModel.movieDetails == null)
        {
            return NotFound();
        }
        viewModel.movieGenres = viewModel.genreList
                                 .Select(g => new SelectCheckList
                                 {
                                     ID = g.ID,
                                     Name = g.GenreName,
                                     IsChecked = viewModel.movieDetails.MovieGenreMappings
                                                          .Any(mg => mg.GenreID == g.ID)
                                 }).ToList();
        viewModel.movieLanguages = viewModel.languageList
                                .Select(l => new SelectCheckList
                                {
                                    ID = l.LanguageID,
                                    Name = l.Language,
                                    IsChecked = viewModel.movieDetails.MovieLanguageMappings
                                                         .Any(ml => ml.LanguageID == l.LanguageID)
                                }).ToList();
        viewModel.isMovieEditMode = true;
        return View("ManageMovies", viewModel);
    }

    /// <summary>
    /// Private Methods
    /// </summary>
    /// <returns></returns>
    private ManageMoviesViewModel GetViewModelFromDB()
    {
        ManageMoviesViewModel viewModel = new ManageMoviesViewModel()
        {
            genreList = _sharedService.GetGenresList(),
            languageList = _sharedService.GetLanguagesList(),
            moviesList = _sharedService.GetMoviesList(),
        };
        return viewModel;
    }
}
