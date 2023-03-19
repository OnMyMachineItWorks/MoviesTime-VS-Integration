using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesTime.Contract.Models;
using MoviesTime.Contract.ViewModels;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers 
{
    [Area("TheaterManager")]
    public class ManageTheatersController : Controller 
    {
        //configure unit of work
        private readonly IUnitOfWork _unitOfWork;
        public ManageTheatersController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
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
        public IActionResult CreateNewTheater(ManageTheatersViewModel theater) 
        {
            if (theater.theaters != null 
                    && theater.theaters.TheaterName != null 
                    && theater.theaters.ManagerID > 0) 
            {
                Console.WriteLine("|| Successfully triggered response ||");
                //_unitOfWork.Theaters.Add(theater.theaters);
                //_unitOfWork.Save();
            }
            return RedirectToAction("ManageTheaters");
        }

        public IActionResult EditTheater(int? id) 
        {
            ManageTheatersViewModel viewModel = new ManageTheatersViewModel() 
            {
                lstUsers = GetUsersAsSelectList(),
                lstTheaters = GetTheaters(),
                theaters = _unitOfWork.Theaters.GetFirstOrDefault(u => u.TheaterID == id),
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
            return _unitOfWork.Users.GetAll()
                                .Select(i => new SelectListItem() 
                                {
                                    Text = i.Username,
                                    Value = i.UserID.ToString()
                                }).ToList();
        }

        // get main Grid/table data
        private List<Theaters> GetTheaters() 
        {
            return _unitOfWork.Theaters.GetAll().ToList();
        }
    }
}
