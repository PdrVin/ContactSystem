using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Domain.Models;
using Domain.Enums;

namespace Application.Filters;

public class OnlyAdminPage : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string userSession = context.HttpContext.Session.GetString("userLoggedSession");

        if (string.IsNullOrEmpty(userSession))
        {
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
        }
        else
        {
            UserModel user = JsonSerializer.Deserialize<UserModel>(userSession);

            if (user == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }

            if (user.Profile != Profile.Admin)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Restrict" }, { "action", "Index" } });
            }
        }

        base.OnActionExecuting(context);
    }
}
