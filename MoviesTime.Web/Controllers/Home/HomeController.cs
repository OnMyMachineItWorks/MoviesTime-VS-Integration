using Microsoft.AspNetCore.Mvc;
using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.Web.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ITestInterface _db;

        public HomeController(ITestInterface db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TestModel> lstTest = _db.GetAll();
            return View(lstTest);
        }
    }
}
