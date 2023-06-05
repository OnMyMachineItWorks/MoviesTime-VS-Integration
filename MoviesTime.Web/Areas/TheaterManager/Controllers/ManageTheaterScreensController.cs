using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.Contract.DbModels;
using MoviesTime.Contract.ViewModels;
using MoviesTime.BusinessLayer.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers;

[Area("TheaterManager")]
public class ManageTheaterScreensController : Controller 
{
    private readonly ISharedService _sharedService;
    private readonly ITheaterManager _theaterManager;
    public ManageTheaterScreensController(ISharedService sharedService, ITheaterManager theaterManager) 
    {
        _sharedService = sharedService;
        _theaterManager = theaterManager;
    }

    /// <summary>
    /// public Action methods
    /// </summary>
    /// <returns></returns>
    // Default Method on Page load
    public IActionResult ManageTheaterScreens(ManageTheaterScreensViewModel viewModel) 
    {
        viewModel.selectTheaterList = GetTheatersAsSelectList();
        return View(viewModel);
    }


    // Fetch Theater Screens section
    public IActionResult GetTheaterScreens(ManageTheaterScreensViewModel viewModel) 
    {
        if (viewModel.isEditMode) 
          return View("ManageTheaterScreens", viewModel); 
        if (viewModel.selectedTheaterID > 0) 
        {
            List<TheaterScreen> theaterScreens = _theaterManager.GetTheaterScreensByTheaterID(viewModel.selectedTheaterID);
            viewModel.selectTheaterList = GetTheatersAsSelectList();
            viewModel.theaterScreensList = theaterScreens;
            ModelState.Clear();
            return View("ManageTheaterScreens", viewModel);
        }
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateTheaterScreen(ManageTheaterScreensViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("|| model state invalid ||");
            return View("ManageTheaterScreens", viewModel);
        }
        if (viewModel.selectedTheaterID > 0
            && viewModel.theaterScreen != null 
            && viewModel.theaterScreen.ScreenName != null) 
        {
            TheaterScreen theaterScreen = new TheaterScreen()
                {
                    TheaterID = viewModel.selectedTheaterID,
                    ScreenName = viewModel.theaterScreen.ScreenName,
                    ScreenDescription = viewModel.theaterScreen.ScreenDescription,
                    IsAvailable = true,
                    IsActive = true,
                };
            //_theaterManager.CreateTheaterScreen(theaterScreen);
            return RedirectToAction("GetTheaterScreens", viewModel);
        }
        return RedirectToAction("ManageTheaterScreens");
    }

    public IActionResult EditTheaterScreen(int id)
    {
        TheaterScreen theaterScreenFromDB = _sharedService.GetTheaterScreenByID(id);
        ManageTheaterScreensViewModel viewModel = new ManageTheaterScreensViewModel()
        {
            selectedTheaterID = theaterScreenFromDB.TheaterID,
            selectTheaterList = GetTheatersAsSelectList(),
            theaterScreen = theaterScreenFromDB,
            theaterScreensList = _theaterManager.GetTheaterScreensByTheaterID(theaterScreenFromDB.TheaterID),
            isEditMode = true,
            //lstUsers = GetUsersAsSelectList(),
            //lstTheaters = GetTheaters(),
            //theater = _sharedService.GetTheaterByID(id),
            //isEditMode = true
        };
        return View("ManageTheaterScreens", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteTheaterScreen(int id)
    {
        // Delete the customer logic

        // Set the success message in ViewData
        //ViewData["DeleteSuccess"] = "Customer deleted successfully.";

        // Redirect back to the view
        return RedirectToAction("Index");
    }

    //private methods
    private List<SelectListItem> GetTheatersAsSelectList() 
    {
        return _sharedService.GetTheatersList()
                             .Select(i => new SelectListItem() 
                             {
                                 Text = i.TheaterName,
                                 Value = i.TheaterID.ToString() 
                             })
                             .ToList();
    }
}
