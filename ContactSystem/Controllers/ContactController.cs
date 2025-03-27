using ContactSystem.Models;
using ContactSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

public class ContactController : Controller
{
    public readonly IContactRepository _repository;

    public ContactController(IContactRepository contactRepository) =>
        _repository = contactRepository;

    public IActionResult Index() =>
        View(_repository.GetAll());

    public IActionResult Create() =>
        View();

    public IActionResult Edit(int id) =>
        View(_repository.GetById(id));

    public IActionResult DeleteConfirm(int id) =>
        View(_repository.GetById(id));

    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Create(ContactModel contact)
    {
        _repository.Add(contact);
        return RedirectToAction("Index");
    }

    [HttpPut]
    public IActionResult Edit(ContactModel contact)
    {
        _repository.Update(contact);
        return RedirectToAction("Index");
    }
}
