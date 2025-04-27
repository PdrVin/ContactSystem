using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Domain.Models;
using Application.Interfaces;

namespace Application.Helper;

public class LogSession : ILogSession
{
    private readonly IHttpContextAccessor _httpContext;

    public LogSession(IHttpContextAccessor httpContext) =>
        _httpContext = httpContext;

    public UserModel SearchUserSession()
    {
        string userSession = _httpContext.HttpContext.Session.GetString("userLoggedSession");
        if (string.IsNullOrEmpty(userSession)) return null;

        return JsonSerializer.Deserialize<UserModel>(userSession);
    }

    public void CreateUserSession(UserModel user)
    {
        string jsonValue = JsonSerializer.Serialize(user);

        _httpContext.HttpContext.Session.SetString("userLoggedSession", jsonValue);
    }

    public void RemoveUserSession()
    {
        _httpContext.HttpContext.Session.Remove("userLoggedSession");
    }
}
