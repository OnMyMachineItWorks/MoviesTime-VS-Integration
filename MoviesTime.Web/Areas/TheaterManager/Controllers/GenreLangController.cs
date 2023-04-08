using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        viewModel.lstLanguages = GetLanguagesList();
        return View(viewModel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateGenre(ManageGenreLanguagesViewModel viewModel) 
    {
        //if (!viewModel.genre.GenreName.IsNullOrEmpty()
        //    && viewModel.genre.ID == 0)  
        //    _theaterManager.CreateGenre(viewModel.genre);
        return RedirectToAction("ManageGenreLanguages");
    }

    public IActionResult CreateLanguage(ManageGenreLanguagesViewModel viewModel)
    {
        //if (!viewModel.language.Language.IsNullOrEmpty() 
        //    && viewModel.language.LanguageID == 0)
        //    _theaterManager.CreateLanguage(viewModel.language);
        return RedirectToAction("ManageGenreLanguages");
    }

    public IActionResult EditGenre(int id)
    {
        ManageGenreLanguagesViewModel viewModel = new ManageGenreLanguagesViewModel()
        {
            genre = _theaterManager.GetGenreDetailsByID(id),
            lstGenres = GetGenresList(),
            lstLanguages = GetLanguagesList(),
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
            lstLanguages = GetLanguagesList(),
            IsLanguageEditMode = true
        };
        return View("ManageGenreLanguages", viewModel);
    }

    // Private Methods
    private List<Genres> GetGenresList()
    {
        return _sharedService.GetGenresList();
    }
    private List<Languages> GetLanguagesList()
    {
        return _sharedService.GetLanguagesList();
    }
}
