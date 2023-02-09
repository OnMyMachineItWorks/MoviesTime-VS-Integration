using Microsoft.AspNetCore.Mvc;

namespace MoviesTime.Web.Controllers.Customer
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
