using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EventManagmentMVCCore.Filters
{
    public class ValidateAdminSession : IAuthorizationFilter
    {
        private readonly string _permission;
        public ValidateAdminSession(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetString("RoleID"))))
            {
                bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission);
                if (!isAuthorized)
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";
                    result.TempData["ErrorMessage"] = "Invalid User";
                    context.Result = result;
                }
            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";
                result.TempData["ErrorMessage"] = "You Session has been Expired";
                context.Result = result;
            }
        }
        private bool CheckUserPermission(ClaimsPrincipal user, string permission)
        {
            return permission == "1";
        }
    }
    public class ValidateSuperAdminSession : AuthorizeAttribute
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetString("RoleID"))))
            {
                string? UserCurrentRole = context.HttpContext.Session.GetString("RoleID");
                if (UserCurrentRole != "3") //Admin Role = 1
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";
                    result.TempData["ErrorMessage"] = "Invalid User";
                    context.Result = result;
                }
            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";
                result.TempData["ErrorMessage"] = "You Session has been Expired";
                context.Result = result;
            }
        }
    }

    public class ValidateUserSession : AuthorizeAttribute
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetString("RoleID"))))
            {
                string? UserCurrentRole = context.HttpContext.Session.GetString("RoleID");
                if (UserCurrentRole != "2") //Admin Role = 1
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";
                    result.TempData["ErrorMessage"] = "Invalid User";
                    context.Result = result;
                }
            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";
                result.TempData["ErrorMessage"] = "You Session has been Expired";
                context.Result = result;
            }
        }
    }

    public class AdminUserAttribute : TypeFilterAttribute
    {
        public AdminUserAttribute(string permission)
            : base(typeof(ValidateAdminSession))
        {
            Arguments = new object[] { permission };
        }
    }

}
