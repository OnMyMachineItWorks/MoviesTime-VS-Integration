using Microsoft.AspNetCore.Mvc;
using MoviesTime.BusinessLayer.Interface;
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
        private ICustomer _customer = null;

        public HomeController(IUnitOfWork unitOfWork, ICustomer customer)
        {
            _unitOfWork = unitOfWork;
            _customer = customer;
        }

        public IActionResult Index()
        {
            IEnumerable<Users> lstTest = _unitOfWork.Users.GetAll();
            int s = _customer.GetUsersCount();
            return View(lstTest);
        }
    }
}
