using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.Models;
using MoviesTime.Contract.ViewModels;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers 
{
    [Area("TheaterManager")]
    public class ManageTheatersController : Controller 
    {
        //configure unit of work
        private readonly ISharedService _sharedService;

        public ManageTheatersController(ISharedService sharedService) 
        {
            _sharedService = sharedService; 
        }

        /// <summary>
        /// Public methods
        /// </summary>
        /// <returns></returns>
        // Default method on page load
        public IActionResult ManageTheaters() 
        {
            ManageTheatersViewModel viewModel = new ManageTheatersViewModel();
            viewModel.lstUsers = GetUsersAsSelectList();
            viewModel.lstTheaters = GetTheaters();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Submit action method
        public IActionResult CreateTheater(ManageTheatersViewModel theaters) 
        {
            if (theaters.theater != null 
                    && theaters.theater.TheaterName != null 
                    && theaters.theater.ManagerID > 0) 
            {
                Console.WriteLine("|| Successfully triggered response ||");
                //_unitOfWork.Theaters.Add(theater.theaters);
                //_unitOfWork.Save();
            }
            return RedirectToAction("ManageTheaters");
        }

        public IActionResult EditTheater(int id) 
        {
            ManageTheatersViewModel viewModel = new ManageTheatersViewModel() 
            {
                lstUsers = GetUsersAsSelectList(),
                lstTheaters = GetTheaters(),
                theater = _sharedService.GetTheaterByID(id),
                isEditMode = true
            };
            return View("ManageTheaters", viewModel);
        }

        /// <summary>
        /// private methods
        /// </summary>
        /// <returns></returns>
        // get users dropdown list values
        private List<SelectListItem> GetUsersAsSelectList() 
        {
            return _sharedService.GetUsersList()
                                .Select(i => new SelectListItem() 
                                {
                                    Text = i.Username,
                                    Value = i.UserID.ToString()
                                }).ToList();
        }

        // get main Grid/table data
        private List<Theaters> GetTheaters() 
        {
            return _sharedService.GetTheatersList().ToList();
        }
    }
}
