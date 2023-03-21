using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.Contract.Models;
using MoviesTime.Contract.ViewModels;
using MoviesTime.DataAccess.IRepository;
using MoviesTime.BusinessLayer.Interface;
using MoviesTime.BusinessLayer.TheaterManager;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers 
{
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
        public IActionResult ManageTheaterScreens() 
        {
            ManageTheaterScreensViewModel viewModel = new ManageTheaterScreensViewModel() 
            {
                selectTheaterList = GetTheatersAsSelectList(),
            };
            return View(viewModel);
        }

        // Get Method for Theater Screens section
        public IActionResult GetTheaterScreens(ManageTheaterScreensViewModel viewModel) 
        {
            if (viewModel.selectedTheaterID > 0) 
            {
                List<TheaterScreen> theaterScreens = _theaterManager.GetTheaterScreensByTheaterID(viewModel.selectedTheaterID);
                viewModel.selectTheaterList = GetTheatersAsSelectList();
                viewModel.theaterScreensList = theaterScreens;
                return View("ManageTheaterScreens",viewModel);
            }
            return View(viewModel);
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
}
