using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.Contract.Models;
using MoviesTime.Contract.ViewModels;
using MoviesTime.DataAccess.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers 
{
    [Area("TheaterManager")]
    public class ManageTheaterScreensController : Controller 
    {
        public readonly IUnitOfWork _unitOfWork;
        public ManageTheaterScreensController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
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
                List<TheaterScreen> theaterScreens = _unitOfWork.TheaterScreens.GetAll()
                                                        .Where(u => u.TheaterID == viewModel.selectedTheaterID)
                                                        .ToList();
                viewModel.selectTheaterList = GetTheatersAsSelectList();
                viewModel.theaterScreens = theaterScreens;
                return View("ManageTheaterScreens",viewModel);
            }
            return View(viewModel);
        }


        //private methods
        private List<SelectListItem> GetTheatersAsSelectList() {
            return _unitOfWork.Theaters.GetAll()
                                .Select(i => new SelectListItem() 
                                {
                                    Text = i.TheaterName,
                                    Value = i.TheaterID.ToString() 
                                })
                                .ToList();
        }
    }
}
