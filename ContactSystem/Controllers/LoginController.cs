using ContactSystem.Helper;
using ContactSystem.Interfaces;
using ContactSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

public class LoginController : Controller
{
    private readonly IUserRepository _repository;
    private readonly ILogSession _session;
    private readonly IEmail _email;

    public LoginController(IUserRepository userRepository, ILogSession session, IEmail email)
    {
        _repository = userRepository;
        _session = session;
        _email = email;
    }

    public IActionResult Index()
    {
        if (_session.SearchUserSession() != null) return RedirectToAction("Index", "Home");
        return View();
    }

    public IActionResult ResetPassword() =>
        View();

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

    [HttpPost]
    public IActionResult ResetPasswordLink(ResetPasswordModel reset)
    {
        try
        {
            if (!ModelState.IsValid) return View("Index");

            UserModel user = _repository.GetByLoginAndEmail(reset.Login, reset.Email);

            if (user == null)
            {
                TempData["MessageError"] = $"Erro no processo de Redefinição de Senha. Verifique Novamente.";
                return RedirectToAction("Index");
            }

            string newPassword = user.GenerateNewPassword();
            string subject = "ContactSystem - Nova Senha";
            string message = $"Sua nova senha é: {newPassword}";

            bool emailSent = _email.Send(user.Email, subject, message);

            if (emailSent)
            {
                _repository.Update(user);
                TempData["MessageSuccess"] = $"Nova Senha enviada para seu E-mail.";
            }
            else
                TempData["MessageError"] = $"Erro no processo de Envio do Email. Tente Novamente.";

            return RedirectToAction("Index", "Login");
        }
        catch (Exception error)
        {   
            TempData["MessageError"] = $"Erro no processo de Redefinição de Senha: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}
