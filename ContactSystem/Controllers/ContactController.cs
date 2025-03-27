using ContactSystem.Models;
using ContactSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

public class ContactController : Controller
{
    public readonly IContactRepository _repository;

    public ContactController(IContactRepository contactRepository)
    {
        _repository = contactRepository;
    }
    public IActionResult Index()
    {
        return View(_repository.GetAll());
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult DeleteConfirm()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ContactModel contact)
    {
        _repository.Add(contact);
        return RedirectToAction("Index");
    }
}
