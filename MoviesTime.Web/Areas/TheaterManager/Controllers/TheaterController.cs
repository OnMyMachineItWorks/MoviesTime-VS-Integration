using Microsoft.AspNetCore.Mvc;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers;

[Area("TheaterManager")]
public class TheaterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
