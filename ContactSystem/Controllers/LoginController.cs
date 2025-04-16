using ContactSystem.Helper;
using ContactSystem.Interfaces;
using ContactSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

public class LoginController : Controller
{
    private readonly IUserRepository _repository;
    private readonly ILogSession _session;

    public LoginController(IUserRepository userRepository, ILogSession session)
    {
        _repository = userRepository;
        _session = session;
    }

    public IActionResult Index()
    {
        if (_session.SearchUserSession() != null) return RedirectToAction("Index", "Home");
        return View();
    }

    public IActionResult Exit()
    {
        _session.RemoveUserSession();
        return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public IActionResult Enter(LoginModel log)
    {
        try
        {
            if (!ModelState.IsValid) return View("Index");

            UserModel user = _repository.GetByLogin(log.Login);

            if (user == null || !user.IsPasswordValid(log.Password))
            {
                TempData["MessageError"] = $"Usuário e/ou Senha inválido(s). Tente Novamente.";
                return RedirectToAction("Index");
            }

            _session.CreateUserSession(user);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Login: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}
