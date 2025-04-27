using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace WebUI.ViewComponents;

public class Menu : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string userSession = await Task.Run(() => HttpContext.Session.GetString("userLoggedSession"));

        if (string.IsNullOrEmpty(userSession)) return null;

        UserModel user = JsonSerializer.Deserialize<UserModel>(userSession);

        return View(user);
    }
}
