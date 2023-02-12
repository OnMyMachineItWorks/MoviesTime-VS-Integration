using Microsoft.AspNetCore.Mvc;

namespace MoviesTime.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
