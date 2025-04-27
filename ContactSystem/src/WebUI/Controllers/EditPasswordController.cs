using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Models;

namespace WebUI.Controllers;

public class EditPasswordController : Controller
{
    private readonly IUserRepository _repository;
    private readonly ILogSession _session;

    public EditPasswordController(IUserRepository repository, ILogSession session)
    {
        _repository = repository;
        _session = session;
    }

    public IActionResult Index() =>
        View();

    [HttpPost]
    public IActionResult Edit(EditPasswordModel editPassword)
    {
        try
        {
            UserModel loggedUser = _session.SearchUserSession();
            editPassword.Id = loggedUser.Id;

            if (ModelState.IsValid)
            {
                _repository.UpdatePassword(editPassword);
                TempData["MessageSuccess"] = "Senha alterada com sucesso.";
            }

            return View("Index", editPassword);
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Alteração de Senha: {error.Message}";
            return View("Index", editPassword);
        }
    }
}
