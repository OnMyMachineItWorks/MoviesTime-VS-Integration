using Microsoft.AspNetCore.Mvc;

namespace MoviesTime.Web.Areas.TheaterManager.Controllers;

public class ManageMoviesController : Controller
{
    public IActionResult ManageMovies() 
    {
        return View();
    }
}
