using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;

namespace TaskManagerApp.Authorizations
{
    public class Auth : ActionFilterAttribute, IAuthorizationFilter
    {
        private string _permission;
        public Auth(string permission = null)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Session.GetString("Role");

            if (role == null)
            {
                context.Result = new RedirectResult("/Account/Login");
                return;
            }
            if (_permission.Contains(role))
            {
                return;
            }
            else
            {
                context.Result = new RedirectResult("/Account/UnAuthorization");
            }
        }
    }
}
