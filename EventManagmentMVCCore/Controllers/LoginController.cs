using Event.DOM;
using Event.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using EventManagmentMVCCore.ViewModel;
using EventManagmentMVCCore.Filters;

namespace EventManagmentMVCCore.Controllers
{
    public class LoginController : Controller
    {
        public IConfiguration _config = null;
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepository db;
        public LoginController(ILogger<HomeController> logger, IConfiguration config, ILoginRepository loginRepository)
        {
            _config = config;
            db = loginRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = db.ValidateUser(model.UserName, model.Password);
                if (result != null)
                {
                    if (result.ID == 0 || result.ID < 0)
                    {
                        ViewBag.errormessage = "Entered Invalid Username and Password";
                    }
                    else
                    {
                        var RoleID = result.RoleID;
                        remove_Anonymous_Cookies(); //Remove Anonymous_Cookies
                        AddCookie_For_API_Validation(result.ID);
                        HttpContext.Session.SetString("UserID", Convert.ToString(result.ID));
                        HttpContext.Session.SetString("RoleID", Convert.ToString(result.RoleID));
                        if (RoleID == 1)
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else if (RoleID == 2)
                        {
                            return RedirectToAction("Dashboard", "CustomerDashboard");
                        }
                        else if (RoleID == 3)
                        {
                            return RedirectToAction("Dashboard", "SuperAdmin");
                        }
                    }
                }
                else
                {
                    ViewBag.errormessage = "Entered Invalid Username and Password";
                    return View();
                }
            }
            return View();
        }

        public void AddCookie_For_API_Validation(int ID)
        {
            string cookieToken;
            string formToken;
            AntiForgeryValidate antiForgeryValidate = new AntiForgeryValidate(_config);
            cookieToken = antiForgeryValidate.GenerateJSONWebToken();
            formToken = cookieToken;
            ViewBag.cookieToken = cookieToken;
            ViewBag.formToken = formToken;

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            options.Secure = true;
            options.HttpOnly = true;
            string value = ID + "*" + cookieToken + "*" + formToken + "*" + DateTime.Now.Date.ToShortDateString() + "*" + DateTime.Now.Date.ToShortTimeString();
            Response.Cookies.Append("EventChannel", value, options);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (Request.Cookies["EventChannel"] != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMilliseconds(1);
                Response.Cookies.Delete("EventChannel", options);
            }
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("RoleID");

            return RedirectToAction("Login", "Login");

        }

        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            if (Request.Cookies["EventChannel"] != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMilliseconds(1);
                Response.Cookies.Delete("EventChannel", options);
            }
        }

    }
}



