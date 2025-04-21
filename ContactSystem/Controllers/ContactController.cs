using ContactSystem.Models;
using ContactSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ContactSystem.Filters;
using ContactSystem.Helper;

namespace ContactSystem.Controllers;

[LoggedUserPage]
public class ContactController : Controller
{
    public readonly IContactRepository _repository;
    public readonly ILogSession _session;

    public ContactController(IContactRepository contactRepository, ILogSession session)
    {
        _repository = contactRepository;
        _session = session;
    }

    public IActionResult Index()
    {
        UserModel loggedUser = _session.SearchUserSession();
        return View(_repository.GetAll(loggedUser.Id));
    }

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

            UserModel loggedUser = _session.SearchUserSession();
            contact.UserId = loggedUser.Id;
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

            UserModel loggedUser = _session.SearchUserSession();
            contact.UserId = loggedUser.Id;

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
