using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

public class ContactController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Create()
    {
        return View();
    }

    public ActionResult Edit()
    {
        return View();
    }

    public ActionResult DeleteConfirm()
    {
        return View();
    }
}

