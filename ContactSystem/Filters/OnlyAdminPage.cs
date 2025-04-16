using System.Text.Json;
using ContactSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactSystem.Filters;

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

            if (user.Profile != Enums.Profile.Admin)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Restrict" }, { "action", "Index" } });
            }
        }

        base.OnActionExecuting(context);
    }
}
