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
        try
        {
            if (_repository.Delete(id))
                TempData["MessageSuccess"] = "Contato deletado com sucesso.";
            else
                TempData["MessageError"] = "Erro no processo de Exclusão.";

            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Exclusão: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Create(ContactModel contact)
    {
        try
        {
            if (!ModelState.IsValid) return View(contact);

            contact = _repository.Add(contact);
            TempData["MessageSuccess"] = "Contato cadastrado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Cadastro: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Edit(ContactModel contact)
    {
        try
        {
            if (!ModelState.IsValid) return View(contact);

            contact = _repository.Update(contact);
            TempData["MessageSuccess"] = "Contato atualizado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Atualização: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}
