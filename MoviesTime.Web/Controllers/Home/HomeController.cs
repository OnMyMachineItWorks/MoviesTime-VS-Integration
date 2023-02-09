using Microsoft.AspNetCore.Mvc;
using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.Database;

namespace MoviesTime.Web.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TestModel> lstTest = _db.TestTable;
            return View(lstTest);
        }
    }
}
