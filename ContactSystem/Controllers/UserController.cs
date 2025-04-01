using ContactSystem.Interfaces;
using ContactSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

public class UserController : Controller
{
    public readonly IUserRepository _repository;

    public UserController(IUserRepository userRepository) =>
        _repository = userRepository;

    public IActionResult Index() =>
        View(_repository.GetAll());

    public IActionResult Create() =>
        View();

    [HttpPost]
    public IActionResult Create(UserModel user)
    {

        try
        {
            if (ModelState.IsValid)
            {
                user = _repository.Add(user);
                TempData["MessageSuccess"] = "Usuário cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            return View(user);
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Cadastro: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}
