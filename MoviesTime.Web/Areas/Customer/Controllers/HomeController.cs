using Microsoft.AspNetCore.Mvc;
using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.DbModels;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;
using MoviesTime.DataAccess.Repository;

namespace MoviesTime.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private ISharedService _sharedService = null;

        public HomeController(IUnitOfWork unitOfWork, ISharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public IActionResult Index()
        {
            IEnumerable<Users> lstTest = _sharedService.GetUsersList();
            //int s = _customer.GetUsersCount();
            return View(lstTest);
        }
    }
}
