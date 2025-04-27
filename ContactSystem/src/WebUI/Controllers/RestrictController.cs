using Microsoft.AspNetCore.Mvc;
using Application.Filters;

namespace WebUI.Controllers;

[LoggedUserPage]
public class RestrictController : Controller
{
    public IActionResult Index() =>
        View();
}