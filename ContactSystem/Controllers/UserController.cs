using ContactSystem.Filters;
using ContactSystem.Interfaces;
using ContactSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.Controllers;

[OnlyAdminPage]
public class UserController : Controller
{
    public readonly IUserRepository _userRepository;
    public readonly IContactRepository _contactRepository;

    public UserController(IUserRepository userRepository, IContactRepository contactRepository)
    {
        _userRepository = userRepository;
        _contactRepository = contactRepository;
    }

    public IActionResult Index() =>
        View(_userRepository.GetAll());

    public IActionResult Create() =>
        View();

    public IActionResult Edit(int id) =>
        View(_userRepository.GetById(id));

    public IActionResult DeleteConfirm(int id) =>
        View(_userRepository.GetById(id));

    public IActionResult Delete(int id)
    {
        try
        {
            if (_userRepository.Delete(id))
                TempData["MessageSuccess"] = "Usuário deletado com sucesso.";
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

    public IActionResult ListContactsByUserId(int userId)
    {
        List<ContactModel> contacts = _contactRepository.GetAll(userId);
        return PartialView("UserContacts", contacts);
    }

    [HttpPost]
    public IActionResult Create(UserModel user)
    {
        try
        {
            if (!ModelState.IsValid) return View(user);

            user = _userRepository.Add(user);
            TempData["MessageSuccess"] = "Usuário cadastrado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Cadastro: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Edit(UserDto userDto)
    {
        try
        {
            UserModel? user = null;

            if (!ModelState.IsValid) return View(user);

            user = new()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Login = userDto.Login,
                Email = userDto.Email,
                Profile = userDto.Profile,
            };

            user = _userRepository.Update(user);
            TempData["MessageSuccess"] = "Usuário atualizado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["MessageError"] = $"Erro no processo de Atualização: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}
