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
        private readonly IUnitOfWork _unitOfWork;

        public ManageTheatersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Public methods
        public IActionResult ManageTheaters()
        {
            ManageTheatersViewModel viewModel = new ManageTheatersViewModel();

            viewModel.UsersList = _unitOfWork.Users.GetAll()
                                        .Select(i => new SelectListItem()
                                        {
                                            Text = i.Username,
                                            Value = i.UserID.ToString()
                                        });
            viewModel.lstTheaters = AddDummyTheaters();

            IEnumerable<Theaters> theaterFromDb = _unitOfWork.Theaters
                                         .GetAll();

            if (theaterFromDb.Any())
            {
                foreach (Theaters item in theaterFromDb)
                    viewModel.lstTheaters.Add(item);

            }
            else
            {
                Theaters theater = new()
                {
                    TheaterID = 4,
                    TheaterName = "PVR MoviesTime",
                    ManagerID = 1,
                    TheaterContact = "Contact Admin if facing any Issues.",
                    IsActive = true
                };
                viewModel.lstTheaters.Add(theater);
            }

            return View(viewModel);
        }

        //private methods
        private List<Theaters> AddDummyTheaters()
        {

            List<Theaters> lstTheaters = new List<Theaters>();
            Theaters theater = new()
            {
                TheaterID = 1,
                TheaterName = "Apna Cinema",
                TheaterContact = "Apke sath hamesha"
            };
            lstTheaters.Add(theater);
            Theaters theater2 = new()
            {
                TheaterID = 2,
                TheaterName = "mera Cinema",
                TheaterContact = "sirf mera"
            };
            lstTheaters.Add(theater2);

            return lstTheaters;
        }


    }
}
