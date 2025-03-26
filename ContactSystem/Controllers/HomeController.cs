using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactSystem.Models;

namespace ContactSystem.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        HomeModel home = new("Pedro", "pedro.mcrescencio@gmail.com", "84 99813-0186");
        return View(home);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
