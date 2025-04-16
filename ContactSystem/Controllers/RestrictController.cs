using ContactSystem.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

[LoggedUserPage]
public class RestrictController : Controller
{
    public IActionResult Index() =>
        View();
}