using Microsoft.AspNetCore.Mvc;
using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;
using MoviesTime.DataAccess.Repository;


namespace MoviesTime.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Users> lstTest = _unitOfWork.Users.GetAll();
            return View(lstTest);
        }
    }
}
