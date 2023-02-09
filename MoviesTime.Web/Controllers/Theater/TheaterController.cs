using Microsoft.AspNetCore.Mvc;

namespace MoviesTime.Web.Controllers.Theater
{
    public class TheaterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
