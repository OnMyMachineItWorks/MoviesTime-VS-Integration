using Microsoft.AspNetCore.Mvc;
using MoviesTime.BusinessLayer.Interface;
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

    public IActionResult ManageMovies(ManageMoviesViewModel viewModel)
    {
        viewModel = GetViewModelFromDB();
        _sharedService.TestGenreReturns();
        //viewModel.selectedGenre = 
        return View(viewModel);
    }

    public IActionResult CreateMovie(ManageMoviesViewModel viewModel)
    {
        return RedirectToAction("ManageMovies");
    }

    public IActionResult EditMovies(int id)
    {
        ManageMoviesViewModel viewModel = GetViewModelFromDB();
        viewModel.movieDetails = _sharedService.GetMovieDetailsByID(id);
        viewModel.isMovieEditMode = true;
        return View("ManageMovies", viewModel);
    }

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

    //private SelectCheckList GetIsCheckedMapping(ManageMoviesViewModel viewModel) 
    //{ }

}
