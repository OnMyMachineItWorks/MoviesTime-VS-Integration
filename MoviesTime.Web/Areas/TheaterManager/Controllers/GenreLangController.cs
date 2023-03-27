using Microsoft.AspNetCore.Mvc;
using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.Models;
using MoviesTime.Contract.ViewModels;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers;

[Area("TheaterManager")]
public class GenreLangController : Controller
{
    private readonly ISharedService _sharedService;
    private readonly ITheaterManager _theaterManager;

    public GenreLangController(ITheaterManager theaterManager, ISharedService sharedService)
    {
        _sharedService = sharedService;
        _theaterManager = theaterManager;
    }

    //Public methods
    public IActionResult ManageGenreLanguages(ManageGenreLanguagesViewModel viewModel)
    {
        viewModel.lstGenres = GetGenresList();
        viewModel.lstLanguages = GetlanguagesList();
        return View(viewModel);
    }

    public IActionResult CreateGenre(ManageGenreLanguagesViewModel viewModel) 
    {

        return RedirectToAction("ManageGenreLanguages");
    }

    public IActionResult CreateLanguage(ManageGenreLanguagesViewModel viewModel)
    {

        return RedirectToAction("ManageGenreLanguages");
    }

    public IActionResult EditGenre(int id)
    {
        ManageGenreLanguagesViewModel viewModel = new ManageGenreLanguagesViewModel()
        {
            genre = _theaterManager.GetGenreDetailsByID(id),
            lstGenres = GetGenresList(),
            lstLanguages = GetlanguagesList(),
            IsGenreEditMode = true
        };
        return View("ManageGenreLanguages", viewModel);
    }

    public IActionResult EditLanguage(int id)
    {
        ManageGenreLanguagesViewModel viewModel = new ManageGenreLanguagesViewModel()
        {
            language = _theaterManager.GetLanguageDetailsByID(id),
            lstGenres = GetGenresList(),
            lstLanguages = GetlanguagesList(),
            IsLanguageEditMode = true
        };
        return View("ManageGenreLanguages", viewModel);
    }

    // Private Methods
    private List<Genres> GetGenresList()
    {
        return _sharedService.GetGenresList();
    }
    private List<Languages> GetlanguagesList()
    {
        return _sharedService.GetLanguagesList();
    }
}
