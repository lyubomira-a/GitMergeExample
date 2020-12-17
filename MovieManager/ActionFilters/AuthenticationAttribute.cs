using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieManager.Entities;
using MovieManager.Extensions;

namespace MovieManager.ActionFilters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<User>("loggedUser") == null)
                context.Result = new RedirectResult("/Home/Login");
        }


        /*public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (AuthenticationService.LoggedUser == null)
                context.Result = new RedirectResult("/Home/Login");
        }*/
    }
}
